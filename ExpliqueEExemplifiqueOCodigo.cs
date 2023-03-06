using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicacaoJoseVinicius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso das funções da classe String em C#

            string s = "hello world";

            // Length: Retorna o número de caracteres em uma string.
            Console.WriteLine(s.Length); // Saída: 11

            // ToCharArray: Retorna um array de caracteres representando a string.
            char[] chars = s.ToCharArray();
            Console.WriteLine(chars[0]); // Saída: h

            // Trim: Remove os espaços em branco no início e no final da string.
            string trimmed = s.Trim();
            Console.WriteLine(trimmed); // Saída: "hello world"

            // Substring: Retorna uma substring da string original.
            string substring = s.Substring(2, 3);
            Console.WriteLine(substring); // Saída: llo

            // Split: Divide a string em substrings com base em um separador especificado.
            string[] substrings = s.Split(' ');
            Console.WriteLine(substrings[0]); // Saída: hello

            // Contains: Retorna um valor booleano indicando se uma substring está contida na string original.
            bool contains = s.Contains("world");
            Console.WriteLine(contains); // Saída: true

            // EndsWith: Retorna um valor booleano indicando se a string termina com a substring especificada.
            bool endsWith = s.EndsWith("world");
            Console.WriteLine(endsWith); // Saída: true

            // Equals: Retorna um valor booleano indicando se duas strings são iguais.
            bool equals = s.Equals("Hello world");
            Console.WriteLine(equals); // Saída: false

            // GetType: Retorna o tipo de objeto da string.
            Type type = s.GetType();
            Console.WriteLine(type.FullName); // Saída: System.String

            // IndexOf: Retorna o índice da primeira ocorrência de uma substring na string original.
            int index = s.IndexOf("world");
            Console.WriteLine(index); // Saída: 6

            // Empty: Representa uma string vazia.
            string empty = string.Empty;
            Console.WriteLine(empty); // Saída: ""

            // Insert: Insere uma substring em uma posição especificada na string original.
            string inserted = s.Insert(5, "there ");
            Console.WriteLine(inserted); // Saída: hello there world

            // LastIndexOf: Retorna o índice da última ocorrência de uma substring na string original.
            int lastIndex = s.LastIndexOf("o");
            Console.WriteLine(lastIndex); // Saída: 7

            // Remove: Remove uma substring da string original.
            string removed = s.Remove(5, 6);
            Console.WriteLine(removed); // Saída: hello

            // Replace: Substitui todas as ocorrências de uma substring por outra substring na string original.
            string replaced = s.Replace("world", "C#");
            Console.WriteLine(replaced); // Saída: hello C#

            // StartsWith: Retorna um valor booleano indicando se a string começa com a substring especificada.
            bool startsWith = s.StartsWith("hello");
            Console.WriteLine(startsWith); // Saída: true

            // ToLower: Retorna a string em letras minúsculas.
            string lower = s.ToLower();
            Console.WriteLine(lower); // Saída: hello world

            // ToUpper: Retorna a string em letras maiúsculas.
            string upper = s.ToUpper();
            Console.WriteLine(upper); // Saída: HELLO WORLD

            // ToString: Transforma em ToString
            string str = s.ToString();
            Console.WriteLine(str); // Saída: hello world

            DateTime dt = DateTime.Now;
            string dateStr = dt.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(dateStr); // Exemplo de saída: 06/03/2023 16:30:25

            int number = 123456;
            string numberStr = number.ToString("N3");
            Console.WriteLine(numberStr); // Exemplo de saída: 123.456,000
        }
    }
}
