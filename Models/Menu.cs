using financas.Models;
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
            Console.WriteLine("3. Exibir Extrato Completo");
            Console.WriteLine("4. Exibir Extrato por Período");
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
                case 4:
                    ExibirExtratoPorPeriodo();
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

    private void ExibirExtratoPorPeriodo()
    {
        Console.Write("Data de início (dd/MM/yyyy): ");
        DateTime inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Data de fim (dd/MM/yyyy): ");
        DateTime fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        conta.ExibirExtratoPorPeriodo(inicio, fim);
    }
}
