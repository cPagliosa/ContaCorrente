using System;
using System.Collections;
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

        #region Controlhe do menu sem estar logado

        public void MostrarMenuIniciar()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("** Menu do Banco AP **\n0. Sair\n1. Cadastrar\n2. Logar\n");
                Console.Write("Informe qual opicao quer: ");
                int id = Convert.ToInt32(Console.ReadLine());
                this.ControllerMenuIniciar(id);
                if (id == 0) break;
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

        private void Logar()
        {
            Console.Clear();

            Console.Write("** Logar **");
            Console.Write("\nInforme o nome do titula da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Informe a senha: ");
            string senha = Console.ReadLine();

            foreach (var cont in contas)
            {
                if (nome.Equals(cont.NomePrimeiro))
                {
                    if (senha.Equals(cont.NomeUltimo))
                    {
                        conta = new Conta();
                        conta = cont;
                        this.ControllerMenuLogin();
                    }
                    else
                    {
                        Console.WriteLine("Senha invalida");
                        Console.Write("enter para continuar");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("conta não encontrada!!");
                    Console.Write("enter para continuar");
                    Console.ReadLine();
                }
            }
        }

        #endregion


        #region Controlhe do menu qunado estiver logado
        private void ControllerMenuLogin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Nome: {this.conta.NomePrimeiro};\nNumero da conta: {this.conta.Numero};\nConta Especial: {Convert.ToString(this.conta.Especial)};" +
                    $"\nSaldo: {this.conta.Saldo};\nLimite: {this.conta.Limite};");
                Console.WriteLine("----------------------------------------");

                Console.Write("** Menu do Usuario **\n0. deslogar\n1. Depositar\n2. retirar\n3. Pagar Conta\n4. Extrato\n5. Lista de Contas Cadastradas\n6. Trasferencia");
                Console.Write("Informe qual opicao quer: ");
                int id = Convert.ToInt32(Console.ReadLine());
                this.ControllerMenuLogado(id);
                if (id == 0) break;
            }

        }

        private void ControllerMenuLogado(int id)
        {
            decimal valor;
            DateTime data;
            string dataMgs;
            Extrato extrato;

            switch (id)
            {
                case 0: break;

                case 1:
                    Console.Clear();
                    Console.Write("** Depositar na conta **");
                    Console.Write("\nInforme a quantia a ser depositada: ");
                    valor = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Depositar(valor);
                    data = DateTime.Now;
                    dataMgs = Convert.ToString(data);

                    extrato = new Extrato("Depositar", valor, dataMgs);
                    this.conta.Extrato.AddFirst(extrato);
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("** Sacar na conta **");
                    Console.Write("\nInforme a quantia a ser sacada: ");
                    valor = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Depositar(valor);
                    data = DateTime.Now;
                    dataMgs = Convert.ToString(data);

                    extrato = new Extrato("Sacar", valor, dataMgs);
                    this.conta.Extrato.AddFirst(extrato);
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("** Pagar conta **");
                    Console.Write("\nInforme o valor da conta: ");
                    valor = Convert.ToDecimal(Console.ReadLine());

                    this.conta.Depositar(valor);
                    data = DateTime.Now;
                    dataMgs = Convert.ToString(data);

                    extrato = new Extrato("Pagamento de conta", valor, dataMgs);
                    this.conta.Extrato.AddFirst(extrato);
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
                case 5:
                    this.conta.MostrarContas(this.contas);
                    Console.Write("enter para continuar");
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    Console.Write("** Trasferencia **");
                    Console.Write("\nInforme a quantia a trasferida: ");
                    valor = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("\nInforme o numero da conta destino: ");
                    int destino = Convert.ToInt32(Console.ReadLine());

                    foreach (Conta conta in contas)
                    {
                        if (destino == conta.Numero)
                        {
                            this.conta.Trasferencia(this.conta, conta, destino, valor);
                            data = DateTime.Now;
                            dataMgs = Convert.ToString(data);

                            extrato = new Extrato($"Tranferecia para conta {destino}", valor, dataMgs);
                            this.conta.Extrato.AddFirst(extrato);
                            extrato = new Extrato($"Tranferecia da conta {this.conta.Numero}", valor, dataMgs);
                            conta.Extrato.AddFirst(extrato);
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Conta nao encontrada!!");
                            Console.Write("enter para continuar");
                            Console.ReadLine();
                        }
                    }
                    break;
            }
        }
        #endregion
    }
}
