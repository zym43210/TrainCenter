using System;
using System.Collections.Generic;
using System.Linq;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    class EFAbonementRepository : IAbonementRepository
    {
        private TrainCenterEntities2 context;

        public EFAbonementRepository()
        {
            context = new TrainCenterEntities2();
        }
        public EFAbonementRepository(TrainCenterEntities2 context)
        {
            this.context = context;
        }
        public IEnumerable<Abonement> getAll()
        {
            return context.Abonements;
        }
        public void add(Abonement abonement)
        {
            context.Abonements.Add(abonement);
            context.SaveChanges();
        }
        public void delete(Abonement abonement)
        {
            context.Abonements.Remove(context.Abonements.FirstOrDefault(x => x.id == abonement.id));
            context.SaveChanges();
        }

        public Abonement getByEndDate(DateTime date)
        {
            return context.Abonements.FirstOrDefault(x => x.EndDate == date);
        }


        public IEnumerable<Abonement> getManyByPersonId(int id)
        {
            return context.Abonements.Where(x => x.PersonId == id).ToList();
        }

        public Abonement getByPersonId(int? id)
        {
            return context.Abonements.OrderByDescending(x => x.id).FirstOrDefault(x => x.PersonId == id);
        }

    }
}
