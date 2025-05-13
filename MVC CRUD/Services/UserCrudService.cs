using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Services
{
    public class UserCrudService
    {
        private readonly MVCCRUDDBContext _context;

        public UserCrudService()
        {
            _context = new MVCCRUDDBContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public bool ExistsUser(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
        public bool CreateUser(User user)
        {
            if (!ExistsUser(user.Id))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditUser(User user)
        {
            if (!ExistsUser(user.Id))
            {
                return false;
            }
            var data = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            if (data != null)
            {
                data.PhoneNo = user.PhoneNo;
                data.LastName = user.LastName;
                data.FirstName = user.FirstName;
                data.Email = user.Email;
                data.Gender = user.Gender;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false; 
            }
        }
        public bool DeleteUser(int id)
        {
            var data = GetById(id);
            if (data != null)
            {
                _context.Users.Remove(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}