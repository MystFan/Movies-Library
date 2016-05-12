namespace MoviesLibrary.Web.Tests.CustomAttributesTests
{
    using System.Collections.Generic;
    using System.Web;

    using Moq;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;
    using NUnit.Framework;

    [TestFixture]
    public class FilesCountAttrubuteTests
    {
        private FileCount attribute;

        [TestFixtureSetUp]
        public void SetupTests()
        {
            this.attribute = new FileCount();
        }

        [Test]
        public void WithoutFilesShouldReturnFalse()
        {
            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { null }));
        }

        [Test]
        public void WithoutMinCountAndMaxCountShouldWorkCorrectly()
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(i => i.FileName).Returns("image.jpg");

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }

        [Test]
        public void WithMinCountAndMaxCountShouldWorkCorrectly()
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(i => i.FileName).Returns("image.jpg");

            this.attribute.MinCount = 1;
            this.attribute.MaxCount = 3;

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }

        [Test]
        public void WithInvalidFilesCountShouldReturnFalse()
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(i => i.FileName).Returns("image.jpg");

            this.attribute.MinCount = 3;
            this.attribute.MaxCount = 3;

            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }

        [Test]
        [TestCase(1, 3)]
        [TestCase(0, 3)]
        public void WithValidFilesCountShouldReturnTrue(int min, int max)
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(i => i.FileName).Returns("image.jpg");

            this.attribute.MinCount = min;
            this.attribute.MaxCount = max;

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }
    }
}
