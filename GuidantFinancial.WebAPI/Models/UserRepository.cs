using GuidantFinancial.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuidantFinancial.WebAPI.Models
{
    public class UserRepository
    {
        private static List<User> _data = new List<User>()
        {
            new User { Id = 1, Name = "Will", Point = 8},
            new User { Id = 2, Name = "Jonh", Point = 8},
            new User { Id = 3, Name = "Joe", Point = 8}
        };

        public List<User> GetAll()
        {
            return _data;
        }

        public User Get(int Id)
        {
            try
            {
                var result = _data.FirstOrDefault(x => x.Id == Id);
                if (result != null)
                    return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public bool Add(User user)
        {
            try
            {
                user.Id = _data.Count + 1;
                _data.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool Update(User user)
        {
            try
            {
                var oldUser = Get(user.Id);
                if (oldUser != null)
                {
                    user.Name = oldUser.Name;
                    _data.Remove(oldUser);
                    _data.Add(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool IsExisted(string name)
        {
            try
            {
                var result = _data.FirstOrDefault(x => x.Name == name);
                if (result != null)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return false;
        }
    }
}