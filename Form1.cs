using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        bool jogador1 = true;
        int jogadas = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private List<Player> players = new List<Player>();
        private string playersFile = "players.txt";
        private bool playAgainstComputer = false;
        private Random random = new Random();

        public class Player
        {
            public string Name { get; set; }
            public string Cpf { get; set; }
            public int Wins { get; set; }
        }

        private void SavePlayers()
        {
            using (StreamWriter sw = new StreamWriter(playersFile))
            {
                foreach (var player in players)
                {
                    sw.WriteLine($"{player.Name},{player.Cpf},{player.Wins}");
                }
            }
        }

        private bool ValidateCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            for (int i = 0; i < 10; i++)
            {
                if (cpf == new string(i.ToString()[0], 11))
                    return false;
            }

            int[] firstMultiplier = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * firstMultiplier[i];

            int result = sum % 11;
            result = result < 2 ? 0 : 11 - result;

            tempCpf += result.ToString();

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * secondMultiplier[i];

            result = sum % 11;
            result = result < 2 ? 0 : 11 - result;

            tempCpf += result.ToString();

            return cpf == tempCpf;
        }

        private void UpdatePlayerWins(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                player.Wins++;

                // Encontre a linha correspondente ao jogador vencedor no DataGridView
                foreach (DataGridViewRow row in dataGridViewRanking.Rows)
                {
                    if (row.Cells["Nome"].Value.ToString() == player.Name)
                    {
                        // Incremente o valor da coluna Wins para esse jogador
                        int currentWins = Convert.ToInt32(row.Cells["Wins"].Value);
                        row.Cells["Wins"].Value = currentWins + 1;
                        break;
                    }
                }

                SavePlayers();
            }
        }

        private void LoadPlayers()
        {
            if (File.Exists(playersFile))
            {
                using (StreamReader sr = new StreamReader(playersFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        players.Add(new Player { Name = data[0], Cpf = data[1], Wins = int.Parse(data[2]) });
                    }
                }
            }
        }

        private void MakeComputerMove()
        {
            List<Button> availableButtons = new List<Button>();

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button && ctrl.Name.StartsWith("button") && ctrl.Text == "")
                {
                    availableButtons.Add((Button)ctrl);
                }
            }

            if (availableButtons.Count > 0)
            {
                int index = random.Next(availableButtons.Count);
                Button btn = availableButtons[index];
                btn.Text = "O";
                btn.ForeColor = Color.Blue;

                jogador1 = !jogador1;
                jogadas++;

                VerificarVitoria();
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "")
            {
                if (jogador1)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Red;
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Blue;
                }

                jogador1 = !jogador1;
                jogadas++;

                VerificarVitoria();

                if (!jogador1 && playAgainstComputer)
                {
                    MakeComputerMove();
                }
            }
        }

        private void VerificarVitoria()
        {
            bool vitoria = false;

            // Verifica linhas
            for (int i = 1; i <= 9; i += 3)
            {
                if (VerificarCelulas(i, i + 1, i + 2))
                {
                    vitoria = true;
                    break;
                }
            }

            // Verifica colunas
            for (int i = 1; i <= 3; i++)
            {
                if (VerificarCelulas(i, i + 3, i + 6))
                {
                    vitoria = true;
                    break;
                }
            }

            // Verifica diagonais
            if (VerificarCelulas(1, 5, 9) || VerificarCelulas(3, 5, 7))
            {
                vitoria = true;
            }

            if (vitoria)
            {
                FinalizarJogo("Vitória!");
                UpdatePlayerWins(nomeBox.Text);
            }
            else if (jogadas == 9)
            {
                FinalizarJogo("Empate!");
            }
        }

        private bool VerificarCelulas(int a, int b, int c)
        {
            Button btn1 = (Button)Controls["button" + a.ToString()];
            Button btn2 = (Button)Controls["button" + b.ToString()];
            Button btn3 = (Button)Controls["button" + c.ToString()];

            if (btn1.Text != "" && btn1.Text == btn2.Text && btn2.Text == btn3.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FinalizarJogo(string mensagem)
        {
            lblStatus.Text = mensagem;
            lblStatus.Visible = true;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button && ctrl.Name.StartsWith("button"))
                {
                    ((Button)ctrl).Enabled = false;
                }
            }
        }
        
        private void BtnNovoJogo_Click_1(object sender, EventArgs e)
        {
            jogador1 = true;
            jogadas = 0;
            lblStatus.Visible = false;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button && ctrl.Name.StartsWith("button"))
                {
                    ((Button)ctrl).Text = "";
                    ((Button)ctrl).ForeColor = Color.Black;
                    ((Button)ctrl).Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button_Click(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            playAgainstComputer = checkBox1.Checked;
        }

        private void exibirRankingButton_Click(object sender, EventArgs e)
        {
            dataGridViewRanking.Rows.Clear();
            var sortedPlayers = players.OrderByDescending(p => p.Wins).Take(10);
            foreach (var player in sortedPlayers)
            {
                dataGridViewRanking.Rows.Add(player.Name, player.Cpf, player.Wins);
            }
        }

        private void cadastrarButton_Click(object sender, EventArgs e)
        {
            string nome = nomeBox.Text;
            string cpf = cpfBox.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || !ValidateCpf(cpf))
            {
                MessageBox.Show("Por favor, insira um nome e um CPF válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                players.Add(new Player { Name = nome, Cpf = cpf, Wins = 0 });
                SavePlayers();
                MessageBox.Show("Jogador cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nomeBox.Clear();
                cpfBox.Clear();
            }
        }

        private void dataGridViewRanking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRanking.CurrentRow != null)
            {
                int selectedRowIndex = dataGridViewRanking.CurrentRow.Index;

                if (selectedRowIndex >= 0)
                {
                    // Obter os detalhes do jogador selecionado
                    string cpf = dataGridViewRanking.Rows[selectedRowIndex].Cells["Cpf"].Value.ToString();
                    string nome = dataGridViewRanking.Rows[selectedRowIndex].Cells["Nome"].Value.ToString();

                    // Preencha os campos apropriados com os detalhes do jogador (por exemplo, txtCpfJogador1)
                    cpfBox.Text = cpf;
                    nomeBox.Text = nome;
                }
            }
        }
    }
}
