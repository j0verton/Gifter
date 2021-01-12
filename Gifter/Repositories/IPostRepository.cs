using Gifter.Models;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        Post GetById(int id);
        List<Post> GetByUserProfileId(int id);
        List<Post> Hottest(DateTime since);
        List<Post> Search(string q, bool reverseOrder);
        void Update(Post post);
    }
}