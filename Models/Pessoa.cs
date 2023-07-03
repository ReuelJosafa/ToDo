namespace ToDo
{
    public abstract class Pessoa
    {
        // protected int _id;
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Pessoa(string nome, string email, string telefone)
        {
            // _id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        
        public virtual void ExibirTarefas() => throw new Exception("Este método deve ser implementado.");
    }
}