using System.Collections.Generic;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class SimplePostOfficeNameCompleterTests
    {
        private const string AchalPur = "Achalpur B.O";
        private const string AchalPurCity = "Achalpur City S.O";
        private const string Achalu = "Achalu";

        [Test]
        public void WhenCompletionCalledWithEmptyString_ShouldReturnEmptySet()
        {
            var testData = new List<string> {AchalPur, AchalPurCity, Achalu};
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames(string.Empty);
            Assert.That(completions, Is.EquivalentTo(new List<string>()));
        }

        [Test]
        public void GivenAllPOsStartWithAchal_WhenCompletionForAchal_ShouldReturnAllPostOffices()
        {
            var testData = new List<string> {AchalPur, AchalPurCity, Achalu};
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames("Achal");
            Assert.That(completions, Is.EquivalentTo(new [] {"pur B.O", "pur City S.O", "u"}));
        }

        [Test]
        public void GivenTwoPOsWithTheSamename_WhenCompletionRequested_ShouldNotReturnDuplicateName()
        {
            var testData = new List<string> { AchalPur, AchalPur };
            var completer = new SimplePostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames("Achal");
            Assert.That(completions, Is.EquivalentTo(new[] { "pur B.O" }));
        }
    }
}