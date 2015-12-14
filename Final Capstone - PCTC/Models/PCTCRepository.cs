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
    }
}