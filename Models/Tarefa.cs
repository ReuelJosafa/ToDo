namespace ToDo
{
    public class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        private Responsavel _responsavel;
        private Solicitante _solicitante;
        private Status _status;
        private DateTime _dataSolicitacao;
        private DateTime _dataInicio;
        private DateTime _dataFim;

        public Tarefa(string titulo, string descricao, Solicitante solicitante)
        {
            if (titulo == null || descricao == null || solicitante == null)
            {
                throw new Exception("Uma tarefa deve conter titulo, descrição e solicitante.");
            }

            // _generateRandomId();
            Titulo = titulo;
            Descricao = descricao;
            _solicitante = solicitante;
            _status = StatusStatic.AFazer;
            _dataSolicitacao = DateTime.Now;
        }

        public Responsavel GetResponsavel => _responsavel;
        public Solicitante GetSolicitante => _solicitante;
        public Status GetStatus => _status;
        public string GetDataSolicitacao => _dataSolicitacao.ToShortDateString();
        public string GetDataInicio => _dataInicio.ToShortDateString();
        public string GetDataFim => _dataFim.ToShortDateString();
        public int CalcularDiasRealizacao => _dataFim.Subtract(_dataInicio).Days;
        public int CalcularDiasRestantes => _dataFim.Subtract(DateTime.Now).Days;

        public void IniciarTarefa(DateTime dataFinalizacao, Responsavel responsavel)
        {
            if (responsavel == null)
            {
                throw new Exception("Uma tarefa não pode ser iniciada sem uma pessoa Responsável.");
            }
            _responsavel = responsavel;
            _status = StatusStatic.EmProgresso;
            _dataInicio = DateTime.Now;
            _dataFim = dataFinalizacao;
        }

        public void FinalizarTarefa()
        {
            if (_responsavel == null) throw new Exception("Uma tarefa não pode ser finilizada sem uma pessoa Responsável.");
            _status = StatusStatic.Finalizado;

            string complementoMsg;

            if (CalcularDiasRestantes >= 0)
                complementoMsg = "no prazo.";
            else
                complementoMsg = "fora do prazo.";

            Console.Write("A tarefa '" + Descricao + "', solicitada no dia " + GetDataSolicitacao
            + ", foi finalizada " + complementoMsg);
        }

        public override string ToString()
        {
            return "Título: " + Titulo + ", descrição: " + Descricao + ", solicitada em: "
            + GetDataSolicitacao + ", de status: " + _status.Titulo;
        }

        /* private void _generateRandomId()
        {
            Random rnd = new Random();
            _id = rnd.Next();
        } */
    }
}