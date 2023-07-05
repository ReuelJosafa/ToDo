namespace ToDo
{
    public class Responsavel : Pessoa
    {
        public ListaTarefas _historicoTarefasRealizadas;
        public Responsavel(string nome, string email, string telefone) : base(nome, email, telefone)
        {
            _historicoTarefasRealizadas = new ListaTarefas("histórico tarefas realizadas do(a) " + nome);
        }

        public void IniciarTarefa(Tarefa tarefa)
        {
            DateTime data = DateTime.UnixEpoch;

            while (data == DateTime.UnixEpoch)
            {
                Console.Write("Informe a data de finalização da tarefa " + tarefa.Titulo + ": ");
                string novaData = Console.ReadLine();
                DateTime.TryParse(novaData, out data);
            }
            tarefa.IniciarTarefa(data, this);
            Console.WriteLine("A tarefa '" + tarefa.Descricao + "', solicitada no dia " + tarefa.GetDataSolicitacao + ", deve ser finalizada até o dia " + tarefa.GetDataFim);
        }

        public void FinalizarTarefa(Tarefa tarefa)
        {
            if (tarefa.GetResponsavel != this)
            {
                throw new Exception("Esta tarefa não corresponde a(o) responsável: " + base.Nome);
            }
            tarefa.FinalizarTarefa();
            _historicoTarefasRealizadas.AddTarefa(tarefa);
        }

        public override void ExibirTarefas()
        {
            foreach (var tarefa in _historicoTarefasRealizadas.GetTarefas)
            {
                string soliciatadaPor = tarefa.GetSolicitante != null ? ", solicitada por: " + tarefa.GetSolicitante : "";
                Console.WriteLine(tarefa.ToString() + soliciatadaPor);
            }
        }
    }


}