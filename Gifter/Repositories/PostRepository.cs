﻿using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.DateCreated)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post
                .Include(p => p.UserProfile)
                                .FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetByUserProfileId(int id)
        {
            return _context.Post.Include(p => p.UserProfile)
                            .Where(p => p.UserProfileId == id)
                            .OrderBy(p => p.Title)
                            .ToList();
        }

        public void Add(Post post)
        {
            try { 
            _context.Add(post);
            _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
                
            }
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = GetById(id);
            _context.Post.Remove(post);
            _context.SaveChanges();
        }

        
        public List<Post> Search(string q, bool reverseOrder)
        {
            var query = _context.Post
                .Where(p => p.Title.Contains(q) || p.Caption.Contains(q));

            if (reverseOrder == true)
            {
                return query.OrderBy(p => p.DateCreated).ToList();
            }
            else
            {
                return query.OrderByDescending(p => p.DateCreated).ToList();
            }
        }

        
        public List<Post> Hottest(DateTime since)
        {
            
            return _context.Post.Where(p => p.DateCreated > since).ToList();
        }
    }
}
