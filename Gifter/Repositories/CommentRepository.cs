using Gifter.Data;
using Gifter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetAll()
        {
            return _context.Comment
                .Include(c => c.UserProfile)
                .Include(c => c.Post)
                .ToList();
        }

        public List<Comment> GetCommentsByPostId(int id)
        {
            return _context.Comment
                .Include(c => c.UserProfile)
                .Include(c => c.Post)
                .Where(c => c.PostId == id)
                .ToList();
        }

        public Comment 

    }
}
