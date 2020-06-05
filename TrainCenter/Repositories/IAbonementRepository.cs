using System;
using System.Collections.Generic;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    public interface IAbonementRepository
    {
        IEnumerable<Abonement> getAll();
        void add(Abonement user);
        void delete(Abonement user);
        Abonement getByEndDate(DateTime date);
        Abonement getByPersonId(int? id);
        IEnumerable<Abonement> getManyByPersonId(int id);


    }
}
