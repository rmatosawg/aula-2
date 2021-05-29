using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public interface IPontoDeMatriz
    {
        int linha { get; set; }
        int coluna { get; set; }

        bool EstaVazio();
        void ocupar(string conteudo);

        Matriz<IPontoDeMatriz> matriz { get; set; }
    }
}
