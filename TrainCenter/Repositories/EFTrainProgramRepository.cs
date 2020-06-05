using System.Collections.Generic;
using System.Linq;
using TrainCenter.Model;


namespace TrainCenter.Repositories
{
    class EFTrainProgramRepository : ITrainProgramRepository
    {
        private TrainCenterEntities2 context;

        public EFTrainProgramRepository()
        {
            context = new TrainCenterEntities2();
        }
        public EFTrainProgramRepository(TrainCenterEntities2 context)
        {
            this.context = context;
        }
        public IEnumerable<TrainProgram> getAll()
        {
            return context.TrainPrograms;
        }
        public void update(TrainProgram TrainProgram,bool isDone)
        {
            var tmp = context.TrainPrograms.FirstOrDefault(x => x.id == TrainProgram.id);

            if (tmp != null)
            {
                tmp.IsDone = isDone;
            }
            context.SaveChanges();
        }
        public void delete(TrainProgram TrainProgram)
        {
            context.TrainPrograms.Remove(context.TrainPrograms.FirstOrDefault(x => x.id == TrainProgram.id));
            context.SaveChanges();
        }
        public void add(TrainProgram TrainProgram)
        {
            context.TrainPrograms.Add(TrainProgram);
            context.SaveChanges();
        }
        public TrainProgram getByText(string text)
        {
            return context.TrainPrograms.FirstOrDefault(x => x.Text == text);
        }
        public IEnumerable<TrainProgram> getByPersonId(int personID)
        {
            return context.TrainPrograms.Where(x => x.PersonId == personID).ToList();
        }



    }
}
