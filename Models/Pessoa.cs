namespace ToDo
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Pessoa(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        
        // public virtual void ExibirTarefas() => throw new Exception("O método 'ExibirTarefas' não foi implementado na subclasse.");
    }
}