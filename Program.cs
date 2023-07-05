
namespace ToDo;
class Program
{
    static void Main()
    {
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
        while (opcaoSelecionada >= 0 && opcaoSelecionada < 8)
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
                ExibirTarefas(listaListaTarefas);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 3)
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
        listaLT.Sort();
        for (int index = 0; index < listaLT.Count; index++)
        {
            Console.WriteLine(index + 1 + " - " + listaLT[index].Titulo);
        }
    }

    static void PularLinhaConsole() => Console.WriteLine();
}
