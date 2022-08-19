using Front_Crud_Escola.Models;

namespace Front_Crud_Escola.Interfaces
{
    public interface ITurma
    {
        List<Turma> GetAsync();

        Turma GetByIdAsync(int id);

        Turma PostAsync(TurmaModelView turma);

        Turma PutAsync(TurmaModelView turma, int id);

        Turma DeleteAsync(int id);

        List<Turma> PostListAsync(List<TurmaModelView> turma);
    }
}
