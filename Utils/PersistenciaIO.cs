using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{

    public class PersistenciaIO<T>
    {
        string ArquivoDeTrabalho;

        public PersistenciaIO(string local)
        {
            ArquivoDeTrabalho = local;
        }

        public List<T> LoadArray()
        {
            if (!File.Exists(ArquivoDeTrabalho))
                return new List<T>();
            var conteudoarquivo = File.ReadAllText(ArquivoDeTrabalho);
            var listRet = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(conteudoarquivo);
            return listRet;
        }

        public void SaveArray(List<T> toSave)
        {
            var conteudoserializado = Newtonsoft.Json.JsonConvert.SerializeObject(toSave);
            File.WriteAllText(ArquivoDeTrabalho, conteudoserializado);
        }

    }
}
