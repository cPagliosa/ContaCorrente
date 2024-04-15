using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Conta
    {
        private string nome;
        private string senha;
        private string cpf;
        private decimal saldo;
        private decimal limite;
        private int numero;
        private bool especial;
        private LinkedList<Extrato> extrato;

        



        //gets e sets
        public string NomePrimeiro { get => nome; set => nome = value; }
        public string NomeUltimo { get => senha; set => senha = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }
        public decimal Limite { get => limite; set => limite = value; }
        public int Numero { get => numero; set => numero = value; }
        public bool Especial { get => especial; set => especial = value; }
        internal LinkedList<Extrato> Extrato { get => extrato; set => extrato = value; }


        #region contrutores
        public Conta(string nome, string senha, string cpf, decimal saldo, decimal limite, int numero, bool especial, LinkedList<Extrato> extrato)
        {
            this.nome = nome;
            this.senha = senha;
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

            Console.Write("\nInforme o nome completo do titular: ");
            string nome = Console.ReadLine();

            Console.Write("\nInforme senha: ");
            string senha = Console.ReadLine();

            Console.Write("Informe o cpf: ");
            string cpf = Console.ReadLine();

            Conta conta = new Conta(nome, senha, cpf, 0, 0, lista.Count+1, false, new LinkedList<Extrato>());

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
                Console.Write("enter para continuar");
                Console.ReadLine();
            }
            
            
        }

        private bool PossivelMovimentacao(decimal valor)
        {
            if ((this.saldo - valor) > 0) return true;
            else return false;
        }

        public void MostrarContas(LinkedList<Conta> lista)
        {
            foreach (Conta conta in lista)
            {              
                Console.WriteLine($"\nTitular da conta: {conta.nome}\nNumero da conta: {conta.Numero}");
            }
        }

        public void Trasferencia(Conta origem,Conta destino,int numeroDestino,decimal valor)
        {
            if(numeroDestino == destino.numero)
            {
                if (PossivelMovimentacao(valor))
                {
                    destino.Saldo += valor;
                    origem.Saldo -= valor;
                }
                else
                {
                    Console.WriteLine("Saldo Insuficiente!!");
                    Console.Write("enter para continuar");
                    Console.ReadLine();
                }
            }
        }
    }
}
