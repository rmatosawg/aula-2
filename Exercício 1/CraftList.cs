using System;
using System.Collections.Generic;
using System.Text;

namespace Exercício_1
{
    class CraftList
    {
        public static void Main(string[] args)
        {
            CraftList lista = new CraftList();
            lista.Adiciona(10);
            lista.Adiciona(200);

            int i = lista.Adiciona(400);

        }


        class nó
        {
            public int valor;
            public int indice;
            public nó proximo;
        }

        nó ElementoRaiz;
        nó Ultimo;

        public int Adiciona(int valor)
        {
            if (ElementoRaiz == null)
            {
                ElementoRaiz = new nó();
                ElementoRaiz.indice = 0;
                ElementoRaiz.valor = valor;
                Ultimo = ElementoRaiz;
            }
            else
            {
                nó Novo = new nó();
                Novo.indice = Ultimo.indice + 1;
                Novo.valor = valor;
                Ultimo.proximo = Novo;
                Ultimo = Novo;
            }

            return Ultimo.indice;
        }

        public void RemoveNaPosicao(int posic)
        {
            nó percorre = ElementoRaiz;
            while (percorre != null && percorre.indice != posic)
                percorre = percorre.proximo;

            //remover o percorre


        }


    }
}
