using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lista5
{
    internal class Program
    {
        static void exercicio1()
        {
            DateTime today = DateTime.Today;
            string dayOfWeek = today.ToString("dddd");
            string month = today.ToString("MMMM");
            int day = today.Day;
            int year = today.Year;
            
            var date = DateTime.Now;

            Console.WriteLine("Qual o seu nome? :)");
            var usuario = Console.ReadLine();

            if(date.Hour >= 6 && date.Hour <= 12)
            {
                Console.WriteLine($"Bom dia! {usuario}");
            } else if (date.Hour >= 12 && date.Hour <= 18)
            {
                Console.WriteLine($"Boa tarde! {usuario}");
            }
            else
            {
                Console.WriteLine($"Boa noite! {usuario}");
            }

            var maquinaNome = Environment.MachineName;
            Console.WriteLine($"Você está utilizando a máquina {maquinaNome}");
            Console.WriteLine("Hoje é {0}, {1} de {2} de {3}", dayOfWeek, day, month, year);
            Console.ReadKey();
        }

        static void exercicio2()
        {
            var numeroSujo = "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040.0965918;9309297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;4941711%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%4312072.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%5294927%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#4990786.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305,1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#6603120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.5810497.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#9239331%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756.1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484922;4599156,5815576%3414149.1343440#16129";

            char[] delimiterChars = { '%', ',', '.', ';', ':', '#', '|' };
            string[] groups = numeroSujo.Split(delimiterChars);

            List<int> numbers = new List<int>();
            foreach (string group in groups)
            {
                int num;
                if (int.TryParse(group, out num))
                {
                    numbers.Add(num);
                }
            }

            int maxProduct = 0;
            int[] maxProductNumbers = new int[5];

            for (int i = 0; i < numbers.Count - 4; i++)
            {
                int product = numbers[i] * numbers[i + 1] * numbers[i + 2] * numbers[i + 3] * numbers[i + 4];
                if (product > maxProduct)
                {
                    maxProduct = product;
                    maxProductNumbers = new int[] { numbers[i], numbers[i + 1], numbers[i + 2], numbers[i + 3], numbers[i + 4] };
                }
            }

            Console.Write("Os cinco números consecutivos que retornam o maior produto são: ");
            foreach (int num in maxProductNumbers)
            {
                Console.Write(num + " ");
            }

            Console.ReadKey();

        }

        static void exercicio3()
        {
            string inputString = "0110111101111011101111000";
            List<string> substrings = new List<string>();

            for (int i = 0; i < inputString.Length - 1; i++)
            {
                if (inputString.Substring(i, 2) == "11")
                {
                    string substring = inputString.Substring(0, i + 2);
                    substrings.Add(substring);

                    int sum = 0;
                    for (int j = 0; j < substring.Length; j++)
                    {
                        sum += int.Parse(substring[j].ToString());
                    }
                    Console.WriteLine(substring + " " + sum);
                }
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Escolha um exercício:");
                Console.WriteLine("1 - Exercício 1");
                Console.WriteLine("2 - Exercício 2");
                Console.WriteLine("3 - Exercício 3");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        exercicio1();
                        break;
                    case 2:
                        exercicio2();
                        break;
                    case 3:
                        exercicio3();
                        break;
                    case 0:
                        // Sair do programa
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
