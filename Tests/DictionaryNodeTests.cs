using NUnit.Framework;

namespace Tests
{
    public class DictionaryNodeTests
    {
        [Test]
        public void GivenDictionaryNodeWithNodeAdded_WhenFindCalled_ShouldReturnNotNull()
        {
            var root = new DictionaryNode();
            root.Add("a");
            var aNode = root.Find("a");
            Assert.That(aNode, Is.Not.Null);
        }

        [Test]
        public void GivenEmptyDictionaryNode_WhenFindCalled_ShouldReturnNull()
        {
            var root = new DictionaryNode();
            var aNode = root.Find("a");
            Assert.That(aNode, Is.Null);
        }

        [Test]
        public void GivenDictionaryNodeWithNodeAddedForTwoCharWord_WhenFindCalledOnceOnEachChar_ShouldReturnSameNodeAsFindCalledOnceOnWholeWord()
        {
            var root = new DictionaryNode();
            root.Add("an");
            var anNodeReachedBySingleCall = root.Find("an");
            var anNodeReachedyTwoCalls = root.Find("a").Find("n");

            Assert.That(anNodeReachedBySingleCall, Is.EqualTo(anNodeReachedyTwoCalls));
        }
    }
}