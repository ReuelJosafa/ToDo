namespace ToDo
{
    public class Status
    {
        private int _id;
        public string Titulo { get; set; }
        public string CorHex { get; set; }

        public Status(int id, string titulo, string corHex)
        {
            _id = id;
            Titulo = titulo;
            CorHex = corHex;
        }


    }


    // Poderia ser feito 4 classes que herdam de Status, também poderia ser enum
    public static class StatusStatic
    {
        public static Status AFazer = new Status(1, "A fazer", "FFFFFF");
        public static Status EmProgresso = new Status(2, "Em Progresso", "FFFFFF");
        public static Status Finalizado = new Status(3, "Finalizado", "FFFFFF");
    }

}