namespace financas.Models
{
    public class Conta
    {
         public decimal Saldo { get; private set; }
    public List<Transacao> Transacoes { get; private set; }

    public Conta()
    {
        Saldo = 0;
        Transacoes = new List<Transacao>();
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        Transacoes.Add(transacao);
        if (transacao.Tipo == "Entrada")
            Saldo += transacao.Valor;
        else if (transacao.Tipo == "Saída")
            Saldo -= transacao.Valor;
    }

    public void ExibirExtrato()
    {
        Console.WriteLine("Extrato de Transações:");
        foreach (var transacao in Transacoes)
        {
            Console.WriteLine(transacao);
        }
        Console.WriteLine($"Saldo Atual: {Saldo:C}");
    }
    }
}