using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Crud_Escola.Repository
{
    public class TurmaRepository : ITurma
    {
        private readonly string uprApi = "https://localhost:7213/";
        
        public List<Turma> GetAsync()
        {
            var classroom = new List<Turma>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = cliente.GetStringAsync(uprApi + "Turma/BuscarTurmas");
                    response.Wait();
                    classroom = JsonConvert.DeserializeObject<Turma[]>(response.Result).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return classroom;
        }

        public Turma GetByIdAsync(int id)
        {
            var requestedClassroom = new Turma();
            requestedClassroom.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = cliente.GetAsync(uprApi + "Turma/BuscarTurma/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        requestedClassroom = JsonConvert.DeserializeObject<Turma>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return requestedClassroom;
        }

        public Turma PostAsync(TurmaModelView turma)
        {
            var newClassroom = new Turma();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(turma);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PostAsync(uprApi + "Turma/CriarTurma", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newClassroom = JsonConvert.DeserializeObject<Turma>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newClassroom;
        }
        public List<Turma> PostListAsync(List<TurmaModelView> turma)
        {
            var newClassrooms = new List<Turma>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(turma);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PostAsync(uprApi + "Turma/CriarTurmas", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newClassrooms = JsonConvert.DeserializeObject<Turma[]>(returned.Result).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newClassrooms;
        }

        public Turma PutAsync(TurmaModelView escola, int id)
        {
            var newClassroom = new Turma();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(escola);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PutAsync(uprApi + "Turma/AtualizarTurma/" + id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newClassroom = JsonConvert.DeserializeObject<Turma>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newClassroom;
        }
        public Turma DeleteAsync(int id)
        {
            var deletedClassroom = new Turma();
            deletedClassroom.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(deletedClassroom);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.DeleteAsync(uprApi + "Turma/DeletarTurma/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        deletedClassroom = JsonConvert.DeserializeObject<Turma>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return deletedClassroom;
        }
    }
}
