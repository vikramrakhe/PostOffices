using System.Collections.Generic;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class PostOfficeNameCompletionTests
    {
        private static string s_AchalPur = "Achalpur B.O";
        private static string s_AchalPurCity = "Achalpur City S.O";
        private static string s_Achalu = "Achalu";

        [Test]
        public void WhenCompletionCalledWithEmptyString_ShouldReturnEmptySet()
        {
            var testData = new List<string> {s_AchalPur, s_AchalPurCity, s_Achalu};
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames(string.Empty);
            Assert.That(completions, Is.EquivalentTo(new List<string>()));
        }

        [Test]
        public void GivenAllPOsStartWithAchal_WhenCompletionForAchal_ShouldReturnAllPostOffices()
        {
            var testData = new List<string> {s_AchalPur, s_AchalPurCity, s_Achalu};
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames("Achal");
            Assert.That(completions, Is.EquivalentTo(new [] {"pur B.O", "pur City S.O", "u"}));
        }

        [Test]
        public void GivenTwoPOsWithTheSamename_WhenCompletionRequested_ShouldNotReturnDuplicateName()
        {
            var testData = new List<string> { s_AchalPur, s_AchalPur };
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames("Achal");
            Assert.That(completions, Is.EquivalentTo(new[] { "pur B.O" }));
        }

    }
}