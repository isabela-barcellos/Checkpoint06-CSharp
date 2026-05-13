using HelpDesk.Data;
using HelpDesk.Models;

class Program
{
    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("\n===== SISTEMA HELP DESK =====");

            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Listar clientes");

            Console.WriteLine("3 - Cadastrar técnico");
            Console.WriteLine("4 - Listar técnicos");

            Console.WriteLine("5 - Cadastrar chamado");
            Console.WriteLine("6 - Listar chamados");

            Console.WriteLine("10 - Cadastrar equipamento");
            Console.WriteLine("11 - Listar equipamentos");
            Console.WriteLine("12 - Atualizar status do equipamento");
            Console.WriteLine("13 - Remover equipamento");

            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha uma opção: ");

            bool opcaoValida = int.TryParse(Console.ReadLine(), out opcao);

            if (!opcaoValida)
            {
                Console.WriteLine("Digite uma opção válida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarCliente();
                    break;

                case 2:
                    ListarClientes();
                    break;

                case 3:
                    CadastrarTecnico();
                    break;

                case 4:
                    ListarTecnicos();
                    break;

                case 5:
                    CadastrarChamado();
                    break;

                case 6:
                    ListarChamados();
                    break;

                case 10:
                    CadastrarEquipamento();
                    break;

                case 11:
                    ListarEquipamentos();
                    break;

                case 12:
                    AtualizarStatusEquipamento();
                    break;

                case 13:
                    RemoverEquipamento();
                    break;

                case 0:
                    Console.WriteLine("Sistema encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 0);
    }

    // ========================= CLIENTES =========================

    static void CadastrarCliente()
    {
        using var context = new HelpDeskContext();

        Console.Write("Nome do cliente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Email do cliente: ");
        string email = Console.ReadLine() ?? string.Empty;

        var cliente = new Cliente
        {
            Nome = nome,
            Email = email
        };

        context.Clientes.Add(cliente);

        context.SaveChanges();

        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    static void ListarClientes()
    {
        using var context = new HelpDeskContext();

        var clientes = context.Clientes.ToList();

        if (clientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        foreach (var cliente in clientes)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {cliente.Id}");
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Email: {cliente.Email}");
        }
    }

    // ========================= TECNICOS =========================

    static void CadastrarTecnico()
    {
        using var context = new HelpDeskContext();

        Console.Write("Nome do técnico: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Especialidade: ");
        string especialidade = Console.ReadLine() ?? string.Empty;

        var tecnico = new Tecnico
        {
            Nome = nome,
            Especialidade = especialidade
        };

        context.Tecnicos.Add(tecnico);

        context.SaveChanges();

        Console.WriteLine("Técnico cadastrado com sucesso!");
    }

    static void ListarTecnicos()
    {
        using var context = new HelpDeskContext();

        var tecnicos = context.Tecnicos.ToList();

        if (tecnicos.Count == 0)
        {
            Console.WriteLine("Nenhum técnico cadastrado.");
            return;
        }

        foreach (var tecnico in tecnicos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {tecnico.Id}");
            Console.WriteLine($"Nome: {tecnico.Nome}");
            Console.WriteLine($"Especialidade: {tecnico.Especialidade}");
        }
    }

    // ========================= CHAMADOS =========================

    static void CadastrarChamado()
    {
        using var context = new HelpDeskContext();

        Console.Write("Título do chamado: ");
        string titulo = Console.ReadLine() ?? string.Empty;

        Console.Write("Descrição do chamado: ");
        string descricao = Console.ReadLine() ?? string.Empty;

        Console.Write("Status do chamado: ");
        string status = Console.ReadLine() ?? string.Empty;

        var chamado = new Chamado
        {
            Titulo = titulo,
            Descricao = descricao,
            Status = status
        };

        context.Chamados.Add(chamado);

        context.SaveChanges();

        Console.WriteLine("Chamado cadastrado com sucesso!");
    }

    static void ListarChamados()
    {
        using var context = new HelpDeskContext();

        var chamados = context.Chamados.ToList();

        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado cadastrado.");
            return;
        }

        foreach (var chamado in chamados)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {chamado.Id}");
            Console.WriteLine($"Título: {chamado.Titulo}");
            Console.WriteLine($"Descrição: {chamado.Descricao}");
            Console.WriteLine($"Status: {chamado.Status}");
        }
    }

    // ========================= EQUIPAMENTOS =========================

    static void CadastrarEquipamento()
    {
        using var context = new HelpDeskContext();

        Console.Write("Patrimônio: ");
        string patrimonio = Console.ReadLine() ?? string.Empty;

        Console.Write("Tipo: ");
        string tipo = Console.ReadLine() ?? string.Empty;

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine() ?? string.Empty;

        Console.Write("Status: ");
        string status = Console.ReadLine() ?? string.Empty;

        Console.Write("Localização: ");
        string localizacao = Console.ReadLine() ?? string.Empty;

        var equipamento = new Equipamento
        {
            Patrimonio = patrimonio,
            Tipo = tipo,
            Modelo = modelo,
            Status = status,
            Localizacao = localizacao
        };

        context.Equipamentos.Add(equipamento);

        context.SaveChanges();

        Console.WriteLine("Equipamento cadastrado com sucesso!");
    }

    static void ListarEquipamentos()
    {
        using var context = new HelpDeskContext();

        var equipamentos = context.Equipamentos.ToList();

        if (equipamentos.Count == 0)
        {
            Console.WriteLine("Nenhum equipamento cadastrado.");
            return;
        }

        foreach (var equipamento in equipamentos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {equipamento.Id}");
            Console.WriteLine($"Patrimônio: {equipamento.Patrimonio}");
            Console.WriteLine($"Tipo: {equipamento.Tipo}");
            Console.WriteLine($"Modelo: {equipamento.Modelo}");
            Console.WriteLine($"Status: {equipamento.Status}");
            Console.WriteLine($"Localização: {equipamento.Localizacao}");
        }
    }

    static void AtualizarStatusEquipamento()
    {
        using var context = new HelpDeskContext();

        Console.Write("Digite o Id do equipamento: ");

        bool idValido = int.TryParse(Console.ReadLine(), out int id);

        if (!idValido)
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var equipamento =
            context.Equipamentos.FirstOrDefault(e => e.Id == id);

        if (equipamento == null)
        {
            Console.WriteLine("Equipamento não encontrado.");
            return;
        }

        Console.WriteLine($"Status atual: {equipamento.Status}");

        Console.Write("Novo status: ");

        string novoStatus = Console.ReadLine() ?? string.Empty;

        equipamento.Status = novoStatus;

        context.SaveChanges();

        Console.WriteLine("Status atualizado com sucesso!");
    }

    static void RemoverEquipamento()
    {
        using var context = new HelpDeskContext();

        Console.Write("Digite o Id do equipamento: ");

        bool idValido = int.TryParse(Console.ReadLine(), out int id);

        if (!idValido)
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var equipamento =
            context.Equipamentos.FirstOrDefault(e => e.Id == id);

        if (equipamento == null)
        {
            Console.WriteLine("Equipamento não encontrado.");
            return;
        }

        context.Equipamentos.Remove(equipamento);

        context.SaveChanges();

        Console.WriteLine("Equipamento removido com sucesso!");
    }
}