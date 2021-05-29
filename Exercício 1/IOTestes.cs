using System;
using System.Collections.Generic;
using System.Text;

namespace Exercício_1
{
    class IOTestes
    {
        public static void Main(string[] args)
        {
            var arquivo = @"C:\Users\Rafael\OneDrive\CURSO-DEV-0\Entrega\Exercício 1\Exercício 1\TESTES\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") + ".txt";

            var arqs = System.IO.Directory.GetFiles(@"C:\Users\Rafael\OneDrive\CURSO-DEV-0\Entrega\Exercício 1\Exercício 1\TESTES\", "*.txt");
            if (arqs.Length > 0)
            {
                Console.WriteLine("Aproveitar o último arquivo? S/N");
                var r = Console.ReadKey();

                if (r.Key == ConsoleKey.S)
                {
                    var list = new List<string>(arqs);
                    list.Sort();
                    arquivo = list[list.Count - 1];

                    Console.WriteLine(System.IO.File.ReadAllText(arquivo));
                    Console.WriteLine("CONTINUE ...");
                }
            }

            Console.WriteLine("Escreva o que quiser. Quando parar, escreva EXIT e dê enter");
            do
            {
                var linha = Console.ReadLine();

                System.IO.File.AppendAllText(arquivo, linha + "\n");

                if (linha == "EXIT")
                    break;



            } while (true);

        }
    }
}
