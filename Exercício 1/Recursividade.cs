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
            int[] aleatorios = null;

            while (true)
            {
                bool novo_sorteio = true;
                int tamanho = 0;

                if (aleatorios != null)
                {
                    tamanho = aleatorios.Length;

                    Console.WriteLine("\n\n");
                    novo_sorteio = (Dev1.ValorDigitadoTratado("\nGera novo array ? S ou N", "S ou N!!!!", new string[] { "S", "N" }) == "S");
                }

                if (novo_sorteio)
                {
                    Console.WriteLine("\n\n");
                    tamanho = Dev1.ColetaInteiro(4, 1000000);

                    aleatorios = new int[tamanho];

                    for (int i = 0; i < aleatorios.Length; i++)
                        aleatorios[i] = new Random().Next(1, tamanho * 10);

                }

                DateTime ini = DateTime.Now;
                DateTime fim = DateTime.Now;
                int[] ordenado = new int[tamanho];

                switch (Dev1.ValorDigitadoTratado("\nEscolha o algoritmo: (1) Bubble, (2) Quick, (3) List.Sort (4) Bubble Recursivo", "escolha!!!!", new string[] { "1", "2", "3", "4" }))
                {
                    case "1":
                        var aleatoriosoriginais = new int[aleatorios.Length];
                        aleatorios.CopyTo(aleatoriosoriginais, 0);
                        ini = DateTime.Now;
                        ordenado = ArrayOrdenado(aleatorios);
                        fim = DateTime.Now;
                        aleatorios = new int[aleatorios.Length];
                        aleatoriosoriginais.CopyTo(aleatorios, 0);

                        break;
                    case "2":
                        aleatorios.CopyTo(ordenado, 0);
                        ini = DateTime.Now;
                        QuickSort(ordenado, 0, tamanho - 1);
                        fim = DateTime.Now;
                        break;
                    case "3":

                        List<int> lista = new List<int>(aleatorios);
                        ini = DateTime.Now;
                        lista.Sort();
                        fim = DateTime.Now;
                        ordenado = lista.ToArray();
                        break;

                    case "4":
                        var aleatoriosoriginaisrec = new int[aleatorios.Length];
                        aleatorios.CopyTo(aleatoriosoriginaisrec, 0);
                        ini = DateTime.Now;
                        ordenado = ArrayOrdenadoRecursivo(aleatorios, aleatorios.Length);
                        fim = DateTime.Now;
                        aleatorios = new int[aleatorios.Length];
                        aleatoriosoriginaisrec.CopyTo(aleatorios, 0);

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
            //ordenar um array de números
            for (int j = 1; j < origem.Length; j++)
            {
                for (int i = 0; i < origem.Length - 1; i++)
                {
                    //troca a posicao do array
                    if (origem[i] > origem[i + 1])
                    {
                        int temp = origem[i];
                        origem[i] = origem[i + 1];
                        origem[i + 1] = temp;
                    }
                }
            }

            return origem;
        }

        public static int[] ArrayOrdenadoRecursivo(int[] origem, int j)
        {
            bool trocou = false;

            for (int i = 0; i < j - 1; i++)
            {
                //troca a posicao do array
                if (origem[i] > origem[i + 1])
                {
                    trocou = true;
                    int temp = origem[i];
                    origem[i] = origem[i + 1];
                    origem[i + 1] = temp;
                }
            }

            if (j > 1 && trocou)
                origem = ArrayOrdenadoRecursivo(origem, j - 1);

            return origem;
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
