namespace Cadastro;

public class Cliente
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public DateOnly DataNascimento { get; set; } // Somente data
  public DateTime CadastradoEm { get; set; } // Data e hora
  public decimal Desconto { get; set; }
}