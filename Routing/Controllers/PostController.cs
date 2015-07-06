using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Blog.IStore;
using Blog.Store.Entity;
using Models;
using Routing.Models;

namespace Routing.Controllers
{
    public class PostController : Controller
    {
     
        private readonly IPostStore _postStore;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IPostStore postStore, IUnitOfWork unitOfWork)
        {
            _postStore = postStore;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(AddPostViewModel model)
        {
            var newPost = Mapper.Map<Post>(model);
            newPost.Comments = new List<Comment>();
            newPost.User = new User
            {
                Age = 10,
                Name = "Ivan",
                DateCreated = DateTime.UtcNow,
                Surname = "Ivanov",
                Summary = "IIIIIIII",
                Posts = new List<Post>()
            };
            _postStore.AddPost(newPost);
            _unitOfWork.Save();
            return RedirectToAction("ViewPosts", "Post");
        }

        public ActionResult ViewPosts()
        {
            var posts = _postStore.GetLastPost();
            var viewPost = Mapper.Map<ViewPostViewModel>(posts);
            return View(viewPost);
        }

    }
}
