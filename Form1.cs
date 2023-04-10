using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivrariaCRUD
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();

        private static String caminho = @"C:\Users\cj3014657\Documents\BancoCRUD\livraria.sqlite";
        public Form1()
        {
            InitializeComponent();
        }

        private static SQLiteConnection DbConnection()
        {
            var sqliteConnection = new SQLiteConnection("Data Source=" + caminho + "; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void insertBook(int id, String nome, float valor)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Livros(id, Nome, Valor ) values (@id, @nome, @valor)";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection.CreateFile(caminho);
                MessageBox.Show("Banco em Arquivo criado com sucesso em: " + caminho);
            }
            catch
            {
                throw;
            }

            try
               {
                    using (var cmd = DbConnection().CreateCommand())
                    {
                        cmd.CommandText = "CREATE TABLE Livros(id int, Nome Varchar(50), Valor REAL)";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        public void GetLivros()
        { 
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                List<string> ImportedFiles = new List<string>();
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Livros";
                    SQLiteDataReader read = cmd.ExecuteReader();
                    interfaceTable.Rows.Clear();
                    while (read.Read())
                    {
                        interfaceTable.Rows.Add(new object[] {
                        read.GetValue(0),  // U can use column index
                        read.GetValue(1),  // Or column name like this
                        read.GetValue(2) });
                    }
                   }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao se comunicar com o banco");
            }
        }

        private int getNextId()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select MAX(id) from Livros;";
                    string id = cmd.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        return 1;
                    } else
                    {
                        return int.Parse(id) + 1;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return 1;
                MessageBox.Show("Erro ao achar o próximo ID");
            }
        }

        private void insertBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                int nextId = getNextId();
                insertBook(nextId, nomeBox.Text, float.Parse(valorBox.Text));
            } catch (Exception ex)
            {
                MessageBox.Show("Você inseriu algum dado errado: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetLivros();
        }

        private void deleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Livros WHERE Nome = @nome";
                    cmd.Parameters.AddWithValue("@Id", getNextId());
                    cmd.Parameters.AddWithValue("@Nome", nomeBox.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
