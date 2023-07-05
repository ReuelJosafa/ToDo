using Newtonsoft.Json;

namespace ToDo
{

    public static class PessoasService
    {
        private static string solicitantesJson = "listasolicitantes.json";
        private static string responsaveisJson = "listaresponsaveis.json";
        public static void SalvarSolicitantes(List<Solicitante> solicitantes)
        {
            File.WriteAllText(solicitantesJson, JsonConvert.SerializeObject(solicitantes));
        }

        public static void SalvarResponsaveis(List<Responsavel> responsaveis)
        {
            File.WriteAllText(responsaveisJson, JsonConvert.SerializeObject(responsaveis));
        }

        public static List<Solicitante> ObterSolicitantes()
        {

            if (File.Exists(solicitantesJson))
            {
                var data = File.ReadAllText(solicitantesJson);
                return JsonConvert.DeserializeObject<List<Solicitante>>(File.ReadAllText(solicitantesJson))!;
            }
            throw new Exception("Não foi possivel obter as lista de tarefas de nossa base de dados.");
        }

        public static List<Responsavel> ObterResponsaveis()
        {

            if (File.Exists(responsaveisJson))
            {

                return JsonConvert.DeserializeObject<List<Responsavel>>(File.ReadAllText(responsaveisJson))!;
            }
            throw new Exception("Não foi possivel obter as lista de tarefas de nossa base de dados.");
        }
    }
}