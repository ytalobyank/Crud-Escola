using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Crud_Escola.Repository
{
    public class EscolaRepository : IEscola
    {
        private readonly string uprApi = "https://localhost:7213/";
        
        public List<Escola> GetAsync()
        {
            var schools = new List<Escola>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = cliente.GetStringAsync(uprApi + "Escola/BuscarEscolas");
                    response.Wait();
                    schools = JsonConvert.DeserializeObject<Escola[]>(response.Result).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return schools;
        }

        public Escola GetByIdAsync(int id)
        {
            var requestedSchool = new Escola();
            requestedSchool.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    //string jsonObject = JsonConvert.SerializeObject(requestedSchool);
                    //var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.GetAsync(uprApi + "Escola/BuscarEscola/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        requestedSchool = JsonConvert.DeserializeObject<Escola>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return requestedSchool;
        }

        public Escola PostAsync(EscolaModelView escola)
        {
            var newSchool = new Escola();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(escola);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PostAsync(uprApi + "Escola/CriarEscola", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newSchool = JsonConvert.DeserializeObject<Escola>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newSchool;
        }

        public Escola PutAsync(EscolaModelView escola, int id)
        {
            var newSchool = new Escola();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(escola);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PutAsync(uprApi + "Escola/AtualizarEscola/" + id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newSchool = JsonConvert.DeserializeObject<Escola>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newSchool;
        }
        public Escola DeleteAsync(int id)
        {
            var deletedSchool = new Escola();
            deletedSchool.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(deletedSchool);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.DeleteAsync(uprApi + "Escola/DeletarEscola/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        deletedSchool = JsonConvert.DeserializeObject<Escola>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return deletedSchool;
        }
    }
}
