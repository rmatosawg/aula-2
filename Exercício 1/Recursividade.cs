using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exercício_1
{
    class Recursividade
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                //teste de ordem alfabetica
                Console.WriteLine("Informe o caminho de um arquivo de nomes:");
                string arquivo = Console.ReadLine();

                if (arquivo.ToUpper() == "EXIT")
                    break;
                else if (!File.Exists(arquivo))
                    Console.WriteLine("arquivo nao existe.");
                else
                {
                    string[] nomes = File.ReadAllLines(arquivo);
                    //remover os espaços em branco
                    nomes = nomes.Where(n => n.Trim() != "").ToArray();

                    string[] nomesordenados = ArrayOrdenado(nomes);

                    Console.WriteLine("Nomes ordenados:");
                    nomesordenados.ToList().ForEach(n => Console.WriteLine(n));
                    Console.WriteLine("FIM.");

                }
            }
        }



        public static string[] ArrayOrdenado(string[] origem)
        {
            //TODO: ordenar um array de nomes

            return origem;
        }

    }
}
