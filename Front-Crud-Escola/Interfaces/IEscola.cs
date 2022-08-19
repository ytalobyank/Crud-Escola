using Front_Crud_Escola.Models;

namespace Front_Crud_Escola.Interfaces
{
    public interface IEscola
    {
        List<Escola> GetAsync();

        Escola GetByIdAsync(int id);

        Escola PostAsync(EscolaModelView escola);

        Escola PutAsync(EscolaModelView escola, int id);

        Escola DeleteAsync(int id);
    }
}
