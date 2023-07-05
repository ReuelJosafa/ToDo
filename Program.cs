
namespace ToDo;
class Program
{
    static void Main()
    {
        List<Solicitante> solicitantes = new List<Solicitante> { };
        List<Responsavel> responsaveis = new List<Responsavel> { };
        try
        {
            // Console.WriteLine(ListaTarefaService.ObterListaTarefas());
            solicitantes.AddRange(PessoasService.ObterSolicitantes());
            responsaveis.AddRange(PessoasService.ObterResponsaveis());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        List<ListaTarefas> listaListaTarefas = new List<ListaTarefas> { };


        // Cria a 1º Lista de Tarefas
        ListaTarefas listaTarefas = new ListaTarefas("Tarefas Suporte");
        listaListaTarefas.Add(listaTarefas);

        Console.Write("\n\nSistema de Gerenciamento de Tarefas - ToDo\n\n");

        int opcaoSelecionada = 0;
        while (opcaoSelecionada >= 0 && opcaoSelecionada <= 8)
        {
            Console.Write(
                "0 - Limpar console\n" +
                "1 - Criar ListaTarefas\n" +
                "2 - Exibir ListaTarefas\n" +
                "3 - Solicitar Tarefa\n" +
                "4 - Exibir Tarefas\n" +
                "5 - Cadastrar Pessoa\n" +
                "6 - Exibir Pessoas Cadastradas\n" +
                "7 - Iniciar Tarefa\n" +
                "8 - Finalizar Tarefa\n" +
                "9 - Sair\n\n" +
                "Digite um número para iniciar umas das ações listadas acima: "
            );

            opcaoSelecionada = InputInt();
            Console.Write(opcaoSelecionada);
            PularLinhaConsole();

            if (opcaoSelecionada == 0)
            {
                LimparConsole();
                continue;
            }
            if (opcaoSelecionada == 1)
            {
                ListaTarefas novaListaT = MenuOpcoes.CriarListaTarefas();
                listaListaTarefas.Add(novaListaT);
                LimparConsole();
                Console.WriteLine("Lista de Tarefas criada com sucesso!");
                PularLinhaConsole();
                MenuOpcoes.ExibirListaTarefas(listaListaTarefas);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 2)
            {
                LimparConsole();
                MenuOpcoes.ExibirListaTarefas(listaListaTarefas);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 3)
            {
                LimparConsole();
                MenuOpcoes.ExibirListaTarefas(listaListaTarefas);
                int indexSelecionado = MenuOpcoes.SelecionarItem(listaListaTarefas.Count, "Informe para qual lista a tarefa está sendo solicitada: ");
                Tarefa novaTarefa = MenuOpcoes.SolicitarTarefa(solicitantes);
                listaListaTarefas[indexSelecionado].AddTarefa(novaTarefa);
                PularLinhaConsole();
                continue;
            }
            if (opcaoSelecionada == 4)
            {
                LimparConsole();
                foreach (ListaTarefas listaTarefa in listaListaTarefas)
                {
                    PularLinhaConsole();
                    MenuOpcoes.ExibirTarefas(listaTarefa.GetTarefas, listaTarefa.Titulo);
                }
                continue;
            }
            if (opcaoSelecionada == 5)
            {
                Pessoa pessoa = MenuOpcoes.CadastrarPessoa();
                if (pessoa is Solicitante)
                {
                    solicitantes.Add(pessoa as Solicitante);
                    continue;
                }

                responsaveis.Add(pessoa as Responsavel);
                continue;
            }
            if (opcaoSelecionada == 6)
            {
                MenuOpcoes.ExibirPessoas(responsaveis);
                MenuOpcoes.ExibirPessoas(solicitantes);
                continue;
            }
            if (opcaoSelecionada == 7)
            {
                MenuOpcoes.ExibirListaTarefas(listaListaTarefas);
                int indexLT = MenuOpcoes.SelecionarItem(listaListaTarefas.Count, "Informe de qual lista a tarefa será iniciada: ");
                MenuOpcoes.ExibirTarefas(listaListaTarefas[indexLT].getTarefasSemResponsavel(), listaListaTarefas[indexLT].Titulo);
                int indexTarefa = MenuOpcoes.SelecionarItem(listaListaTarefas[indexLT].getTarefasSemResponsavel().Count, "Selecione uma das tarefas: ");
                MenuOpcoes.ExibirPessoas(responsaveis);
                int indexResponsavel = MenuOpcoes.SelecionarItem(responsaveis.Count, "Selecione um responsável");
                responsaveis[indexResponsavel].IniciarTarefa(listaListaTarefas[indexLT].GetTarefas[indexTarefa]);
                continue;
            }
            if (opcaoSelecionada == 8)
            {
                MenuOpcoes.ExibirListaTarefas(listaListaTarefas);
                int indexLT = MenuOpcoes.SelecionarItem(listaListaTarefas.Count, "Informe de qual lista a tarefa será finalizada: ");
                MenuOpcoes.ExibirTarefas(listaListaTarefas[indexLT].getTarefasComResponsavel(), listaListaTarefas[indexLT].Titulo);
                int indexTarefa = MenuOpcoes.SelecionarItem(listaListaTarefas[indexLT].getTarefasComResponsavel().Count, "Selecione uma das tarefas: ");
                Tarefa tarefaFim = listaListaTarefas[indexLT].getTarefasComResponsavel()[indexTarefa];
                tarefaFim = listaListaTarefas[indexLT].getTarefaBy(tarefaFim.Titulo);
                tarefaFim.FinalizarTarefa();
                continue;
            }
        }

        ListaTarefaService.SalvarListaTarefas(listaListaTarefas);
        PessoasService.SalvarSolicitantes(solicitantes);
        PessoasService.SalvarResponsaveis(responsaveis);

    }

    static void PularLinhaConsole() => Console.WriteLine();
    static void LimparConsole() => Console.Clear();

    static int InputInt()
    {
        string input = Console.ReadLine();
        int value;
        int.TryParse(input, out value);
        return value;
    }
}
