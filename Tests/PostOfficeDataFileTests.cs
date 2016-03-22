using System.Linq;
using NUnit.Framework;
using PostOffices;

namespace Tests
{
    public class PostOfficeDataFileTests
    {
        [Test]
        public void GivenPostOfficeDataFile_WhenReadCalled_ShouldReadDataOnOver1500000PostOffices()
        {
            var file = new PostOfficeDataFile();
            var postOffices = file.Read();
            Assert.That(postOffices.Count(), Is.GreaterThan(150000));
        }

        [Test]
        public void GivenPostOfficeDataFile_WhenReadCalled_FirstItemShouldHaveCorrectName()
        {
            var file = new PostOfficeDataFile();
            var postOffices = file.Read();
            var firstPostOffice = postOffices.First();
            Assert.That(firstPostOffice.Name, Is.EqualTo("(Gandhinagar) Sector 16 S.O"));
        }
    }
}
