using Gifter.Models;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        List<Comment> GetCommentsByPostId(int id);
    }
}