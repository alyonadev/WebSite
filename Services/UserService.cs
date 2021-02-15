using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebSite.Models;
using WebSite.Repository;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(User item)
        {
            _userRepository.Add(item);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

        public User FirstOrDefault(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.FirstOrDefault(predicate);
        }

        public User FirstOrDefault()
        {
            return _userRepository.FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User item)
        {
            _userRepository.Update(item);
        }

        public byte[] GetPhoto(HttpPostedFileBase photoFile)
        {
            return _userRepository.GetPhoto(photoFile);
        }


    }
}
