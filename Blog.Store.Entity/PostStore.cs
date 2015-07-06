using System.Linq;
using Blog.IStore;
using Models;

namespace Blog.Store.Entity
{
    public class PostStore : GenericRepository<Post>, IPostStore
    {


        public PostStore(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public void AddPost(Post post)
        {
            Add(post);
        }

        public void EditPost(Post post, int id)
        {
            var editPost = EntityDbSet.Find(id);
            editPost.Title = post.Title;
            editPost.Image = post.Image;
            editPost.Text = post.Text;
        }

        public void RemovePost(int id)
        {
            var deletedPost = EntityDbSet.Find(id);
            EntityDbSet.Remove(deletedPost);
        }

        public Post GetLastPost()
        {
            return EntityDbSet.Last();
        }
    }
}