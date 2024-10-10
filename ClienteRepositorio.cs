using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
  public List<Cliente> clientes = new List<Cliente>();

  public void GravarDadosClientes()
  {
    var json = System.Text.Json.JsonSerializer.Serialize(clientes); // Serializando os dados da lista clientes em um json

    File.WriteAllText("clientes.txt", json); // Salvando os dados em um arquivo txt
  }

  public void LerDadosClientes()
  {
    if (File.Exists("clientes.txt"))
    {
      var dados = File.ReadAllText("clientes.txt"); // Lendo todos os dados do arquivo txt

      var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados); // Deserializando os dados json para a lista cliente

      clientes.AddRange(clientesArquivo); // Adicionando os dados que estavam no arquivo a lista clientes
    }
  }

  public void ExcluirCliente()
  {
    Console.Clear();
    Console.Write("Informe o código do cliente: ");
    var codigo = Console.ReadLine();

    var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

    if (cliente == null)
    {
      Console.WriteLine("Cliente não encontrado! [Enter]");
      Console.ReadKey();
      return;
    }

    ImprimirCliente(cliente);

    clientes.Remove(cliente);

    Console.WriteLine("Cliente removido com sucesso! [Enter]");
    Console.ReadKey();
  }

  public void EditarCliente()
  {
    Console.Clear();
    Console.Write("Informe o código do cliente: ");
    var codigo = Console.ReadLine();

    var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

    if (cliente == null)
    {
      Console.WriteLine("Cliente não encontrado! [Enter]");
      Console.ReadKey();
      return;
    }

    ImprimirCliente(cliente);

    Console.Write("Nome do cliente: ");
    var nome = Console.ReadLine();
    Console.Write(Environment.NewLine);

    Console.Write("Data de nascimento: ");
    var dataNascimento = DateOnly.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    Console.Write("Desconto: ");
    var desconto = Decimal.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    cliente.Nome = nome;
    cliente.DataNascimento = dataNascimento;
    cliente.Desconto = desconto;
    cliente.CadastradoEm = DateTime.Now;

    ImprimirCliente(cliente);
    Console.WriteLine("Cliente alterado com sucesso! [Enter]");
    Console.ReadKey();
  }

  public void CadastrarCliente()
  {
    Console.Clear();

    Console.Write("Nome do cliente: ");
    var nome = Console.ReadLine();
    Console.Write(Environment.NewLine);

    Console.Write("Data de nascimento: ");
    var dataNascimento = DateOnly.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    Console.Write("Desconto: ");
    var desconto = Decimal.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    var cliente = new Cliente();
    cliente.Id = clientes.Count + 1;
    cliente.Nome = nome;
    cliente.DataNascimento = dataNascimento;
    cliente.Desconto = desconto;
    cliente.CadastradoEm = DateTime.Now;

    clientes.Add(cliente);
    
    ImprimirCliente(cliente);
    Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
    Console.ReadKey();
  }

  public void ImprimirCliente(Cliente cliente)
  {
    Console.WriteLine("ID.............: " + cliente.Id);
    Console.WriteLine("Nome...........: " + cliente.Nome);
    Console.WriteLine("Desconto.......: " + cliente.Desconto.ToString("0.00"));
    Console.WriteLine("Data Nascimento: " + cliente.DataNascimento);
    Console.WriteLine("Data Cadastro..: " + cliente.CadastradoEm);
    Console.WriteLine("-------------------------------------");
  }

  public void ExibirClientes()
  {
    Console.Clear();

    if (clientes.Count() == 0)
    {
      Console.WriteLine("Não há clientes cadastrados! [Enter]");
      Console.ReadKey();
      return;
    }

    foreach (var cliente in clientes)
    {
      ImprimirCliente(cliente);
    }

    Console.ReadKey();
  }
}