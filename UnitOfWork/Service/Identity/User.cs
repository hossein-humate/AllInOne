using DataAccess.DbContext;
using System;
using System.Linq;
using UnitOfWork.Repository;
using Utility.Helpers;

namespace UnitOfWork.Service.Identity
{
    public class User : Repository<Model.Entity.Identity.User>, IUser
    {
        public User(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public Model.Entity.Identity.User IsValidUser(string username, string password)
        {
            try
            {
                var user = Get().FirstOrDefault(u => u.Username == username && u.IsActive);
                if (user == null)
                {
                    return null;
                }

                return !Cryptography.CheckValidInput(password, user.PasswordHash, user.PasswordSalt) ? null : user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public interface IUser : IRepository<Model.Entity.Identity.User>
    {
        Model.Entity.Identity.User IsValidUser(string username, string password);
    }
}