using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLib.Models;

namespace TodoLib.Services.Tests
{
    [TestClass()]
    public class TodosRepositoryTests
    {
        private TodosRepository _repository;

        [TestMethod()]
        public void TodosRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }
        
        [TestMethod()]
        [DataRow(7)]
        public async Task ReadTest(int id)
        {
            var item = await _repository.Read(id);

            var expected = item.TodoId;

            var actualResult = id;

            Assert.AreEqual(expected, actualResult);
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }
    }
}