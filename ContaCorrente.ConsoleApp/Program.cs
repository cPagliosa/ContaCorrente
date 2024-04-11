namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu menu = new Menu();
                menu.MostrarMenuIniciar();

                Console.WriteLine("\n\nVocê tem certeza que quer sair?\n[1] Sim   [2] Não");
                Console.Write("qual a sua escolha: ");
                int h = Convert.ToInt32(Console.ReadLine());
                if (h == 1) break;

            }
        }
    }
}
