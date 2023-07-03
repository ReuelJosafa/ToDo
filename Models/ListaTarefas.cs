namespace ToDo
{
    public class ListaTarefas
    {
        // private int _id { get; }
        public string Titulo { get; set; }
        private List<Tarefa> _tarefas;

        public ListaTarefas(/* int id,  */string titulo)
        {
            // _id = id;
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
            _tarefas.Remove(tarefa);

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

    }
}