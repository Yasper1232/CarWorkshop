using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    [TestClass()]
    public class CarWorkshopTests
    {
        [TestMethod()]
        public void EncodeName_ShouldSetEncodedName()
        {
            //arrange
          var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            //act

            carWorkshop.EncodeName();

            //assert

            carWorkshop.EncodedName.Should().Be("test-workshop");

        }

        [TestMethod()]
public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            var carWorkshop = new CarWorkshop();

           Action action = () => carWorkshop.EncodeName();

            action.Invoking(a=>a.Invoke())
                .Should().Throw<NullReferenceException>();

        }




    }
}