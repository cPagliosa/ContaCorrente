using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Conta
    {
        private string nomePrimeiro;
        private string nomeUltimo;
        private string cpf;
        private decimal saldo;
        private decimal limite;
        private int numero;
        private bool especial;
        private LinkedList<Extrato> extrato;

        



        //gets e sets
        public string NomePrimeiro { get => nomePrimeiro; set => nomePrimeiro = value; }
        public string NomeUltimo { get => nomeUltimo; set => nomeUltimo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }
        public decimal Limite { get => limite; set => limite = value; }
        public int Numero { get => numero; set => numero = value; }
        public bool Especial { get => especial; set => especial = value; }
        internal LinkedList<Extrato> Extrato { get => extrato; set => extrato = value; }


        #region contrutores
        public Conta(string nomePrimeiro, string nomeUltimo, string cpf, decimal saldo, decimal limite, int numero, bool especial, LinkedList<Extrato> extrato)
        {
            this.nomePrimeiro = nomePrimeiro;
            this.nomeUltimo = nomeUltimo;
            this.cpf = cpf;
            this.saldo = saldo;
            this.limite = limite;
            this.numero = numero;
            this.especial = especial;
            this.extrato = extrato;
        }

        public Conta() { }
        #endregion


        public Conta CadastroConta(LinkedList<Conta> lista)
        {
            Console.Clear();
            Console.Write("** Cadastrar Conta  **");
            Random ram = new Random();
            Console.Write("\nInforme o primeiro Nome: ");
            string priNome = Console.ReadLine();

            Console.Write("Informe o ultimo Nome(Sobrenome): ");
            string ultNome = Console.ReadLine();

            Console.Write("Informe o cpf: ");
            string cpf = Console.ReadLine();

            Conta conta = new Conta(priNome, ultNome, cpf, 0, 0, ram.Next(1, 1000), false, new LinkedList<Extrato>());

            return conta;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor; 
        }

        public void Retirar(decimal valor)
        {
            if(this.PossivelMovimentacao(valor))
            {
                this.saldo -= valor;
            }else
            {
                Console.WriteLine("Saldo Insuficiente!!");
            }
            
            
        }

        private bool PossivelMovimentacao(decimal valor)
        {
            if ((this.saldo - valor) > 0) return true;
            else return false;
        }
    }
}
