
namespace ToDo;
class Program
{
    static void Main()
    {

        /* Produto produto2 = new Produto(2, "Macarrão", 3.59, 1);
        produto2.ExibirDados();

        produto2.CalcularPrecoTotal();


        Status status = StatusStatic.AFazer;
        status.Titulo = "To do";
        Console.Write(StatusStatic.AFazer.Titulo);

        Solicitante solicitante1 = new Solicitante("Jubiscréia", "jub@gmail.com", "5542987654");
        Tarefa t1 = new Tarefa("Infra", "Formatar PC", solicitante1);
        t1.GetStatus(); */
















        List<ListaTarefas> listaListaTarefas = new List<ListaTarefas> { };

        // Cria a 1º Lista de Tarefas
        ListaTarefas listaTarefas = new ListaTarefas("Tarefas Suporte");
        listaListaTarefas.Add(listaTarefas);


        Responsavel responsavel = new Responsavel("João", "joao@gmail.com", "42343567");
        Solicitante solicitante = new Solicitante("Maria", "maria@gmail.com", "42765487654");

        Tarefa t2 = solicitante.SolicitarTarefa();

        // listaTarefas.AddTarefa(t1);

        // responsavel.IniciarTarefa(t1);
        // responsavel.FinalizarTarefa(t1);

        int opcaoSelecionada = 0;
        while (opcaoSelecionada == 0)
        {
            Console.Write(
                "Sistema de Gerenciamento de Tarefas - ToDo\n\n" +
                "1 - Criar ListaTarefas\n" +
                "2 - Exibir ListaTarefas\n" +
                "3 - Solicitar Tarefa\n" +
                "4 - Exibir Tarefas\n" +
                "5 - Cadastrar Responsavel\n" +
                "6 - Cadastrar Solicitante\n" +
                "7 - Exibir Pessoas Cadastradas\n" +
                "8 - Sair\n\n" +
                "Digite um número para iniciar umas das seguintes ações: "
            );

            int.TryParse(Console.ReadLine(), out opcaoSelecionada);

            if (opcaoSelecionada == 1)
            {
                ListaTarefas novaListaT = CriarListaTarefas();
                listaListaTarefas.Add(novaListaT);
                Console.WriteLine("Lista de Tarefas criada com sucesso!");
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 2)
            {

            }
        }
    }

    /* 
    
    Criar menu com
    1 - Criar ListaTarefas
    2 - Exibir ListaTarefas
    3 - Solicitar Tarefa
    4 - Exibir Tarefas
    5 - Cadastrar Responsavel
    6 - Cadastrar Solicitante
    7 - Exibir Pessoas Cadastradas
    8 - Sair
    
     */

    static ListaTarefas CriarListaTarefas()
    {
        Console.Write("Digite o título da lista de tarefas: ");
        string titulo = Console.ReadLine();
        return new ListaTarefas(titulo);
    }

    static void ExibirTarefas(List<ListaTarefas> listaLT)
    {
        // listaLT
    }

    static void PularLinhaConsole() => Console.WriteLine();
}
