using System.Collections.Generic;
using System.Linq;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    class EFVisitingRepository : IVisitingRepository
    {
        private TrainCenterEntities2 context;

        public EFVisitingRepository()
        {
            context = new TrainCenterEntities2();
        }

        public IEnumerable<Visiting> getAll()
        {
            return context.Visitings;
        }

        public void delete(Visiting Visiting)
        {
            context.Visitings.Remove(context.Visitings.FirstOrDefault(x => x.id == Visiting.id));
            context.SaveChanges();
        }
        public void add(Visiting Visiting)
        {
            context.Visitings.Add(Visiting);
            context.SaveChanges();
        }



        public IEnumerable<Visiting> getByAbonementId(int abonementId)
        {
            return context.Visitings.Where(x => x.AbonementId == abonementId).ToList();
        }




    }
}
