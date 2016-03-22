using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class PerformanceComparisonTests
    {
        [Test]
        public void GivenTreeBasedAndSimpleCompleters_WhenLookupCalled_TreeBasedShouldBeFaster()
        {
            var testData = new PostOfficeDataFile();

            var treeBasedPostOfficeNameCompleter = new TreeBasedPostOfficeNameCompleter(testData.Read());
            var timeForTreeBasedLookup = Time(() => treeBasedPostOfficeNameCompleter.SuggestCompletedNames("Acha"));

            var simplePostOfficeNameCompleter = new SimplePostOfficeNameCompleter(testData.Read());
            var timeForSimpleLookup = Time(() => simplePostOfficeNameCompleter.SuggestCompletedNames("Acha"));
            
            Console.WriteLine("Simple lookup took {0}", timeForSimpleLookup);
            Console.WriteLine("Tree based lookup took {0}", timeForTreeBasedLookup);
            Assert.That(timeForSimpleLookup, Is.GreaterThan(timeForTreeBasedLookup));
        }

        private TimeSpan Time(Func<IEnumerable<string>> timedAction)
        {
            var startTime = DateTime.Now;
            var result = timedAction().ToList();
            return DateTime.Now - startTime;
        }
    }
}