using System.IO;
using System.Globalization;
using financas.Models;

public class Conta
{
    public decimal Saldo { get; private set; }
    public List<Transacao> Transacoes { get; private set; }
    private string filePath = "transacoes.txt";

    public Conta()
    {
        Saldo = 0;
        Transacoes = new List<Transacao>();
        CarregarTransacoes();
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        Transacoes.Add(transacao);
        if (transacao.Tipo == "Entrada")
            Saldo += transacao.Valor;
        else if (transacao.Tipo == "Saída")
            Saldo -= transacao.Valor;
        SalvarTransacoes();
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

    public void ExibirExtratoPorPeriodo(DateTime inicio, DateTime fim)
    {
        Console.WriteLine($"Extrato de {inicio.ToShortDateString()} a {fim.ToShortDateString()}:");
        foreach (var transacao in Transacoes.Where(t => t.Data >= inicio && t.Data <= fim))
        {
            Console.WriteLine(transacao);
        }
    }

    private void SalvarTransacoes()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var transacao in Transacoes)
            {
                writer.WriteLine($"{transacao.Data.ToString("o")}|{transacao.Descricao}|{transacao.Valor}|{transacao.Tipo}");
            }
        }
    }

    private void CarregarTransacoes()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    var partes = linha.Split('|');
                    var data = DateTime.Parse(partes[0], null, DateTimeStyles.RoundtripKind);
                    var descricao = partes[1];
                    var valor = decimal.Parse(partes[2]);
                    var tipo = partes[3];
                    var transacao = new Transacao(data, descricao, valor, tipo);
                    Transacoes.Add(transacao);
                    if (tipo == "Entrada")
                        Saldo += valor;
                    else if (tipo == "Saída")
                        Saldo -= valor;
                }
            }
        }
    }
}
