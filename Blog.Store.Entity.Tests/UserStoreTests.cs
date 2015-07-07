using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using Moq;
using NUnit.Framework;

namespace Blog.Store.Entity.Tests
{
    [TestFixture]
    public class UserStoreTests
    {
        [Test]
        public void Check_GetById()
        {

            var post = new Post
            {
                Id = 1
            };
            var postDbSetMock = new Mock<DbSet<Post>>();
            postDbSetMock.Setup(x => x.Find(1))
                .Returns(post);

            var databaseContextMock = new Mock<IDatabaseContext>();
            databaseContextMock.Setup(x => x.Set<Post>())
                .Returns(postDbSetMock.Object);

            var postStore = new PostStore(databaseContextMock.Object);

            var result = postStore.GetById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(post, result);

        }
    }
}
