using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Tests.Defensive
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using nStuff.Core.Defensive;

    [TestClass]
    public class GuardDatesTests
    {
        [TestMethod]
        public void given_a_valid_positive_assertion_then_MinValue_should_pass()
        {
            FluentlyDefend
                .AssertThat()
                .AndThat
                .IsMinDate(DateTime.MinValue);
        }

        [TestMethod]
        public void given_a_valid_negative_assertion_then_MinValue_should_pass()
        {
            FluentlyDefend
                .AssertThat()
                .ButNotThat
                .IsMinDate(DateTime.Now);
        }

        [TestMethod]
        public void given_an_invalid_positive_assertion_then_MinValue_should_fail()
        {
            var threw = false;
            try
            {
                FluentlyDefend
                    .AssertThat()
                    .AndThat
                    .IsMinDate(DateTime.Now);
            }
            catch
            {
                threw = true;
            }
            Assert.IsTrue(threw);
        }

        [TestMethod]
        public void given_an_invalid_negative_assertion_then_MinValue_should_fail()
        {
            var threw = false;
            try
            {
                FluentlyDefend
                    .AssertThat()
                    .ButNotThat
                    .IsMinDate(DateTime.MinValue);
            }
            catch
            {
                threw = true;
            }
            Assert.IsTrue(threw);
        }
    }
}
