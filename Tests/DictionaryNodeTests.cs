using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class DictionaryTests
    {
        [Test]
        public void GivenDictionaryWithNodeAdded_WhenFindCalled_ShouldReturnNotNull()
        {
            var dictionary = new TreeBasedDictionary();
            dictionary.Add("a");
            var aNode = dictionary.Find("a");
            Assert.That(aNode, Is.Not.Null);
        }

        [Test]
        public void GivenEmptyDictionaryNode_WhenFindCalled_ShouldReturnNull()
        {
            var dictionary = new TreeBasedDictionary();
            var aNode = dictionary.Find("a");
            Assert.That(aNode, Is.Null);
        }

        [Test]
        public void GivenDictionaryWithNodeAddedForTwoCharWord_WhenFindCalledOnceOnEachChar_ShouldReturnSameNodeAsFindCalledOnceOnWholeWord()
        {
            var dictionary = new TreeBasedDictionary();
            dictionary.Add("an");
            var anNodeReachedBySingleCall = dictionary.Find("an");
            var anNodeReachedyTwoCalls = dictionary.Find("a").Find("n");

            Assert.That(anNodeReachedBySingleCall, Is.EqualTo(anNodeReachedyTwoCalls));
        }

        [Test]
        public void GivenDictionaryWithNodeAddedForWord_WhenWordsCalled_ShouldReturnTheWord()
        {
            var dictionary = new TreeBasedDictionary();
            dictionary.Add("an");
            var words = dictionary.Words();
            Assert.That(words, Is.EquivalentTo(new []{"an"}));
        }

        [Test]
        public void GivenDictionaryWithBluesAndBlues_WhenWordsCalled_ShouldReturnBothWords()
        {
            var dictionary = new TreeBasedDictionary();
            dictionary.Add("blues");
            dictionary.Add("blue");
            var words = dictionary.Words();
            Assert.That(words, Is.EquivalentTo(new[] { "blue", "blues" }));
        }

        [Test]
        public void GivenDictionaryWithGrayAndGreen_WhenWordsCalledBeginningWithGre_ShouldReturnOnly_en()
        {
            var dictionary = new TreeBasedDictionary();
            dictionary.Add("gray");
            dictionary.Add("green");
            var node = dictionary.Find("gre");
            var words = node.Words();
            Assert.That(words, Is.EquivalentTo(new[] { "en" }));
        }
    }
}