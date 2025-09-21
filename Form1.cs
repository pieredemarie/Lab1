using System.Data;

namespace KLab1
{
    public partial class Form1 : Form
    {
        private DatabaseService dbService;
        private DataSet authorsDataSet;
        private DataSet booksDataSet;
        public Form1()
        {
            InitializeComponent();
            dbService = new DatabaseService();
            LoadAllData();
        }

        private void LoadAllData()
        {
            // ��������� ������ ��� ���� ������� �����
            LoadAuthorsData();
            LoadBooksData();
            LoadCountries();
        }

        private void LoadAuthorsData()
        {
            try
            {
                authorsDataSet = dbService.GetAuthors();
                dataGridViewAuthors.DataSource = authorsDataSet.Tables[0];
                ConfigureAuthorsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� �������: {ex.Message}");
            }
        }

        private void ConfigureAuthorsDataGridView()
        {
            dataGridViewAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAuthors.ReadOnly = false;

            // ����������� �������
            if (dataGridViewAuthors.Columns.Contains("AuthorID"))
            {
                dataGridViewAuthors.Columns["AuthorID"].HeaderText = "ID ������";
                dataGridViewAuthors.Columns["AuthorID"].ReadOnly = true;
            }

            if (dataGridViewAuthors.Columns.Contains("Name"))
            {
                dataGridViewAuthors.Columns["Name"].HeaderText = "��� ������";
            }

            if (dataGridViewAuthors.Columns.Contains("Country"))
            {
                dataGridViewAuthors.Columns["Country"].HeaderText = "������";
            }
        }
        private void LoadBooksData()
        {
            try
            {
                booksDataSet = dbService.GetBooksWithAuthors();
                dataGridViewBooks.DataSource = booksDataSet.Tables[0];
                ConfigureBooksDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ����: {ex.Message}");
            }
        }

        private void ConfigureBooksDataGridView()
        {
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.ReadOnly = false;

          
            booksDataSet = dbService.GetBooksWithAuthors();
            dataGridViewBooks.DataSource = booksDataSet.Tables[0];

            
            ConfigureBooksColumns();

            // ����������� ���������� ������ ��� �������
            SetupAuthorComboBoxColumn();
        }

        
        private void ConfigureBooksColumns()
        {
            
            foreach (DataGridViewColumn column in dataGridViewBooks.Columns)
            {
                column.Visible = false;
            }

            if (dataGridViewBooks.Columns.Contains("BookID"))
            {
                dataGridViewBooks.Columns["BookID"].Visible = true;
                dataGridViewBooks.Columns["BookID"].HeaderText = "ID �����";
                dataGridViewBooks.Columns["BookID"].ReadOnly = true;
            }

            if (dataGridViewBooks.Columns.Contains("Title"))
            {
                dataGridViewBooks.Columns["Title"].Visible = true;
                dataGridViewBooks.Columns["Title"].HeaderText = "�������� �����";
            }

            if (dataGridViewBooks.Columns.Contains("YearPublished"))
            {
                dataGridViewBooks.Columns["YearPublished"].Visible = true;
                dataGridViewBooks.Columns["YearPublished"].HeaderText = "��� �������";
            }

            if (dataGridViewBooks.Columns.Contains("Price"))
            {
                dataGridViewBooks.Columns["Price"].Visible = true;
                dataGridViewBooks.Columns["Price"].HeaderText = "����";
                dataGridViewBooks.Columns["Price"].DefaultCellStyle.Format = "N2";
            }


            if (dataGridViewBooks.Columns.Contains("AuthorID"))
            {
                dataGridViewBooks.Columns["AuthorID"].Visible = false;
            }

            if (dataGridViewBooks.Columns.Contains("AuthorName"))
            {
                dataGridViewBooks.Columns["AuthorName"].Visible = false;
            }
        }

       
        private void SetupAuthorComboBoxColumn()
        {
          
            DataGridViewComboBoxColumn authorColumn = new DataGridViewComboBoxColumn();
            authorColumn.HeaderText = "�����";
            authorColumn.DataPropertyName = "AuthorID"; 
            authorColumn.Name = "AuthorColumn";
            authorColumn.DisplayMember = "Name";
            authorColumn.ValueMember = "AuthorID";
            authorColumn.Width = 150;

            
            authorColumn.DataSource = dbService.GetAuthorsForComboBox();

            
            dataGridViewBooks.Columns.Add(authorColumn);
        }


        private void LoadCountries()
        {
            try
            {
                var countries = dbService.GetAllCountries();
                comboCountries.DataSource = countries;

                if (countries.Count > 0)
                {
                    comboCountries.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("� ���� ��� ������ � ������� �������");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� �����: {ex.Message}");
            }
        }

        private void dataGridViewAuthors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable authorsTable = authorsDataSet.Tables[0];
                DataRow newRow = authorsTable.NewRow();


                authorsTable.Rows.Add(newRow);


                dataGridViewAuthors.CurrentCell = dataGridViewAuthors.Rows[dataGridViewAuthors.Rows.Count - 1].Cells[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� ������: {ex.Message}");
            }
        }

        private void btnDeleteAuthors_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthors.CurrentRow == null)
            {
                MessageBox.Show("�������� ������ ��� ��������");
                return;
            }

            try
            {
                int authorId = Convert.ToInt32(dataGridViewAuthors.CurrentRow.Cells["AuthorID"].Value);
                string authorName = dataGridViewAuthors.CurrentRow.Cells["Name"].Value?.ToString() ?? "�����������";

                DialogResult result = MessageBox.Show(
                    $"�� �������, ��� ������ ������� ������ '{authorName}'?",
                    "������������� ��������",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dbService.DeleteAuthor(authorId);
                    LoadAuthorsData(); 
                    MessageBox.Show("����� ������� ������");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ������: {ex.Message}");
            }
        }

        private void btnSaveAuthor_Click(object sender, EventArgs e)
        {
            try
            {
               
                foreach (DataRow row in authorsDataSet.Tables[0].Rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        if (string.IsNullOrEmpty(row["Name"]?.ToString()))
                        {
                            MessageBox.Show("��� ������ �� ����� ���� ������!");
                            return;
                        }
                    }
                }

                dbService.SaveAuthorsChanges(authorsDataSet);
                MessageBox.Show("��������� ������� ���������");

               
                LoadAuthorsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ����������: {ex.Message}");
            }
        }


        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable booksTable = booksDataSet.Tables[0];
                DataRow newRow = booksTable.NewRow();

                // ������������� �������� �� ���������
                newRow["YearPublished"] = DateTime.Now.Year;
                newRow["Price"] = 0;

                booksTable.Rows.Add(newRow);
                dataGridViewBooks.CurrentCell = dataGridViewBooks.Rows[dataGridViewBooks.Rows.Count - 1].Cells[1];
                dataGridViewBooks.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� �����: {ex.Message}");
            }
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("�������� ����� ��� ��������");
                return;
            }

            try
            {
                int bookId = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["BookID"].Value);
                string bookTitle = dataGridViewBooks.CurrentRow.Cells["Title"].Value?.ToString() ?? "�����������";

                DialogResult result = MessageBox.Show(
                    $"�� �������, ��� ������ ������� ����� '{bookTitle}'?",
                    "������������� ��������",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dbService.DeleteBook(bookId);
                    dataGridViewBooks.Rows.RemoveAt(dataGridViewBooks.CurrentRow.Index);
                    MessageBox.Show("����� ������� �������");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� �����: {ex.Message}");
            }
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
               
                foreach (DataRow row in booksDataSet.Tables[0].Rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        if (string.IsNullOrEmpty(row["Title"]?.ToString()))
                        {
                            MessageBox.Show("�������� ����� �� ����� ���� ������!");
                            return;
                        }

                        if (row["AuthorID"] == DBNull.Value || Convert.ToInt32(row["AuthorID"]) == 0)
                        {
                            MessageBox.Show("���������� ������� ������!");
                            return;
                        }
                    }
                }

                dbService.SaveBooksChanges(booksDataSet);
                MessageBox.Show("��������� � ������ ������� ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� ����: {ex.Message}");
            }
        }


        private void btnShowBooks_Click(object sender, EventArgs e)
        {
            if (comboCountries.SelectedItem == null)
            {
                MessageBox.Show("�������� ������");
                return;
            }

            try
            {
                string selectedCountry = comboCountries.SelectedItem.ToString();

               
                DataTable result = dbService.GetBooksByAuthorCountry(selectedCountry);

               
                dataGridViewQueryResults.DataSource = result;

               
                dataGridViewQueryResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewQueryResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

               
                MessageBox.Show($"������� {result.Rows.Count} ���� ������� �� {selectedCountry}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� �������: {ex.Message}");
            }
        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            if (comboPriceRange.SelectedItem == null || comboYearRange.SelectedItem == null)
            {
                MessageBox.Show("�������� ������� �������� � ��� �������");
                return;
            }

            try
            {
                
                string priceRange = comboPriceRange.SelectedItem.ToString();
                decimal minPrice = 0, maxPrice = 0;

                if (priceRange.Contains("+"))
                {
                    minPrice = decimal.Parse(priceRange.Replace(" ���.", "").Replace("+", ""));
                    maxPrice = 100000; 
                }
                else
                {
                    string[] prices = priceRange.Replace(" ���.", "").Split('-');
                    minPrice = decimal.Parse(prices[0]);
                    maxPrice = decimal.Parse(prices[1]);
                }

            
                string yearRange = comboYearRange.SelectedItem.ToString();
                string[] years = yearRange.Split('-');
                int startYear = int.Parse(years[0]);
                int endYear = int.Parse(years[1]);

                // ����������� ������ ����� dataset
                DataTable result = dbService.GetBooksByPriceAndYear(minPrice, maxPrice, startYear, endYear);

               
                if (result.Columns.Count >= 5)
                {
                    result.Columns["book_title"].ColumnName = "�������� �����";
                    result.Columns["author_name"].ColumnName = "�����";
                    result.Columns["author_country"].ColumnName = "������ ������";
                    result.Columns["book_price"].ColumnName = "����";
                    result.Columns["book_year"].ColumnName = "��� �������";
                }

                
                dataGridViewProcedureResults.DataSource = result;

               
                dataGridViewProcedureResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewProcedureResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (dataGridViewProcedureResults.Columns.Contains("����"))
                {
                    dataGridViewProcedureResults.Columns["����"].DefaultCellStyle.Format = "N2";
                    dataGridViewProcedureResults.Columns["����"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

              
                MessageBox.Show($"������� {result.Rows.Count} ���� �� ��������� ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� �������: {ex.Message}");
            }
        }
    }
}
