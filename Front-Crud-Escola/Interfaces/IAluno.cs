using Front_Crud_Escola.Models;

namespace Front_Crud_Escola.Interfaces
{
    public interface IAluno
    {
        List<Aluno> GetAsync();

        Aluno GetByIdAsync(int id);

        Aluno PostAsync(AlunoModelView aluno);

        List<Aluno> PostListAsync(List<AlunoModelView> aluno);

        Aluno PutAsync(AlunoModelView aluno, int id);

        Aluno DeleteAsync(int id);

        
    }
}
