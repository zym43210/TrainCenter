using System.Collections.Generic;
using System.Linq;
using TrainCenter.Model;

namespace TrainCenter.Repositories
{
    internal class EFUserRepository : IUserRepository
    {
        private TrainCenterEntities2 context;

        public EFUserRepository()
        {
            context = new TrainCenterEntities2();
        }
        public List<string> getAllNames()
        {
            List<string> tmp = new List<string>();
            foreach (User s in context.Users)
            {
                tmp.Add(s.getName());
            }

            return tmp;
        }
        public IEnumerable<User> getAllMails()
        {
            return context.Users.Where(x => x.privilege == "user").ToList();

        }
        public IEnumerable<User> getAll()
        {
            return context.Users;
        }
        public void add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void delete(User user)
        {
            context.Users.Remove(context.Users.FirstOrDefault(x => x.id == user.id));
            context.SaveChanges();
        }
        public User getByMail(string mail)
        {
            return context.Users.FirstOrDefault(x => x.mail == mail);
        }
        public User getByName(string name)
        {
            return context.Users.FirstOrDefault(x => (x.firstName + " " + x.secondName) == name);
        }
        public User getById(int? id)
        {
            return context.Users.FirstOrDefault(x => x.id == id);
        }
        public void update(User oldUser, User newUser)
        {
            var tmp = context.Users.FirstOrDefault(x => x.id == oldUser.id);

            if (tmp != null)
            {
                tmp.firstName = newUser.firstName;
                tmp.secondName = newUser.secondName;
                tmp.mail = newUser.mail;
                tmp.about = newUser.about;
                tmp.image = newUser.image;
                tmp.telNumber = newUser.telNumber;
            }
            context.SaveChanges();
        }
        public void changePrivelege(User user, string privelege)
        {
            var tmp = context.Users.FirstOrDefault(x => x.id == user.id);
            if (tmp != null)
            {
                tmp.privilege = privelege;
            }

            context.SaveChanges();
        }
    }
}
