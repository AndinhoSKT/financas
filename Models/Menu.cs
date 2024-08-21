namespace financas.Models
{
    public class Menu
    {
         private Conta conta;

    public Menu()
    {
        conta = new Conta();
    }

    public void ExibirMenu()
    {
        int opcao;
        do
        {
            Console.WriteLine("----- Menu Financeiro -----");
            Console.WriteLine("1. Adicionar Entrada");
            Console.WriteLine("2. Adicionar Saída");
            Console.WriteLine("3. Exibir Extrato");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarTransacao("Entrada");
                    break;
                case 2:
                    AdicionarTransacao("Saída");
                    break;
                case 3:
                    conta.ExibirExtrato();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private void AdicionarTransacao(string tipo)
    {
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();
        Console.Write("Valor: ");
        decimal valor = decimal.Parse(Console.ReadLine());
        Transacao transacao = new Transacao(DateTime.Now, descricao, valor, tipo);
        conta.AdicionarTransacao(transacao);
    }
    }
}