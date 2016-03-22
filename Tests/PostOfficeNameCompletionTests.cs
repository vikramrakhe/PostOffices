using System.Collections.Generic;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class PostOfficeNameCompletionTests
    {
        [Test]
        public void WhenCompletionCalledWithEmptyString_ShouldReturnEmptySet()
        {
            var testData = new List<string>();
            var completer = new PostOfficeNameCompleter(testData);
            var completions = completer.SuggestCompletedNames(string.Empty);
            Assert.That(completions, Is.EquivalentTo(new List<string>()));
        }
    }
}