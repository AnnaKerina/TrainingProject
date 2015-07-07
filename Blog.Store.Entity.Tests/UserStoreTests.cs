using System.Data.Entity;
using Models;
using Moq;
using NUnit.Framework;

namespace Blog.Store.Entity.Tests
{
    [TestFixture]
    public class UserStoreTests
    {

        private Mock<IDatabaseContext> _databaseContextMock;
        private readonly MockRepository _mockObject = new MockRepository();

        [SetUp]
        public void SetUp()
        {
            var postDbSetMock = new Mock<DbSet<Post>>();
            postDbSetMock.Setup(x => x.Find(1))
                .Returns(_mockObject.Post);

            _databaseContextMock = new Mock<IDatabaseContext>();
            _databaseContextMock.Setup(x => x.Set<Post>())
                .Returns(postDbSetMock.Object);
        }


        [Test]
        public void Check_GetById()
        {
            var postStore = new PostStore(_databaseContextMock.Object);

            var result = postStore.GetById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);

        }

        [Test]
        public void Check_AddPost()
        {
            var postStore = new PostStore(_databaseContextMock.Object);
            postStore.AddPost(_mockObject.Post);

            var result = postStore.GetById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
