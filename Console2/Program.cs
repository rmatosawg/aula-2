using Exe1.OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var arquivo = @"C:\Users\Rafael\OneDrive\CURSO-DEV-0\Entrega\Exercício 1\Console2\DADOS\integrantes.txt";
            var integrantes = new List<Integrante>();

            if (System.IO.File.Exists(arquivo))
            {
                var conteudo = System.IO.File.ReadAllText(arquivo);
                integrantes.AddRange( Newtonsoft.Json.JsonConvert.DeserializeObject<Integrante[]>(conteudo));
            }

            while (true)
            {
                Console.WriteLine("1) contratar integrante, 2) listar integrantes, 3) gravar no arquivo");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Write("Nome:");
                    string nome = Console.ReadLine();
                    Console.Write("Instrumento:");
                    var instrumento = Console.ReadLine();

                    var instr = new Instrumento();
                    instr.Nome = instrumento;


                    var integ2 = new Integrante(nome, instr);

                    //var cpf = Console.ReadLine();
                    //var erro = integ2.SetarCPFCNPJ(cpf);


                    //if (erro != null)
                    //    Console.WriteLine(erro);
                    //else
                    integrantes.Add(integ2);
                }
                else if (opcao == "2")
                {
                    for (int i = 0; i < integrantes.Count; i++)
                    {
                        Console.WriteLine(integrantes[i].Nome);
                    }
                }
                else if (opcao == "3")
                {
                    System.IO.File.WriteAllText(arquivo, 
                        Newtonsoft.Json.JsonConvert.SerializeObject(integrantes, Newtonsoft.Json.Formatting.Indented));
                 
                }
            }
        }

    }
}
