namespace financas.Models
{
    public class Transacao
    {
        public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public string Tipo { get; set; } // "Entrada" ou "Saída"

    public Transacao(DateTime data, string descricao, decimal valor, string tipo)
    {
        Data = data;
        Descricao = descricao;
        Valor = valor;
        Tipo = tipo;
    }

    public override string ToString()
    {
        return $"{Data.ToShortDateString()} - {Descricao} - {Tipo}: {Valor:C}";
    }
    }
}