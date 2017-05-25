using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Tests.Defensive
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using nStuff.Core.Defensive;
    using nStuff.Core.Defensive.AssertionSets;
    using nStuff.Core.Defensive.Framework;

    [TestClass]
    public class FluentGuardTests
    {
        [TestMethod]
        public void given_a_valid_is_statement_then_the_assertion_should_pass_if_not_fluently_negated()
        {
            FluentlyDefend
                .AssertThat()
                .AndThat
                .IsMinDate(DateTime.MinValue);
        }

        [TestMethod]
        public void given_a_valid_is_statement_then_the_assertion_should_not_pass_if_it_is_fluently_negated()
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

        [TestMethod]
        public void sample_error_message_should_format_correctly_for_negated_mode()
        {
            var containedProperText = false;
            try
            {
                FluentlyDefend
                    .AssertThat()
                    .ButNotThat
                    .IsMinDate(DateTime.MinValue);
            }
            catch(Exception e)
            {
                containedProperText = e.Message.Contains("SHOULD NOT");
            }
            Assert.IsTrue(containedProperText);
        }

        [TestMethod]
        public void sample_error_message_should_format_correctly_for_positive_mode()
        {
            var containedProperText = false;
            try
            {
                FluentlyDefend
                    .AssertThat()
                    .AndThat
                    .IsMinDate(DateTime.Now);
            }
            catch (Exception e)
            {
                containedProperText = e.Message.Contains("SHOULD") && !e.Message.Contains("SHOULD NOT");
            }
            Assert.IsTrue(containedProperText);
        }


        [TestMethod]
        public void given_a_multi_level_set_of_partially_invalid_assertions_but_having_disabled_error_batching_then_the_first_error_only_should_present()
        {
            var containedProperText = false;
            try
            {
                FluentlyDefend
                    .AssertThat()
                    .IsMinDate(DateTime.Now)
                    .ButNotThat
                    .IsMinDate(DateTime.MaxValue)
                    .AndThat
                    .IsMaxDate(DateTime.MinValue);
            }
            catch (Exception)
            {
                containedProperText = true;
            }
            Assert.IsTrue(containedProperText);
        }

        [TestMethod]
        public void given_a_multi_level_set_of_partially_invalid_assertions_but_having_enabled_error_batching_but_never_calling_guard_should_not_do_anything()
        {
            var containedProperText = false;
            try
            {
                FluentlyDefend
                    .AssertThat(ValidationMode.Batched)
                    .IsMinDate(DateTime.Now)
                    .ButNotThat
                    .IsMinDate(DateTime.MaxValue)
                    .AndThat
                    .IsMaxDate(DateTime.MinValue);
            }
            catch (Exception)
            {
                containedProperText = true;
            }
            Assert.IsFalse(containedProperText);
        }


        [TestMethod]
        public void given_a_multi_level_set_of_partially_invalid_assertions_then_the_final_protection_should_include_all_errors_from_all_levels()
        {
            var containedProperText = false;
            AssertionSet assertionSet = null;
            try
            {
                assertionSet = 
                    FluentlyDefend
                        .AssertThat(ValidationMode.Batched);

                    assertionSet
                    .AndThat
                    .IsMinDate(DateTime.Now)
                    .ButNotThat
                    .IsMinDate(DateTime.MaxValue)
                    .AndThat
                    .IsMaxDate(DateTime.MinValue)
                    .Guard();
            }
            catch (Exception)
            {
                containedProperText = true;
                Assert.IsTrue(assertionSet.GetAllErrors().Count == 2);
            }
            Assert.IsTrue(containedProperText);
        }
    }
}
