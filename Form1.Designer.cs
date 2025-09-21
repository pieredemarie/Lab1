namespace KLab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Authors = new TabPage();
            btnSaveAuthor = new Button();
            btnDeleteAuthors = new Button();
            btnAddAuthor = new Button();
            dataGridViewAuthors = new DataGridView();
            Books = new TabPage();
            btnSaveBook = new Button();
            BtnDeleteBook = new Button();
            btnAddBook = new Button();
            dataGridViewBooks = new DataGridView();
            SqlQuery = new TabPage();
            dataGridViewQueryResults = new DataGridView();
            groupBox1 = new GroupBox();
            label1 = new Label();
            comboCountries = new ComboBox();
            btnShowBooks = new Button();
            Procedure = new TabPage();
            dataGridViewProcedureResults = new DataGridView();
            groupBox2 = new GroupBox();
            btnShowResults = new Button();
            comboYearRange = new ComboBox();
            comboPriceRange = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            tabControl1.SuspendLayout();
            Authors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).BeginInit();
            Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SqlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueryResults).BeginInit();
            groupBox1.SuspendLayout();
            Procedure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProcedureResults).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Authors);
            tabControl1.Controls.Add(Books);
            tabControl1.Controls.Add(SqlQuery);
            tabControl1.Controls.Add(Procedure);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // Authors
            // 
            Authors.Controls.Add(btnSaveAuthor);
            Authors.Controls.Add(btnDeleteAuthors);
            Authors.Controls.Add(btnAddAuthor);
            Authors.Controls.Add(dataGridViewAuthors);
            Authors.Location = new Point(4, 29);
            Authors.Name = "Authors";
            Authors.Padding = new Padding(3);
            Authors.Size = new Size(792, 417);
            Authors.TabIndex = 1;
            Authors.Text = "Авторы";
            Authors.UseVisualStyleBackColor = true;
            // 
            // btnSaveAuthor
            // 
            btnSaveAuthor.Location = new Point(289, 329);
            btnSaveAuthor.Name = "btnSaveAuthor";
            btnSaveAuthor.Size = new Size(94, 29);
            btnSaveAuthor.TabIndex = 4;
            btnSaveAuthor.Text = "Обновить";
            btnSaveAuthor.UseVisualStyleBackColor = true;
            btnSaveAuthor.Click += btnSaveAuthor_Click;
            // 
            // btnDeleteAuthors
            // 
            btnDeleteAuthors.Location = new Point(175, 329);
            btnDeleteAuthors.Name = "btnDeleteAuthors";
            btnDeleteAuthors.Size = new Size(94, 29);
            btnDeleteAuthors.TabIndex = 3;
            btnDeleteAuthors.Text = "Удалить";
            btnDeleteAuthors.UseVisualStyleBackColor = true;
            btnDeleteAuthors.Click += btnDeleteAuthors_Click;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Location = new Point(64, 329);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(94, 29);
            btnAddAuthor.TabIndex = 1;
            btnAddAuthor.Text = "Добавить";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // dataGridViewAuthors
            // 
            dataGridViewAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAuthors.Location = new Point(3, 3);
            dataGridViewAuthors.Name = "dataGridViewAuthors";
            dataGridViewAuthors.RowHeadersWidth = 51;
            dataGridViewAuthors.Size = new Size(781, 305);
            dataGridViewAuthors.TabIndex = 0;
            dataGridViewAuthors.CellContentClick += dataGridViewAuthors_CellContentClick;
            // 
            // Books
            // 
            Books.Controls.Add(btnSaveBook);
            Books.Controls.Add(BtnDeleteBook);
            Books.Controls.Add(btnAddBook);
            Books.Controls.Add(dataGridViewBooks);
            Books.Location = new Point(4, 29);
            Books.Name = "Books";
            Books.Padding = new Padding(3);
            Books.Size = new Size(792, 417);
            Books.TabIndex = 0;
            Books.Text = "Книги";
            Books.UseVisualStyleBackColor = true;
            // 
            // btnSaveBook
            // 
            btnSaveBook.Location = new Point(244, 345);
            btnSaveBook.Name = "btnSaveBook";
            btnSaveBook.Size = new Size(94, 29);
            btnSaveBook.TabIndex = 3;
            btnSaveBook.Text = "Обновить";
            btnSaveBook.UseVisualStyleBackColor = true;
            btnSaveBook.Click += btnSaveBook_Click;
            // 
            // BtnDeleteBook
            // 
            BtnDeleteBook.Location = new Point(118, 345);
            BtnDeleteBook.Name = "BtnDeleteBook";
            BtnDeleteBook.Size = new Size(94, 29);
            BtnDeleteBook.TabIndex = 2;
            BtnDeleteBook.Text = "Удалить";
            BtnDeleteBook.UseVisualStyleBackColor = true;
            BtnDeleteBook.Click += BtnDeleteBook_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(8, 345);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(94, 29);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Добавить";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(8, 6);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.Size = new Size(640, 314);
            dataGridViewBooks.TabIndex = 0;
            // 
            // SqlQuery
            // 
            SqlQuery.Controls.Add(dataGridViewQueryResults);
            SqlQuery.Controls.Add(groupBox1);
            SqlQuery.Location = new Point(4, 29);
            SqlQuery.Name = "SqlQuery";
            SqlQuery.Size = new Size(792, 417);
            SqlQuery.TabIndex = 2;
            SqlQuery.Text = "Отчет1";
            SqlQuery.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQueryResults
            // 
            dataGridViewQueryResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQueryResults.Location = new Point(8, 94);
            dataGridViewQueryResults.Name = "dataGridViewQueryResults";
            dataGridViewQueryResults.RowHeadersWidth = 51;
            dataGridViewQueryResults.Size = new Size(575, 299);
            dataGridViewQueryResults.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboCountries);
            groupBox1.Controls.Add(btnShowBooks);
            groupBox1.Location = new Point(3, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 69);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 29);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 2;
            label1.Text = "Страна";
            // 
            // comboCountries
            // 
            comboCountries.FormattingEnabled = true;
            comboCountries.Items.AddRange(new object[] { "Россия", "США", "Колумбия", "Великобритания" });
            comboCountries.Location = new Point(116, 27);
            comboCountries.Name = "comboCountries";
            comboCountries.Size = new Size(220, 28);
            comboCountries.TabIndex = 1;
            // 
            // btnShowBooks
            // 
            btnShowBooks.Location = new Point(410, 27);
            btnShowBooks.Name = "btnShowBooks";
            btnShowBooks.Size = new Size(94, 29);
            btnShowBooks.TabIndex = 0;
            btnShowBooks.Text = "Найти";
            btnShowBooks.UseVisualStyleBackColor = true;
            btnShowBooks.Click += btnShowBooks_Click;
            // 
            // Procedure
            // 
            Procedure.Controls.Add(dataGridViewProcedureResults);
            Procedure.Controls.Add(groupBox2);
            Procedure.Location = new Point(4, 29);
            Procedure.Name = "Procedure";
            Procedure.Size = new Size(792, 417);
            Procedure.TabIndex = 3;
            Procedure.Text = "Отчет2";
            Procedure.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProcedureResults
            // 
            dataGridViewProcedureResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProcedureResults.Location = new Point(8, 169);
            dataGridViewProcedureResults.Name = "dataGridViewProcedureResults";
            dataGridViewProcedureResults.RowHeadersWidth = 51;
            dataGridViewProcedureResults.Size = new Size(722, 221);
            dataGridViewProcedureResults.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnShowResults);
            groupBox2.Controls.Add(comboYearRange);
            groupBox2.Controls.Add(comboPriceRange);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(8, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(722, 138);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // btnShowResults
            // 
            btnShowResults.Location = new Point(589, 39);
            btnShowResults.Name = "btnShowResults";
            btnShowResults.Size = new Size(94, 29);
            btnShowResults.TabIndex = 4;
            btnShowResults.Text = "Найти";
            btnShowResults.UseVisualStyleBackColor = true;
            btnShowResults.Click += btnShowResults_Click;
            // 
            // comboYearRange
            // 
            comboYearRange.FormattingEnabled = true;
            comboYearRange.Items.AddRange(new object[] { "2000-2010", "2010-2020", "2020-2025" });
            comboYearRange.Location = new Point(423, 41);
            comboYearRange.Name = "comboYearRange";
            comboYearRange.Size = new Size(151, 28);
            comboYearRange.TabIndex = 3;
            // 
            // comboPriceRange
            // 
            comboPriceRange.FormattingEnabled = true;
            comboPriceRange.Items.AddRange(new object[] { "450-800", "850-1000", "1000-2000", "Больше 2000" });
            comboPriceRange.Location = new Point(166, 39);
            comboPriceRange.Name = "comboPriceRange";
            comboPriceRange.Size = new Size(151, 28);
            comboPriceRange.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(323, 42);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 1;
            label3.Text = "Год выпуска";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 44);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 0;
            label2.Text = "Ценовой диапазон";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Authors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).EndInit();
            Books.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            SqlQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueryResults).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Procedure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProcedureResults).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Authors;
        private TabPage Books;
        private TabPage SqlQuery;
        private TabPage Procedure;
        private Button btnDeleteAuthors;
        private Button btnAddAuthor;
        private DataGridView dataGridViewAuthors;
        private DataGridView dataGridViewBooks;
        private Button btnSaveBook;
        private Button btnDeleteBook;
        private Button BtnDeleteBook;
        private Button btnAddBook;
        private GroupBox groupBox1;
        private ComboBox comboCountries;
        private Button btnShowBooks;
        private Label label1;
        private DataGridView dataGridViewQueryResults;
        private GroupBox groupBox2;
        private Button btnShowResults;
        private ComboBox comboYearRange;
        private ComboBox comboPriceRange;
        private Label label3;
        private Label label2;
        private DataGridView dataGridViewProcedureResults;
        private Button btnSaveAuthor;
    }
}
