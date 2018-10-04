using App.Objects;

namespace App.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetById(int id);
    }
}