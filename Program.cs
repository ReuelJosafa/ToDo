
namespace ToDo;
class Program
{
    static void Main()
    {
        List<ListaTarefas> listaListaTarefas = new List<ListaTarefas> { };
        List<Solicitante> solicitantes = new List<Solicitante> { };
        List<Responsavel> responsaveis = new List<Responsavel> { };

        // Cria a 1º Lista de Tarefas
        ListaTarefas listaTarefas = new ListaTarefas("Tarefas Suporte");
        listaListaTarefas.Add(listaTarefas);


        Responsavel responsavel = new Responsavel("João", "joao@gmail.com", "42343567");
        responsaveis.Add(responsavel);
        Solicitante solicitante = new Solicitante("Maria", "maria@gmail.com", "42765487654");
        solicitantes.Add(solicitante);
        // Tarefa t2 = solicitante.SolicitarTarefa();

        // listaTarefas.AddTarefa(t1);

        // responsavel.IniciarTarefa(t1);
        // responsavel.FinalizarTarefa(t1);

        Console.Write("Sistema de Gerenciamento de Tarefas - ToDo\n\n");

        int opcaoSelecionada = 0;
        while (opcaoSelecionada >= 0 && opcaoSelecionada < 8)
        {
            Console.Write(
                "0 - Limpar console\n" +
                "1 - Criar ListaTarefas\n" +
                "2 - Exibir ListaTarefas\n" +
                "3 - Solicitar Tarefa\n" +
                "4 - Exibir Tarefas\n" +
                "5 - Cadastrar Responsavel\n" +
                "6 - Cadastrar Solicitante\n" +
                "7 - Exibir Pessoas Cadastradas\n" +
                "8 - Sair\n\n" +
                "Digite um número para iniciar umas das ações listadas acima: "
            );

            int.TryParse(Console.ReadLine(), out opcaoSelecionada);
            PularLinhaConsole();

            if (opcaoSelecionada == 0)
            {
                LimparConsole();
                continue;
            }
            if (opcaoSelecionada == 1)
            {
                ListaTarefas novaListaT = CriarListaTarefas();
                listaListaTarefas.Add(novaListaT);
                LimparConsole();
                Console.WriteLine("Lista de Tarefas criada com sucesso!");
                PularLinhaConsole();
                ExibirListaTarefas(listaListaTarefas);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 2)
            {
                LimparConsole();
                ExibirListaTarefas(listaListaTarefas);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 3)
            {
                LimparConsole();
                ExibirListaTarefas(listaListaTarefas);
                int indexSelecionado = SelecionarListaTarefa(listaListaTarefas.Count) - 1;
                Tarefa novaTarefa = SolicitarTarefa(solicitantes);
                listaListaTarefas[indexSelecionado].AddTarefa(novaTarefa);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 4)
            {
                LimparConsole();
                for (int index = 0; index < listaListaTarefas.Count; index++)
                {
                    PularLinhaConsole();
                    ExibirTarefas(listaListaTarefas[index].Titulo, listaListaTarefas[index].GetTarefas);

                }
                continue;
            }
        }


    }

    /* 
    
    Criar menu com
    4 - Exibir Tarefas
    5 - Cadastrar Responsavel
    6 - Cadastrar Solicitante
    7 - Exibir Pessoas Cadastradas
    8 - Iniciar Tarefa
    9 - Finalizar Tarefa
    8 - Sair
    
     */

    static ListaTarefas CriarListaTarefas()
    {
        Console.Write("Digite o título da lista de tarefas: ");
        string titulo = Console.ReadLine();
        return new ListaTarefas(titulo);
    }

    static void ExibirListaTarefas(List<ListaTarefas> listaLT)
    {
        Console.WriteLine("--------------------------------------Listagem Lista de Tarefas--------------------------------------");
        for (int index = 0; index < listaLT.Count; index++)
        {
            Console.WriteLine(index + 1 + " - " + listaLT[index].Titulo);
        }
        Console.WriteLine("------------------------------------Fim Listagem Lista de Tarefas------------------------------------");
    }

    static Tarefa SolicitarTarefa(List<Solicitante> solicitantes)
    {
        Console.WriteLine("--------------------------------------Listagem Solicitantes--------------------------------------");
        for (int index = 0; index < solicitantes.Count; index++)
        {
            Console.WriteLine(index + 1 + " - " + solicitantes[index].Nome);
        }
        Console.WriteLine("------------------------------------Fim Listagem Solicitantes------------------------------------");
        PularLinhaConsole();

        bool infomouIdValido = false;
        int indexSolicitanteSelecionado = 0;
        while (!infomouIdValido)
        {
            Console.WriteLine("Informe o número de uma pessoa solicitante: ");
            string input = Console.ReadLine();
            infomouIdValido = int.TryParse(input, out indexSolicitanteSelecionado) && solicitantes.Count <= indexSolicitanteSelecionado;
        }
        return solicitantes[indexSolicitanteSelecionado - 1].SolicitarTarefa();
    }

    static int SelecionarListaTarefa(int qtdListaTarefa)
    {
        int indexLista = 0;
        while (indexLista <= 0 || indexLista > qtdListaTarefa)
        {
            Console.WriteLine("informe para qual lista a tarefa está sendo solicitada: ");
            int.TryParse(Console.ReadLine(), out indexLista);
        }
        return indexLista;
    }

    static void ExibirTarefas(string tituloLista, List<Tarefa> tarefas)
    {
        Console.WriteLine("--------------------------------------Listagem Tarefas--------------------------------------");
        Console.WriteLine("Tarefas da lista: " + tituloLista + "\n");

        if (tarefas.Count == 0) Console.Write("Lista vazia.\n");

        for (int index = 0; index < tarefas.Count; index++)
        {
            Console.WriteLine(index + 1 + " - " + tarefas[index].Titulo);
            Console.WriteLine("Descrição: " + tarefas[index].Descricao);
            Console.WriteLine("Status: " + tarefas[index].GetStatus.Titulo);
            Console.WriteLine("Solicitante: " + tarefas[index].GetSolicitante.Nome);
            string nomeResponsavel = tarefas[index].GetResponsavel != null ? tarefas[index].GetResponsavel.Nome : "não possui";
            Console.WriteLine("Responsável: " + nomeResponsavel);
        }
        Console.WriteLine("------------------------------------Fim Listagem Tarefas------------------------------------");
        PularLinhaConsole();
    }

    static void PularLinhaConsole() => Console.WriteLine();
    static void LimparConsole() => Console.Clear();

}
