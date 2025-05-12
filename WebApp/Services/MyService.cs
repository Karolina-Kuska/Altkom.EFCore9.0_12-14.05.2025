using DAL;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services
{
    public class MyService
    {
        private DbContext _context;
        public MyService(DbContext context)
        {
            _context = context;
        }
    }
}
