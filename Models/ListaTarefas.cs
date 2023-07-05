namespace ToDo
{
    public class ListaTarefas
    {
        public string Titulo { get; set; }
        private List<Tarefa> _tarefas;

        public ListaTarefas(string titulo)
        {
            Titulo = titulo;
            _tarefas = new List<Tarefa> { };
        }

        public List<Tarefa> GetTarefas => _tarefas;

        public void AddTarefa(Tarefa tarefa)
        {
            if (tarefa.GetSolicitante == null)
            {
                throw new Exception("Uma tarefa só pode ser adicionada por um solicitante.");
            }
            _tarefas.Add(tarefa);
        }


        public void RemoverTarefa(Tarefa tarefa)
        {
            if (tarefa.GetSolicitante != null)
            {
                throw new Exception("Uma tarefa só pode ser removida por um solicitante.");
            }
            bool removida = _tarefas.Remove(tarefa);
            if (removida) Console.WriteLine("Tarefa removida com sucesso!");
            else Console.WriteLine("A Tarefa não pode ser removida.");
        }

        public Tarefa getTarefaBy(String titulo)
        {
            try
            {
                return _tarefas.Find(tr => tr.Titulo == titulo);
            }
            catch
            {
                throw new Exception("Não há tarefa com o tipo " + titulo + "!");
            }

        }

        /* public Tarefa getTarefaBy(Pessoa pessoa)
        {
            return _tarefas.Find(tr => tr.Responsavel == pessoa || tr.Solicitante == pessoa);

        } */

        public void getTarefasSemResponsavel()
        {

        }

        public void ExibirTarefas()
        {
            Console.WriteLine("Tarefas da lista: " + Titulo + "\n");
            Console.WriteLine("--------------------------------------Listagem Tarefas--------------------------------------");
            for (int index = 0; index < _tarefas.Count; index++)
            {
                Console.WriteLine(index + 1 + " - " + _tarefas[index].Titulo);
            }
            Console.WriteLine("------------------------------------Fim Listagem Tarefas------------------------------------");

        }

    }
}