using System;
using System.Linq;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class SimplePostOfficeNameCompleterTest
    {
        [Test]
        public void GivenPostOfficeName_WhenSimplePostOfficeNameCompleterCalled_ShouldReturnMatchingPostOffices()
        {
            var postOfficefinder = new SimplePostOfficeNameCompleter();
            var listOfMatchingOfficeNames = postOfficefinder.SuggestCompletedNames("Abusa");

            Assert.That(listOfMatchingOfficeNames.First(), Is.EqualTo("Abusar B.O"));
        }
        
    }
}
