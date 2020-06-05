using System.Collections.Generic;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    public interface IVisitingRepository
    {
        IEnumerable<Visiting> getAll();
        void delete(Visiting Visiting);
        void add(Visiting Visiting);

        IEnumerable<Visiting> getByAbonementId(int id);

    }
}
