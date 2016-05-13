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
        public void WithoutFilesShouldReturnTrue()
        {
            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { null, null }));
        }

        [TestCase(120000, 500000, ImageValidations.MinContentLength, ImageValidations.MaxContentLength)]
        [TestCase(120000, 500000, 0, 0)]
        public void MinSizeAndMaxSizeShouldWorkCorrectly(int pngSize, int jpgSize, int minSize, int maxSize)
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(png => png.ContentLength).Returns(pngSize);
            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(jpg => jpg.ContentLength).Returns(jpgSize);

            this.attribute.MinSize = minSize;
            this.attribute.MaxSize = maxSize;

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object, null }));
        }

        [TestCase(ImageValidations.MinContentLength - 1)]
        [TestCase(ImageValidations.MaxContentLength + 1)]
        public void WithInvalidFileSizeFilesCountShouldReturnFalse(int size)
        {
            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(png => png.ContentLength).Returns(size);
            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(jpg => jpg.ContentLength).Returns(size);

            this.attribute.MinSize = ImageValidations.MinContentLength;
            this.attribute.MaxSize = ImageValidations.MaxContentLength;

            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object, null }));
        }
    }
}
