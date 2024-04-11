using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Extrato
    {
        private string tipo;
        private decimal valor;
        private string data;

        #region Contrutores
        public Extrato()
        {
        }

        public Extrato(string tipo, decimal valor, string data)
        {
            this.Tipo = tipo;
            this.Valor = valor;
            this.Data = data;
        }


        #endregion

        #region getSet

        public string Tipo { get => tipo; set => tipo = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Data { get => data; set => data = value; }

        #endregion

    }
}

