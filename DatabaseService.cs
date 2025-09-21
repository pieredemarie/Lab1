using System;
using System.Data;
using Npgsql;
using System.Configuration;

namespace KLab1
{
    public class DatabaseService
    {
        private string connectionString;

        public DatabaseService()
        {
            // Получаем строку подключения из app.config
            connectionString = ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;
        }

        public DataSet GetAuthors()
        {
            DataSet dataSet = new DataSet();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Authors";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                adapter.Fill(dataSet, "Authors");
            }

            return dataSet;
        }

        public void SaveAuthorsChanges(DataSet dataSet)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Authors";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapter);

                adapter.Update(dataSet, "Authors");
            }
        }

        public void DeleteAuthor(int authorId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Authors WHERE AuthorID = @AuthorID";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AuthorID", authorId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetBooksWithAuthors()
        {
            DataSet dataSet = new DataSet();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT b.BookID, b.Title, b.YearPublished, b.Price, 
                           a.AuthorID, a.Name as AuthorName, a.Country
                    FROM Books b 
                    INNER JOIN Authors a ON b.AuthorID = a.AuthorID";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                adapter.Fill(dataSet, "Books");
            }

            return dataSet;
        }

        public void SaveBooksChanges(DataSet dataSet)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BookID, Title, YearPublished, Price, AuthorID FROM Books";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapter);

                adapter.Update(dataSet, "Books");
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Books WHERE BookID = @BookID";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookID", bookId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAuthorsForComboBox()
        {
            DataTable dataTable = new DataTable();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AuthorID, Name FROM Authors ORDER BY Name";

                using (var command = new NpgsqlCommand(query, connection))
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public List<string> GetAllCountries()
        {
            List<string> countries = new List<string>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Country FROM Authors WHERE Country IS NOT NULL ORDER BY Country";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        countries.Add(reader.GetString(0));
                    }
                }
            }

            return countries;
        }

        public DataTable GetBooksByAuthorCountry(string country)
        {
            DataTable dataTable = new DataTable();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // SQL запрос с JOIN для получения книг авторов из указанной страны
                string query = @"
                    SELECT 
                        b.Title as ""Название книги"", 
                        a.Name as ""Автор"", 
                        a.Country as ""Страна"",
                        b.Price as ""Цена"",
                        b.YearPublished as ""Год издания""
                    FROM Books b 
                    INNER JOIN Authors a ON b.AuthorID = a.AuthorID 
                    WHERE a.Country = @Country 
                    ORDER BY b.Title";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Добавляем параметр для защиты от SQL-инъекций
                    command.Parameters.AddWithValue("@Country", country);

                    // Используем DataReader (подключенный режим)
                    using (var reader = command.ExecuteReader())
                    {
                        // Создаем структуру таблицы на основе результата запроса
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dataTable.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                        }

                        // Читаем данные построчно
                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // Проверяем на NULL значения
                                if (reader.IsDBNull(i))
                                    row[i] = DBNull.Value;
                                else
                                    row[i] = reader.GetValue(i);
                            }
                            dataTable.Rows.Add(row);
                        }
                    }
                }
            }

            return dataTable;
        }


        public DataTable GetBooksByPriceAndYear(decimal minPrice, decimal maxPrice, int startYear, int endYear)
        {
            DataSet dataSet = new DataSet();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Вызываем функцию, а не процедуру
                string query = @"
            SELECT * FROM get_books_by_price_and_year(
                @min_price, @max_price, @start_year, @end_year
            )";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@min_price", minPrice);
                    command.Parameters.AddWithValue("@max_price", maxPrice);
                    command.Parameters.AddWithValue("@start_year", startYear);
                    command.Parameters.AddWithValue("@end_year", endYear);

                    // Используем DataAdapter для отключенного режима
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);
                    }
                }
            }

            return dataSet.Tables.Count > 0 ? dataSet.Tables[0] : new DataTable();
        }


        public void CreateStoredProcedureIfNotExists()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем существование функции
                    string checkFunctionSql = @"
                SELECT EXISTS (
                    SELECT 1 FROM pg_proc 
                    WHERE proname = 'get_books_by_price_and_year'
                )";

                    bool functionExists;
                    using (var checkCmd = new NpgsqlCommand(checkFunctionSql, connection))
                    {
                        functionExists = (bool)checkCmd.ExecuteScalar();
                    }

                    if (!functionExists)
                    {
                        // Создаем функцию
                        string createFunctionSql = @"
                    CREATE FUNCTION get_books_by_price_and_year(
                        p_min_price DECIMAL,
                        p_max_price DECIMAL, 
                        p_start_year INT,
                        p_end_year INT
                    )
                    RETURNS TABLE (
                        book_title VARCHAR,
                        author_name VARCHAR,
                        author_country VARCHAR,
                        book_price DECIMAL,
                        book_year INT
                    )
                    LANGUAGE plpgsql
                    AS $$
                    BEGIN
                        RETURN QUERY
                        SELECT 
                            b.Title,
                            a.Name,
                            a.Country,
                            b.Price,
                            b.YearPublished
                        FROM Books b
                        INNER JOIN Authors a ON b.AuthorID = a.AuthorID
                        WHERE b.Price BETWEEN p_min_price AND p_max_price
                          AND b.YearPublished BETWEEN p_start_year AND p_end_year
                        ORDER BY b.Price DESC, b.YearPublished DESC;
                    END;
                    $$;";

                        using (var createCmd = new NpgsqlCommand(createFunctionSql, connection))
                        {
                            createCmd.ExecuteNonQuery();
                            MessageBox.Show("Функция успешно создана!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания функции: {ex.Message}");
            }
        }
    }
}