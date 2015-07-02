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
//        static Mock<IDatabaseContext> _mockDbContext = new Mock<IDatabaseContext>();
//        UserStore _userStore = new UserStore(_mockDbContext.Object);

//        [SetUp]
        public void CreateMockObject()
        {

            var mockDbContext = new Mock<IDatabaseContext>();
            var mockDbSetUser = new Mock<DbSet<User>>();
            mockDbSetUser.Setup(x => x.Find(1)).Returns(new User
            {
                Id = 1
            });

            mockDbContext.Setup(x => x.Users).Returns(mockDbSetUser.Object);

        }

        [Test]
        public void CheckAddUser()
        {

            var data = new List<User> 
            { 
                new User { Id = 1 }, 
                new User { Id = 2 }, 
                new User { Id = 3 }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IDatabaseContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object); 

            var userStore = new UserStore(mockContext.Object);


            var user = new User
            {
                Id = 2
            };

            userStore.AddUser(user);
            var result = userStore.GetById(2);

            Assert.IsNotNull(result);

        }
    }
}
