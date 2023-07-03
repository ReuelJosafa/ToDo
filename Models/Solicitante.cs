namespace ToDo
{
    public class Solicitante : Pessoa
    {
        private ListaTarefas _historicoTarefasSolicitadas;
        public Solicitante(string nome, string email, string telefone) : base(nome, email, telefone)
        {
            _historicoTarefasSolicitadas = new ListaTarefas("histórico tarefas solicitadas do(a) " + nome);
        }

        public Tarefa SolicitarTarefa()
        {
            Console.Write("Informe o título da tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Tarefa tarefa = new Tarefa(titulo, descricao, this);
            _historicoTarefasSolicitadas.AddTarefa(tarefa);
            return tarefa;
        }

        public override void ExibirTarefas()
        {
            foreach (var tarefa in _historicoTarefasSolicitadas.GetTarefas)
            {
                Console.WriteLine(tarefa.ToString() + ", solicitada por: " + tarefa.GetSolicitante);
            }
        }
    }
}