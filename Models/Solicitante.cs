namespace ToDo
{
    public class Solicitante : Pessoa, IAcaoTarefa
    {
        private ListaTarefas _historicoTarefasSolicitadas;
        public Solicitante(string nome, string email) : base(nome, email)
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
            Console.WriteLine("\nTarefa solicitada com sucesso!\n");
            return tarefa;
        }

        public void ExibirTarefas()
        {
            Console.WriteLine("Tarefas do(a) ");
            foreach (var tarefa in _historicoTarefasSolicitadas.GetTarefas)
            {
                string realizadaPor = tarefa.GetResponsavel != null ? ", realizada por: " + tarefa.GetResponsavel : "";
                Console.WriteLine(tarefa.ToString() + ", realizada por: " + realizadaPor);
            }
        }
    }
}