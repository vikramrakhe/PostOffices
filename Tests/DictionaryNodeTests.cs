using NUnit.Framework;

namespace Tests
{
    public class DictionaryNodeTests
    {
        [Test]
        public void GivenDictionaryNode_WhenAddCalled_ShouldFindNode()
        {
            var root = new DictionaryNode();
            root.Add("a");
            var aNode = root.Find("a");
            Assert.That(aNode, Is.Not.Null);
        }
    }
}