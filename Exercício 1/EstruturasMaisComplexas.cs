using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercício_1
{
    class EstruturasMaisComplexas
    {

        struct Jogador
        {
            public string nome;
            public int posicao_jogou;
            public Jogada[] jogadas;

        }

        struct Jogada
        {
            public int tempo;
            public int valor;
        }

        public static void Main(string[] args)
        {
            //TODO: SOLVED perguntar quantos jogadores vão jogar (>=1), e quantas rodadas(>=1)
            int qtd_jogadores = 2;
            int qtd_rodadas = 1;

            Dictionary<string, Jogador> jogadoresjogadas = ExemploMultiJogadorEstruturado(qtd_jogadores, qtd_rodadas);

            Console.WriteLine("-------------------FINAL DA PARTIDA:-----------------");

            //ordena os nomes em ordem alfabetica
            string[] nomes = new string[qtd_jogadores];
            jogadoresjogadas.Keys.CopyTo(nomes,0);
            nomes = Recursividade.ArrayOrdenado(nomes);

            foreach(string nome in nomes)
            {
                Jogador j = jogadoresjogadas[nome];
                Console.WriteLine("{1}) Jogador: {0}", nome, j.posicao_jogou);

                Jogada[] jogadas = j.jogadas;
                //TODO: exibir em loop os resultados do jogador


            }

        }


        static Dictionary<string, Jogador> ExemploMultiJogadorEstruturado(int qtdJ, int qtdR)
        {

            Dictionary<string, Jogador> jogadores = new Dictionary<string, Jogador>();

            for (int J = 1; J <= qtdJ; J++)
            {
                //pedir o nome do jogador através de uma função: lembrando que o nome não pode se repetir
                string[] nomes_jogadores = jogadores.Keys.Select(k => k).ToArray(); //depois explico
                string nome_digitado = ObterNomeJogador(nomes_jogadores);

                Jogador jogador = new Jogador();
                jogador.nome = nome_digitado;
                jogador.jogadas = new Jogada[qtdR];
                jogador.posicao_jogou = J;

                jogadores[nome_digitado] = jogador;

                for (int R = 1; R <= qtdR; R++)
                {
                    Console.WriteLine("{0}: jogue a {1}a rodada:", nome_digitado, R);

                    //TODO: fazer a lógica da rodada dentro de uma função. A função retornará um struct "Jogada" preenchido 
                    Jogada jog = new Jogada();

                    jogadores[nome_digitado].jogadas[R - 1] = jog;

                    //HISTÓRICO: FÓRMULA PARA INDEXAR EM UM ARRAY ÚNICO DADOS DE UMA MATRIZ ==>  int i = (J - 1) * qtdR + R - 1; //quantidade de jogadores de antes * qtd de rodas + rodada em que estou

                }
            }

            return jogadores;

        }

        private static string ObterNomeJogador(string[] nomes_ja_usados)
        {
            string nome;
            do
            {
                Console.WriteLine("Digite o nome do jogador (não repetir, não digitar só espaço):");
                nome = Console.ReadLine();
            } while (nome.Trim() == "" || ExisteNoArray(nome, nomes_ja_usados));

            return nome;
        }

        static bool ExisteNoArray(string valor, string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].ToUpper() == valor.ToUpper())
                    return true;
            }

            return false;
        }

        //HISTÓRICO: MULTIJOGADOR COM UM SÓ ARRAY, OU COM MATRIZ
        static void MultiJogadorAntigo()
        {
            int qtdJ = 3;
            int qtdR = 3;

            string[] nomesJ = new string[qtdJ];
            int[] resultadoMedio = new int[qtdJ];

            int[,] todasrodadas = new int[qtdJ, qtdR];

            for (int J = 1; J <= qtdJ; J++)
            {
                for (int R = 1; R <= qtdR; R++)
                {
                    //jogador acertou
                    int tempoAcerto = 455345;

                    //int i = (J - 1) * qtdR + R - 1; //quantidade de jogadores de antes * qtd de rodas + rodada em que estou
                    todasrodadas[J - 1, R - 1] = tempoAcerto;
                }
            }



        }


    }
}
