namespace MoviesLibrary.Web.Tests.CustomAttributesTests
{
    using System.Collections.Generic;
    using System.Web;

    using Moq;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;
    using NUnit.Framework;

    [TestFixture]
    public class FileExtensionAttributeTests
    {
        private FileExtension attribute;

        [TestFixtureSetUp]
        public void SetupTests()
        {
            this.attribute = new FileExtension();
        }

        [Test]
        public void WithoutExtensionsToCompareShouldReturnTrue()
        {
            this.attribute.FileExtensions = new string[] { };

            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object }));
        }

        [Test]
        public void WithValidExtensionsToCompareShouldReturnTrue()
        {
            this.attribute.FileExtensions = new string[] { ".png", ".jpg" };

            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var jpgMock = new Mock<HttpPostedFileBase>();
            jpgMock.Setup(i => i.FileName).Returns("image.jpg");

            Assert.IsTrue(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, jpgMock.Object }));
        }

        [Test]
        public void WithInvalidExtensionToCompareShouldReturnFalse()
        {
            this.attribute.FileExtensions = new string[] { ".png", ".jpg" };

            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            var txtMock = new Mock<HttpPostedFileBase>();
            txtMock.Setup(i => i.FileName).Returns("image.txt");

            Assert.IsFalse(this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object, txtMock.Object }));
        }

        [Test]
        public void WithoutErrorMessageShouldReturnDefault()
        {
            this.attribute.FileExtensions = new string[] { ".jpg" };

            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            this.attribute.ErrorMessage = null;
            this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object });

            Assert.AreEqual("File is not in a supported format.", this.attribute.ErrorMessage);
        }

        [Test]
        public void WithErrorMessageShouldReturned()
        {
            this.attribute.FileExtensions = new string[] { ".jpg" };

            var pngMock = new Mock<HttpPostedFileBase>();
            pngMock.Setup(i => i.FileName).Returns("image.png");

            string message = "File is not in a supported format. Allowed formats: .jpg";
            this.attribute.IsValid(new List<HttpPostedFileBase>() { pngMock.Object });
            this.attribute.ErrorMessage = message;

            Assert.AreEqual(message, this.attribute.ErrorMessage);
        }
    }
}
