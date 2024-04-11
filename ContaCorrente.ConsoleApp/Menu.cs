using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Menu
    {
        private LinkedList<Conta> contas = new LinkedList<Conta>();
        private Conta conta;

        //contrutor
        public Menu() { }
        public void MostrarMenuIniciar()
        {
            while (true) 
            {
                Console.Clear();
                Console.Write("** Menu do Banco AP **\n0. Sair\n1. Cadastrar\n2. Logar\n");
                Console.Write("Informe qual opicao quer: ");
                int id = Convert.ToInt32(Console.ReadLine());
                this.ControllerMenuIniciar(id);
                if(id == 0) break;
            }
            
        }

        private void ControllerMenuIniciar(int id)
        {
            switch (id)
            {
                case 0: break;

                case 1:
                    Conta conta = new Conta();
                    this.contas.AddFirst(conta.CadastroConta(this.contas));
                    break;

                case 2:

                    this.Logar();
                    break;

            }
        }
        private void ControllerMenuLogin()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"Nome: {this.conta.NomePrimeiro} {this.conta.NomeUltimo};\nSaldo: {this.conta.Saldo};\nNumero da conta: {this.conta.Numero};");
                Console.Write("** Menu do Usuario **\n0. deslogar\n1. Depositar\n2. retirar\n3. Pagar Conta\n4. Extrato\n");
                Console.Write("Informe qual opicao quer: ");
                int id = Convert.ToInt32(Console.ReadLine());
                this.ControllerMenuLogado(id);
                if (id == 0) break;
            }
            
        }

        private void ControllerMenuLogado(int id)
        {
            switch (id)
            {
                case 0: break;

                case 1:
                    Console.Clear();
                    Console.Write("** Depositar na conta **");
                    Console.Write("\nInforme a quantia a ser depositada: ");
                    decimal valorDepositar = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Depositar(valorDepositar);
                    DateTime dataDepositar = DateTime.Now;
                    string datDepositar = Convert.ToString(dataDepositar);

                    Extrato extraDepositar = new Extrato("Depositar", valorDepositar, datDepositar);
                    this.conta.Extrato.AddFirst(extraDepositar);
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("** Retirar na conta **");
                    Console.Write("\nInforme a quantia a ser retirada: ");
                    decimal valorRetirar = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Retirar(valorRetirar);
                    DateTime dataRetirar = DateTime.Now;
                    string detaRetirar = Convert.ToString(dataRetirar);

                    Extrato extratoRetirar = new Extrato("Retirada", valorRetirar, detaRetirar);
                    this.conta.Extrato.AddFirst(extratoRetirar);
                    break;

                    break;
                case 3:
                    Console.Clear();
                    Console.Write("** Pagar conta **");
                    Console.Write("\nInforme a quantia da conta: ");
                    decimal valorConta = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Retirar(valorConta);
                    DateTime dataConta = DateTime.Now;
                    string detaConta = Convert.ToString(dataConta);

                    Extrato extratoConta = new Extrato("Retirada", valorConta, detaConta);
                    this.conta.Extrato.AddFirst(extratoConta);
                    break;

                    break;
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine($"\n** Extrado da conta {this.conta.Numero}. **");

                    foreach (var ext in this.conta.Extrato)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.Write($"\nData: {ext.Data}\n{ext.Tipo}\nValor na trassicao: {ext.Valor}\nSaldo: {this.conta.Saldo}\n");
                        Console.WriteLine("-----------------------------------");
                    }
                    Console.Write("enter para continuar");
                    Console.ReadLine();
                    break;

            }
        }


        private void Logar()
        {
            Console.Clear ();

            Console.Write("** Logar **");
            Console.Write("\nInforme o primeiro nome da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o cpf da conta: ");
            string cpf = Console.ReadLine();

            foreach (var cont in contas)
            {
                if (nome.Equals(cont.NomePrimeiro))
                {
                    if (cpf.Equals(cont.Cpf))
                    {
                        conta = new Conta();
                        conta = cont;
                        this.ControllerMenuLogin();
                    }
                    else
                    {
                        Console.WriteLine("Cpf não encontrado");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("conta não encontrada");
                    Console.ReadLine();
                }
            }
        }

        
    }
}
