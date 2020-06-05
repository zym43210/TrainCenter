using System.Collections.Generic;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> getAll();
        IEnumerable<User> getAllMails();
        void add(User user);
        User getByMail(string name);
        User getById(int? id);
        void update(User oldUser, User newUser);
        List<string> getAllNames();
        void changePrivelege(User user, string privelege);
    }
}
