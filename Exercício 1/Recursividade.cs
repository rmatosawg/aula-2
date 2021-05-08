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
                Console.WriteLine("\n\n");
                int tamanho = Dev1.ColetaInteiro(4, 1000000);

                int[] aleatorios = new int[tamanho];

                for (int i = 0; i < aleatorios.Length; i++)
                    aleatorios[i] = new Random().Next(1, tamanho);

                DateTime ini = DateTime.Now;
                DateTime fim = DateTime.Now;
                int[] ordenado = new int[tamanho];

                switch (Dev1.ValorDigitadoTratado("\nEscolha o algoritmo: (1) Bubble, (2) Quick, (3) List.Sort", "escolha!!!!", new string[] { "1", "2", "3" }))
                {
                    case "1":
                        ini = DateTime.Now;
                        ordenado = ArrayOrdenado(aleatorios);
                        fim = DateTime.Now;
                        break;
                    case "2":
                        aleatorios.CopyTo(ordenado, 0);
                        ini = DateTime.Now;
                        QuickSort(ordenado, 0, tamanho - 1);
                        fim = DateTime.Now;
                        break;
                    case "3":
                        ini = DateTime.Now;
                        List<int> lista = new List<int>(aleatorios);
                        lista.Sort();
                        ordenado = lista.ToArray();
                        fim = DateTime.Now;
                        break;
                }

                Console.WriteLine("Para ordenar {0} foram consumidos {1} milissegundos", tamanho, (fim.Ticks - ini.Ticks) / TimeSpan.TicksPerMillisecond);

                Console.Write("ALEATORIOS:");
                for (int i = 0; i < Math.Min(100, aleatorios.Length); i++)
                    Console.Write("{0}  ", aleatorios[i]);

                Console.Write("\nORDENADOS:");
                for (int i = 0; i < Math.Min(100, ordenado.Length); i++)
                    Console.Write("{0}  ", ordenado[i]);

                Console.ReadKey();

            }

            return;


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

        public static int[] ArrayOrdenado(int[] origem)
        {
            int[] retorno = new int[origem.Length];
            origem.CopyTo(retorno, 0);

            //ordenar um array de números
            for (int j = 1; j < retorno.Length; j++)
            {
                for (int i = 0; i < retorno.Length - 1; i++)
                {
                    //troca a posicao do array
                    if (retorno[i] > retorno[i + 1])
                    {
                        int temp = retorno[i];
                        retorno[i] = retorno[i + 1];
                        retorno[i + 1] = temp;
                    }
                }
            }

            return retorno;
        }


        private static void QuickSort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

    }
}
