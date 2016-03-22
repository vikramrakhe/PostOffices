using System.Collections.Generic;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class PostOfficeNameCompletionTests
    {

        private static string s_AchalPur_MP = "Achalpur B.O";
        private static string s_AchalPur_RJ = "Achalpur B.O";
        private static string s_AchalPurCity = "Achalpur City S.O";
        private static string s_Achalu = "Achalu";

        [Test]
        public void WhenCompletionCalledWithEmptyString_ShouldReturnEmptySet()
        {
            var testData = new List<string> {s_AchalPur_MP, s_AchalPur_RJ, s_AchalPurCity, s_Achalu};
            var completer = new PostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames(string.Empty);
            Assert.That(completions, Is.EquivalentTo(new List<string>()));
        }

        [Test]
        public void GivenAllPOsStartWithAchal_WhenCompletionForAchal_ShouldReturnAllPostOffices()
        {
            var testData = new List<string> {s_AchalPur_RJ, s_AchalPurCity, s_Achalu};
            var completer = new PostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames("Achal");
            Assert.That(completions, Is.EquivalentTo(new [] {"pur B.O", "pur City S.O", "u"}));
        }
    }
}