using System;

namespace Exercício_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //variáveis
            int VJ;
            int VC;
            string OD;
            var A = new Random();
            double TT = 0;

            int Rslt = 0;


            Console.WriteLine("Bem vindo ao jogo! A menor pontuação vence.");

            //loop de rodadas

            for (int R = 0; R < 3; R = R + 1)
            {
                //input do jogador
                Console.WriteLine("Vamos jogar uma rodada");

                bool Conversivel;
                Console.WriteLine("Digite um número");
                string numero_s = Console.ReadLine();

                if (numero_s == "EXIT")
                {
                    break;
                }

                Conversivel = TentaConverter(numero_s, out VJ);


                //loop de erro
                while (Conversivel == false || VJ > 50)
                {
                    VJ = 0;
                    Conversivel = true;
                    Console.WriteLine("Você não digitou um número ou ele é maior que 50. Tente de novo");
                    Conversivel = int.TryParse(Console.ReadLine(), out VJ);
                }

                //vez do computador e input de operação
                Console.WriteLine("O Computador vai gerar um número.");
                VC = A.Next(1, 11);

                string[] valores_validos = { "A", "S", "M", "CANCEL" };

                OD = ValorDigitadoTratado("Digite A para adição e S para subtração M para multiplicação (ou CANCEL)",
                                          "Você não digitou algo válido. Tente novamente. A para + e S para -",
                                          valores_validos);

                //seleção de operação
                switch (OD)
                {
                    case "A":
                        Console.WriteLine("Você escolheu adição.");
                        Rslt = VJ + VC;
                        break;
                    case "S":
                        Console.WriteLine("Você escolheu subtração.");
                        Rslt = VJ - VC;
                        break;
                    case "M":
                        Console.WriteLine("Você escolheu multiplicação.");
                        Rslt = VJ * VC;
                        break;
                    default:
                        Console.WriteLine("não resolvi.");
                        break;
                }


                //resultado e input do palpite
                Console.WriteLine("O resultado da operação foi: " + Rslt);
           
                DateTime antes = DateTime.Now;

                string[] valor_valido = { VC.ToString() };
                string valor_certo = ValorDigitadoTratado("Tente acertar o número gerado pelo computador.",
                                                          "Você errou ou não digitou um número. Tente novamente.",
                                                          valor_valido);

                //sucesso
                Console.WriteLine("Você acertou!");
                TT = TT + (int)DateTime.Now.Subtract(antes).TotalMilliseconds;

            }

            //fim de jogo
            TT = TT / 1000;
            Console.WriteLine("O jogo acabou! Sua pontuação foi: " + TT + "segundos");

        }

        static int f(int x)
        {
            return x + 1;
        }

        static string ValorDigitadoTratado(string mensagem, 
                                           string mensagem_erro, 
                                           string[] possiveis_valores)
        {
            Console.WriteLine(mensagem);
            string dado;
            bool achou = false;
            do
            {
                dado = Console.ReadLine();
                for(int i = 0; i < possiveis_valores.Length; i++)
                {
                    if (possiveis_valores[i] == dado)
                    {
                        achou = true;
                        break;
                    }
                }

                if (!achou)
                    Console.WriteLine(mensagem_erro);

            } while (!achou);
            possiveis_valores[0] = "x";

            return dado;
        }

        static bool TentaConverter(string s, out int cuspido)
        {
            cuspido = 0;
            char[] caracs = s.ToCharArray();

            for (int i = caracs.Length - 1; i >= 0; i--)
                if (caracs[i] < '0' || caracs[i] > '9')
                    return false;
                else
                    cuspido = cuspido + (int)(caracs[i] - '0') * (int)Math.Pow(10, caracs.Length - i - 1);

            return true;
        }
    }
}
