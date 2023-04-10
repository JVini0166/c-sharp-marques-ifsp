namespace LivrariaCRUD
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.nomeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valorBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.insertBookButton = new System.Windows.Forms.Button();
            this.interfaceTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.interfaceTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Criar Banco em Arquivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nomeBox
            // 
            this.nomeBox.Location = new System.Drawing.Point(92, 45);
            this.nomeBox.Name = "nomeBox";
            this.nomeBox.Size = new System.Drawing.Size(100, 20);
            this.nomeBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            // 
            // valorBox
            // 
            this.valorBox.Location = new System.Drawing.Point(92, 97);
            this.valorBox.Name = "valorBox";
            this.valorBox.Size = new System.Drawing.Size(100, 20);
            this.valorBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valor";
            // 
            // insertBookButton
            // 
            this.insertBookButton.Location = new System.Drawing.Point(29, 141);
            this.insertBookButton.Name = "insertBookButton";
            this.insertBookButton.Size = new System.Drawing.Size(75, 40);
            this.insertBookButton.TabIndex = 6;
            this.insertBookButton.Text = "Inserir Livro";
            this.insertBookButton.UseVisualStyleBackColor = true;
            this.insertBookButton.Click += new System.EventHandler(this.insertBookButton_Click);
            // 
            // interfaceTable
            // 
            this.interfaceTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.interfaceTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Valor});
            this.interfaceTable.Location = new System.Drawing.Point(225, 45);
            this.interfaceTable.Name = "interfaceTable";
            this.interfaceTable.Size = new System.Drawing.Size(343, 307);
            this.interfaceTable.TabIndex = 7;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 64);
            this.button2.TabIndex = 8;
            this.button2.Text = "Atualizar Tabela com o Banco";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteBook
            // 
            this.deleteBook.Location = new System.Drawing.Point(117, 141);
            this.deleteBook.Name = "deleteBook";
            this.deleteBook.Size = new System.Drawing.Size(75, 40);
            this.deleteBook.TabIndex = 9;
            this.deleteBook.Text = "Deletar Livro por nome";
            this.deleteBook.UseVisualStyleBackColor = true;
            this.deleteBook.Click += new System.EventHandler(this.deleteBook_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 388);
            this.Controls.Add(this.deleteBook);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.interfaceTable);
            this.Controls.Add(this.insertBookButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valorBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomeBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.interfaceTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nomeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button insertBookButton;
        private System.Windows.Forms.DataGridView interfaceTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteBook;
    }
}

