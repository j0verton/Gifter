using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(up => up.Id == id);
        }

        public void Add(UserProfile up)
        {
            _context.Add(up);
            _context.SaveChanges();
        }

        public void Update(UserProfile up)
        {
            _context.Entry(up).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userprofile = GetById(id);
            _context.UserProfile.Remove(userprofile);
            _context.SaveChanges();
        }

    }
}
