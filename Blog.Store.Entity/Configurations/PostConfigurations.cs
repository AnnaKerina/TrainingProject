using System.Data.Entity.ModelConfiguration;
using Models;

namespace Blog.Store.Entity.Configurations
{
    public class PostConfigurations : EntityTypeConfiguration<Post>
    {
        public PostConfigurations()
        {
            HasRequired(x => x.User);
            HasMany(x => x.Comments);
        }

    }
}