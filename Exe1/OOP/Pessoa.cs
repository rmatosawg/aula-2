using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exe1.OOP
{
    public abstract class Pessoa
    {
        public string Nome;
        public string CPFCNPJ;

        //public List<Instrumento> Toca = new List<Instrumento>();
        public Instrumento[] Toca;

        public virtual string SetarCPFCNPJ(string cpfcnpj)
        {
            if (!ValidaCPF(ref cpfcnpj))
                return "Inválido.";

            this.CPFCNPJ = cpfcnpj;
            return null;
        }



        private static bool ValidaCPF(ref string CPF)
        {
            if (CPF == null || CPF.Trim() == "")
                return false;

            CPF = Regex.Replace(CPF, @"[^0-9]", "");
            CPF = CPF.PadLeft(11, '0');

            int i, x, n1, n2;



            if (CPF.Length != 11 || !Information.IsNumeric(CPF) || CPF.StartsWith(new string(CPF[1], 8)))
                return false;

            for (x = 0; x <= 1; x++)
            {
                n1 = 0;
                for (i = 0; i <= 8 + x; i++)
                    n1 = n1 + (int)(Conversion.Val(CPF.Substring(i, 1)) * (10 + x - i));
                n2 = 11 - (n1 - (int)(Conversion.Int(n1 / (double)11) * 11));
                if (n2 == 10 | n2 == 11)
                    n2 = 0;

                if (n2 != Conversion.Val(CPF.Substring(9 + x, 1)))
                    return false;
            }

            return true;
        }

        public abstract byte[] Tocar();

    }
}
