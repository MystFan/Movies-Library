namespace MoviesLibrary.Web.Tests.CustomAttributesTests
{
    using System.Collections.Generic;
    using System.Web;

    using Moq;
    using MoviesLibrary.Data.Common.Constants;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;
    using NUnit.Framework;

    [TestFixture]
    public class HttpFileContentLengthTests
    {
        private HttpFileContentLength attribute;

        [TestFixtureSetUp]
        public void SetupTests()
        {
            this.attribute = new HttpFileContentLength();
        }

        [Test]
        public void WithoutFilesShouldReturnFalse()
        {
            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { null }));
        }

        [TestCase(120000, 500000, MovieImageValidations.MinContentLength, MovieImageValidations.MaxContentLength)]
        [TestCase(120000, 500000, 0, 0)]
        public void MinSizeAndMaxSizeShouldWorkCorrectly(int pngSize, int jpgSize, int minSize, int maxSize)
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(png => png.ContentLength).Returns(pngSize);
            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(jpg => jpg.ContentLength).Returns(jpgSize);

            this.attribute.MinSize = minSize;
            this.attribute.MaxSize = maxSize;

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }

        [TestCase(99999)]
        [TestCase(500002)]
        public void WithInvalidFileSizeFilesCountShouldReturnFalse(int size)
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(png => png.ContentLength).Returns(size);
            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(jpg => jpg.ContentLength).Returns(size);

            this.attribute.MinSize = MovieImageValidations.MinContentLength;
            this.attribute.MaxSize = MovieImageValidations.MaxContentLength;

            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }
    }
}
