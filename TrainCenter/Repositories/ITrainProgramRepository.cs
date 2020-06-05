using System.Collections.Generic;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    public interface ITrainProgramRepository
    {
        IEnumerable<TrainProgram> getAll();
        void delete(TrainProgram TrainProgram);
        void add(TrainProgram TrainProgram);
        TrainProgram getByText(string text);
        IEnumerable<TrainProgram> getByPersonId(int id);

    }
}
