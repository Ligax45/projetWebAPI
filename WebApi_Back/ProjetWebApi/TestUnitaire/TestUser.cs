using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjetWebApi.Controllers;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Models;
using ProjetWebApi.Services;

namespace TestUnitaire
{
    [TestClass]
    public class UtilisateurControllerTests
    {
        private UserController _controller;
        private DataContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new DataContext(options);

            SeedTestData();

            _controller = new UserController(_context);
        }

        private void SeedTestData()
        {
            var users = new[]
            {
                new User { Id = 1, Email = "test1@example.com", Password = "password1", Salt = "salt1" },
                new User { Id = 2, Email = "test2@example.com", Password = "password2", Salt = "salt2" }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        [TestMethod]
        public void TestCreateAndGetAllUtilisateur()
        {
            // CREATE
            UserModel model = new UserModel
            {
                Email = "newuser@example.com",
                Password = "password",
            };

            var createResult = _controller.CreateUser(model) as OkObjectResult;

            Assert.IsNotNull(createResult);
            Assert.AreEqual(200, createResult.StatusCode);

            var createdUser = _context.Users.SingleOrDefault(u => u.Email == "newuser@example.com");
            Assert.IsNotNull(createdUser);
            Assert.AreEqual("newuser@example.com", createdUser.Email);

            // READ
            var getAllResult = _controller.GetAllUsers() as OkObjectResult;
            Assert.IsNotNull(getAllResult);
            Assert.AreEqual(200, getAllResult.StatusCode);
        }

        // Test Update

        // Test Delete
    }
}