using Newtonsoft.Json;

namespace ToDo
{

    public abstract class ListaTarefaService
    {
        public static void SalvarListaTarefas(List<ListaTarefas> tarefas)
        {
            File.WriteAllText("listatarefas.json", JsonConvert.SerializeObject(tarefas));
        }

        public static List<ListaTarefas> ObterListaTarefas()
        {

            if (File.Exists("listatarefas.json"))
            {
                var data = File.ReadAllText("listatarefas.json");
                return JsonConvert.DeserializeObject<List<ListaTarefas>>(File.ReadAllText("listatarefas.json"))!;
            }
            throw new Exception("Não foi possivel obter as lista de tarefas de nossa base de dados.");
        }

    }
}