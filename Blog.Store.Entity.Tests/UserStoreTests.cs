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
            var userDbSetMock = new Mock<DbSet<User>>();
            userDbSetMock.Setup(x => x.Find(1))
                .Returns(_mockObject.User);

            _databaseContextMock = new Mock<IDatabaseContext>();
            _databaseContextMock.Setup(x => x.Set<User>())
                .Returns(userDbSetMock.Object);
        }

        [Test]
        public void Check_AddUser()
        {
            var editUser = new User { UserName = "new"};
            var userStore = new UserStore(_databaseContextMock.Object);
            userStore.EditUser(editUser, 1);

            var result = userStore.GetById(1);

            Assert.AreEqual("new", result.UserName);

        }
    }
}