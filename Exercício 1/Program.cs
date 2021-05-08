using System;
using System.Collections.Generic;

namespace Exercício_1
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("MENU INICIAL:");
                Console.WriteLine("1) primeiro programa de aula");
                Console.WriteLine("2) estruturas mais complexas");
                Console.WriteLine("3) recursividade");
                Console.WriteLine("---------");
                Console.WriteLine("esc) Sair");

                ConsoleKeyInfo key = Console.ReadKey();

                Console.WriteLine("SEGUINDO ...");

                bool opcao_reconhecida = true;

                if (key.Key == ConsoleKey.Escape)
                    break;

                switch (key.KeyChar)
                {
                    case '1':
                        Dev1.Main(args);
                        break;

                    case '2':
                        EstruturasMaisComplexas.Main(args);
                        break;
                    case '3':
                        Recursividade.Main(args);
                        break;
                    default:
                        opcao_reconhecida = false;
                        Console.WriteLine("Não existe essa opção.");
                        break;

                }

                if (opcao_reconhecida)
                    Console.Clear();

            }

            Console.WriteLine("FIM DA EXECUÇÃO - PRESSIONE QUALQUER TECLA ... ");
            Console.ReadKey();
        }


    }
}
