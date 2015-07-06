using Models;

namespace Blog.IStore
{
    public interface IPostStore
    {
        void AddPost(Post user);
        void EditPost(Post post, int id);
        void RemovePost(int id);
        Post GetLastPost();
    }
}