using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class PCTCRepository
    {
        private PCTCContext _context;
        public PCTCContext Context { get { return _context; } }

        public PCTCRepository()
        {
            _context = new PCTCContext();
        }

        public PCTCRepository(PCTCContext a_context)
        {
            _context = a_context;
        }

        public List<PCTCUser> GetAllUsers()
        {
            var query = from users in _context.PCTCUsers select users;
            return query.ToList();
        }

        public PCTCUser GetUserByUserName(string username)
        {
            var query = from user in _context.PCTCUsers where user.UserName == username select user;
            // IQueryable<JitterUser> query = from user in _context.JitterUsers where user.Handle == handle select user;
            return query.SingleOrDefault();
        }

        public bool IsUserNameAvailable(string username)
        {
            bool available = false;
            try
            {
                PCTCUser some_user = GetUserByUserName(username);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException)
            {
                //Nothing needs to be coded here.
            }
            return available;
        }
    }
}