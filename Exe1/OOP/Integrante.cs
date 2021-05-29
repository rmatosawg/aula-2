using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exe1.OOP
{
    public class Integrante : Pessoa
    {
        public Integrante()
        {
            this.Toca = new Instrumento[1];
        }

        public Integrante(string nome)
        {
            this.Toca = new Instrumento[1];
            Nome = nome;

        }
        public Integrante(string nome, Instrumento instr)
        {
            this.Toca = new Instrumento[1];
            Nome = nome;
            Toca[0] = instr;

        }

        public override string SetarCPFCNPJ(string cpfcnpj)
        {
            string ret = base.SetarCPFCNPJ(cpfcnpj);
            if (ret == null)
                return null;

            if (!ValidaCNPJ(ref cpfcnpj))
                return "Inválido";

            this.CPFCNPJ = cpfcnpj;
            return null;
        }

        public string SetarCPFCNPJ(string cpfcnpj, bool ehCPF)
        {
            if (ehCPF)
            {
                string ret = base.SetarCPFCNPJ(cpfcnpj);
                if (ret == null)
                    return null;

                return ret;

            }
            else
            {
                if (!ValidaCNPJ(ref cpfcnpj))
                    return "Inválido";

                this.CPFCNPJ = cpfcnpj;
                return null;

            }
        }



        public int AdicionarInstrumento(Instrumento intr)
        {
            if (this.Toca[0] != null)
                throw new Exception("O integrante já tem instrumento atrinbuído");

            this.Toca[0] = intr;
            return Toca.Length;
        }

        public int TrocarInstrumento(Instrumento intr)
        {

            if (this.Toca[0] == null)
                throw new Exception("O integrante não tem instrumento atribuído");

            this.Toca[0] = intr;
            return Toca.Length;
        }


        public static bool ValidaCNPJ(ref string CNPJ)
        {
            if (CNPJ == null || CNPJ.Trim() == "")
                return false;

            CNPJ = Regex.Replace(CNPJ, @"[^0-9]", "");
            CNPJ = CNPJ.PadLeft(14, '0');

            bool valida;

            if (CNPJ.Length != 14 || !Information.IsNumeric(CNPJ) || CNPJ.StartsWith(new string(CNPJ[1], 8)))
                return false;

            valida = efetivaValidacao(CNPJ);

            if (valida)
                return true;
            else
                return false;
        }


        private static bool efetivaValidacao(string cnpj)
        {
            int[] Numero = new int[14];
            int soma;
            int i;

            int resultado1;
            int resultado2;
            for (i = 0; i <= Numero.Length - 1; i++)
                Numero[i] = Convert.ToInt32(cnpj.Substring(i, 1));
            soma = Numero[0] * 5 + Numero[1] * 4 + Numero[2] * 3 + Numero[3] * 2 + Numero[4] * 9 + Numero[5] * 8 + Numero[6] * 7 + Numero[7] * 6 + Numero[8] * 5 + Numero[9] * 4 + Numero[10] * 3 + Numero[11] * 2;
            soma = soma - (11 * (int)(Conversion.Int(soma / (double)11)));
            if (soma == 0 | soma == 1)
                resultado1 = 0;
            else
                resultado1 = 11 - soma;

            if (resultado1 == Numero[12])
            {
                soma = Numero[0] * 6 + Numero[1] * 5 + Numero[2] * 4 + Numero[3] * 3 + Numero[4] * 2 + Numero[5] * 9 + Numero[6] * 8 + Numero[7] * 7 + Numero[8] * 6 + Numero[9] * 5 + Numero[10] * 4 + Numero[11] * 3 + Numero[12] * 2;
                soma = soma - (11 * (int)(Conversion.Int(soma / (double)11)));
                if (soma == 0 | soma == 1)
                    resultado2 = 0;
                else
                    resultado2 = 11 - soma;
                if (resultado2 == Numero[13])
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override byte[] Tocar()
        {
            return null;

        }
    }
}
