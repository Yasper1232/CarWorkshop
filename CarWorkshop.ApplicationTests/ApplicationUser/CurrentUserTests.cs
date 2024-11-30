using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWorkshop.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshop.Application.ApplicationUser.Tests
{
    [TestClass()]
    public class CurrentUserTests
    {
        [TestMethod()]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            
            //arrange

            var currentuser = new CurrentUser("1","test@test.com",new List<string> { "Admin","User" });

            //act 
            var isInRole = currentuser.IsInRole("Admin");

            //assert

            isInRole.Should().BeTrue();

        }

        [TestMethod()]
        public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
        {

            //arrange

            var currentuser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            //act 
            var isInRole = currentuser.IsInRole("admin");

            //assert

            isInRole.Should().BeFalse();

        }

        [TestMethod()]
        public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
        {
            
            //arrange

            var currentuser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            //act 
            var isInRole = currentuser.IsInRole("Moderator");

            //assert

            isInRole.Should().BeFalse();

        }


    }
}