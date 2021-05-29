using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Matriz<IPonto>
        where IPonto : IPontoDeMatriz
    {

        List<List<IPonto>> Conteudo = new List<List<IPonto>>();


        public void Set(int coluna, int linha, IPonto ponto)
        {
            if (coluna >= Conteudo.Count)
                Conteudo.AddRange(new List<IPonto>[coluna - Conteudo.Count + 1]);

            if (linha >= Conteudo[coluna].Count)
                Conteudo[coluna].AddRange(new IPonto[linha - Conteudo[coluna].Count + 1]);

            Conteudo[coluna][linha] = ponto;
        }

        public IPonto Get(int coluna, int linha)
        {
            if (Conteudo.Count <= coluna || Conteudo[coluna]?.Count <= linha)
                return default;

            return Conteudo[coluna][linha];
        }

        public int QtdColunas
        {
            get
            {
                return Conteudo.Count;
            }
        }

        public int QtdLinhas(int coluna)
        {
            if (coluna >= Conteudo.Count)
                return 0;

         

            return Conteudo[coluna].Count;
        }

        public int QtdMaxLinhas
        {
            get
            {
                return Conteudo.Select(l => l.Count).Max();
            }
        }

        public List<IPonto> DadosdaColuna(int coluna)
        {
            if (coluna >= Conteudo.Count)
                return null;

            return Conteudo[coluna];
        }

        public List<IPonto> DadosdaLinha(int linha)
        {
            var ret = new List<IPonto>();

            foreach(var coluna in Conteudo)
            {
                if (coluna.Count >= linha)
                    ret.Add(default);
                else
                    ret.Add(coluna[linha]);

            }
            return ret;
        }


    }
}
