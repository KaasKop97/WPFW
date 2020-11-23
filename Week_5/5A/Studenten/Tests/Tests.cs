using System;
using Microsoft.AspNetCore.Mvc;
using Studenten.Controllers;
using Studenten.Data;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            var studentController = new StudentController();
            var result = studentController.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}