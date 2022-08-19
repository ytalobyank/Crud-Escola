using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Crud_Escola.Repository
{
    public class AlunoRepository : IAluno
    {
        private readonly string uprApi = "https://localhost:7213/";

        public List<Aluno> GetAsync()
        {
            var students = new List<Aluno>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = cliente.GetStringAsync(uprApi + "Aluno/BuscarAlunos");
                    response.Wait();
                    students = JsonConvert.DeserializeObject<Aluno[]>(response.Result).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return students;
        }

        public Aluno GetByIdAsync(int id)
        {
            var requestedStudent = new Aluno();
            requestedStudent.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = cliente.GetAsync(uprApi + "Aluno/BuscarAluno/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        requestedStudent = JsonConvert.DeserializeObject<Aluno>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return requestedStudent;
        }

        public Aluno PostAsync(AlunoModelView turma)
        {
            var newStudent = new Aluno();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(turma);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PostAsync(uprApi + "Aluno/CriarAluno", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newStudent = JsonConvert.DeserializeObject<Aluno>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newStudent;
        }
        public List<Aluno> PostListAsync(List<AlunoModelView> turma)
        {
            var newStudents = new List<Aluno>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(turma);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PostAsync(uprApi + "Aluno/CriarAlunos", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newStudents = JsonConvert.DeserializeObject<Aluno[]>(returned.Result).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newStudents;
        }

        public Aluno PutAsync(AlunoModelView escola, int id)
        {
            var newStudent = new Aluno();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(escola);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.PutAsync(uprApi + "Aluno/AtualizarAluno/" + id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        newStudent = JsonConvert.DeserializeObject<Aluno>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return newStudent;
        }
        public Aluno DeleteAsync(int id)
        {
            var deletedStudent = new Aluno();
            deletedStudent.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(deletedStudent);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = cliente.DeleteAsync(uprApi + "Aluno/DeletarAluno/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returned = response.Result.Content.ReadAsStringAsync();
                        deletedStudent = JsonConvert.DeserializeObject<Aluno>(returned.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return deletedStudent;
        }
    }
}
