using Gifter.Models;
using Gifter.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Gifter.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public PostController(IPostRepository postRepository, IUserProfileRepository userProfileRepository )
        {
            _postRepository = postRepository;
            _userProfileRepository = userProfileRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }

        [HttpGet("getbyuser/{id}")]
        public IActionResult GetByUserProfileId(int id)
        {
            return Ok(_postRepository.GetByUserProfileId(id));
        }


        [HttpPost]
        public IActionResult Add(Post post)
        {
            UserProfile CurrentUser = GetCurrentUserProfile();
            post.UserProfileId = CurrentUser.Id;
            post.DateCreated = DateTime.Now;
            _postRepository.Add(post);
            return Ok(post);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string q, bool reverseOrder)
        {
            {
                if (q == null)
                {
                    return Ok(_postRepository.GetAll());
                }

                var posts = _postRepository.Search(q, reverseOrder);
                return Ok(posts);
            }
        }
            [HttpGet("hottest")]
            public IActionResult Hottest(string since)
            {
            try
            {
                var startDate = DateTime.ParseExact(since, "M/d/yyyy", CultureInfo.InvariantCulture);
            var posts = _postRepository.Hottest(startDate);
            return Ok(posts);
            }
            catch
            {
                return BadRequest("please use M/d/yyyy format");
                
                }



        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

    }


}