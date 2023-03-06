using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("Escolha um exercício: ");
                Console.WriteLine("1. Menor, maior e média de um vetor");
                Console.WriteLine("2. Números maiores ou iguais à média de um vetor");
                Console.WriteLine("3. Números aleatórios maiores ou iguais à média de um vetor");
                Console.WriteLine("4. Jogo da velha");
                Console.WriteLine("0. Sair");
                Console.Write("Opção escolhida: ");

                opcao = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Exercicio1();
                        break;

                    case 2:
                        Exercicio2();
                        break;

                    case 3:
                        Exercicio3();
                        break;

                    case 4:
                        Exercicio4();
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();

            } while (opcao != 0);
        }

        static void Exercicio1()
        {
            Console.Write("Digite o tamanho do vetor: ");
            int n = int.Parse(Console.ReadLine());

            float[] vetor = new float[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Digite o {0}º número: ", i + 1);
                vetor[i] = float.Parse(Console.ReadLine());
            }

            float menor = vetor[0];
            float maior = vetor[0];
            float soma = 0;

            for (int i = 0; i < n; i++)
            {
                if (vetor[i] < menor)
                {
                    menor = vetor[i];
                }

                if (vetor[i] > maior)
                {
                    maior = vetor[i];
                }

                soma += vetor[i];
            }

            float media = soma / n;

            Console.WriteLine("Menor número: {0}", menor);
            Console.WriteLine("Maior número: {0}", maior);
            Console.WriteLine("Média aritmética: {0}", media);
        }

        static void Exercicio2()
        {
            Console.Write("Digite o tamanho do vetor: ");
            int n = int.Parse(Console.ReadLine());

            float[] vetor = new float[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Digite o {0}º número: ", i + 1);
                vetor[i] = float.Parse(Console.ReadLine());
            }

            float soma = 0;

            for (int i = 0; i < n; i++)
            {
                soma += vetor[i];
            }

            float media = soma / n;

            Console.Write("Números maiores ou iguais à média: ");

            for (int i = 0; i < n; i++)
            {
                if (vetor[i] >= media)
                {
                    Console.Write("{0} ", vetor[i]);
                }
            }
        }

        static void Exercicio3()
        {
            Random random = new Random();

            Console.Write("Digite o tamanho do vetor: ");
            int n = int.Parse(Console.ReadLine());

            float[] vetor = new float[n];

            for (int i = 0; i < n; i++)
            {
                vetor[i] = (float)random.NextDouble() * 100;
                Console.WriteLine("{0}º número gerado: {1}", i + 1, vetor[i]);
            }

            float soma = 0;

            for (int i = 0; i < n; i++)
            {
                soma += vetor[i];
            }

            float media = soma / n;

            Console.Write("Números gerados maiores ou iguais à média: ");

            for (int i = 0; i < n; i++)
            {
                if (vetor[i] >= media)
                {
                    Console.Write("{0} ", vetor[i]);
                }
            }
        }

        static void Exercicio4()
        {
            char[,] jogo = new char[3, 3];
            bool jogoAcabou = false;

            Console.WriteLine("Jogo da Velha");

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    jogo[linha, coluna] = '-';
                }
            }

            do
            {
                Console.Clear();
                ImprimirTabuleiro(jogo);

                Console.Write("Jogador 1 (X), digite a linha e a coluna da sua jogada (ex: 1 2): ");
                string[] jogada1 = Console.ReadLine().Split(' ');
                int linha1 = int.Parse(jogada1[0]) - 1;
                int coluna1 = int.Parse(jogada1[1]) - 1;

                jogo[linha1, coluna1] = 'X';

                if (VerificarVitoria(jogo, 'X'))
                {
                    Console.Clear();
                    ImprimirTabuleiro(jogo);
                    Console.WriteLine("Jogador 1 (X) venceu!");
                    jogoAcabou = true;
                    break;
                }

                Console.Clear();
                ImprimirTabuleiro(jogo);

                Console.Write("Jogador 2 (O), digite a linha e a coluna da sua jogada (ex: 2 3): ");
                string[] jogada2 = Console.ReadLine().Split(' ');
                int linha2 = int.Parse(jogada2[0]) - 1;
                int coluna2 = int.Parse(jogada2[1]) - 1;

                jogo[linha2, coluna2] = 'O';

                if (VerificarVitoria(jogo, 'O'))
                {
                    Console.Clear();
                    ImprimirTabuleiro(jogo);
                    Console.WriteLine("Jogador 2 (O) venceu!");
                    jogoAcabou = true;
                    break;
                }

            } while (!jogoAcabou);

            Console.WriteLine("Fim de jogo!");
        }

        static void ImprimirTabuleiro(char[,] jogo)
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write("{0} ", jogo[linha, coluna]);
                }

                Console.WriteLine();
            }
        }

        static bool VerificarVitoria(char[,] jogo, char jogador)
        {

            for (int linha = 0; linha < 3; linha++)
            {
                if (jogo[linha, 0] == jogador && jogo[linha, 1] == jogador && jogo[linha, 2] == jogador)
                {
                    return true;
                }
            }

            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (jogo[0, coluna] == jogador && jogo[1, coluna] == jogador && jogo[2, coluna] == jogador)
                {
                    return true;
                }
            }

            if (jogo[0, 0] == jogador && jogo[1, 1] == jogador && jogo[2, 2] == jogador)
            {
                return true;
            }

            if (jogo[0, 2] == jogador && jogo[1, 1] == jogador && jogo[2, 0] == jogador)
            {
                return true;
            }

            return false;
        }
     }
    }
