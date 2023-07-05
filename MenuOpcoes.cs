namespace ToDo
{
    public abstract class MenuOpcoes
    {
        public static ListaTarefas CriarListaTarefas()
        {
            Console.Write("Digite o título da lista de tarefas: ");
            string titulo = Console.ReadLine();
            return new ListaTarefas(titulo);
        }

        public static void ExibirListaTarefas(List<ListaTarefas> listaLT)
        {
            Console.WriteLine("--------------------------------------Listagem Lista de Tarefas--------------------------------------");
            for (int index = 0; index < listaLT.Count; index++)
            {
                Console.WriteLine(index + 1 + " - " + listaLT[index].Titulo);
            }
            Console.WriteLine("------------------------------------Fim Listagem Lista de Tarefas------------------------------------");
        }

        public static Tarefa SolicitarTarefa(List<Solicitante> solicitantes)
        {
            ExibirPessoas(solicitantes);

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

        public static void ExibirTarefas(List<Tarefa> tarefas, string tituloLista)
        {

            Console.WriteLine("--------------------------------------Listagem Tarefas--------------------------------------");
            Console.WriteLine("Tarefas da lista: " + tituloLista + "\n");

            if (tarefas.Count == 0) Console.Write("Lista vazia.\n");

            for (int index = 0; index < tarefas.Count; index++)
            {
                Tarefa tarefa = tarefas[index];
                Console.WriteLine("Número: " + (index + 1));
                Console.WriteLine("Título - " + tarefa.Titulo);
                Console.WriteLine("Descrição: " + tarefa.Descricao);
                Console.WriteLine("Status: " + tarefa.GetStatus.Titulo);
                Console.WriteLine("Solicitante: " + tarefa.GetSolicitante.Nome);
                string nomeResponsavel = tarefa.GetResponsavel != null ? tarefas[index].GetResponsavel.Nome : "não possui";
                Console.WriteLine("Responsável: " + nomeResponsavel);
                string dataFim = tarefa.GetDataFim != "01/01/0001" ? tarefa.GetDataFim : "não definida";
                Console.WriteLine("Data finalização: " + dataFim);
                PularLinhaConsole();
            }
            Console.WriteLine("------------------------------------Fim Listagem Tarefas------------------------------------");
            PularLinhaConsole();
        }

        // public static void ExibirPessoas(List<Pessoa> pessoas) <- Não me permite fazer isso
        // em outras linguagens pode ser feito.
        public static void ExibirPessoas(dynamic pessoas)
        {
            if (!(pessoas is List<Solicitante>) && !(pessoas is List<Responsavel>))
            {
                throw new Exception("ExibirPessoas só pode receber uma lista de Responsavel ou Solicitante.");
            }
            string complementoTitulo;
            if (pessoas is List<Solicitante>) complementoTitulo = "Solicitantes";
            else complementoTitulo = "Responsáveis";

            Console.WriteLine("--------------------------------------Listagem " + complementoTitulo + "--------------------------------------");
            for (int index = 0; index < pessoas.Count; index++)
            {
                Console.WriteLine(index + 1 + " - " + pessoas[index].Nome);
            }
            Console.WriteLine("------------------------------------Fim Listagem " + complementoTitulo + "------------------------------------");
            PularLinhaConsole();
        }

        public static Pessoa CadastrarPessoa()
        {
            Console.Write("Informe o nome da pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o email da pessoa: ");
            string email = Console.ReadLine();
            int opcaoPessoa = 0;
            while (opcaoPessoa <= 0 || opcaoPessoa > 2)
            {
                Console.Write("Informe se " + nome + " é (1) Solicitante ou (2) Responsável: ");
                opcaoPessoa = InputInt();
            }

            Console.WriteLine("Pessoa cadastrada com sucesso!");

            if (opcaoPessoa == 1) return new Solicitante(nome, email);

            return new Responsavel(nome, email);
        }

        public static int SelecionarItem(int qtdItens, string texto)
        {
            int indexLista = 0;
            while (indexLista <= 0 || indexLista > qtdItens)
            {
                Console.WriteLine(texto);
                int.TryParse(Console.ReadLine(), out indexLista);
            }
            return indexLista - 1;
        }

        public static void PularLinhaConsole() => Console.WriteLine();
        public static void LimparConsole() => Console.Clear();

        public static int InputInt()
        {
            string input = Console.ReadLine();
            int value;
            int.TryParse(input, out value);
            return value;
        }
    }
}