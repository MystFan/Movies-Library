namespace MoviesLibrary.Web.Tests.CustomAttributesTests
{
    using System.Collections.Generic;
    using System.Web;

    using Moq;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;
    using NUnit.Framework;

    
    public class CollectionCountTersts
    {
        private CollectionCount attribute;

        [TestFixtureSetUp]
        public void SetupTests()
        {
            this.attribute = new CollectionCount();
        }

        [Test]
        public void WithoutItemsShouldReturnFalse()
        {
            Assert.IsFalse(this.attribute.IsValid(new List<object>() { }));
        }

        [Test]
        public void WithoutMinCountAndMaxCountShouldWorkCorrectly()
        {
            Assert.IsTrue(this.attribute.IsValid(new List<object>() { string.Empty }));
        }

        [Test]
        public void WithMinCountAndMaxCountShouldWorkCorrectly()
        {
            this.attribute.MinCount = 1;
            this.attribute.MaxCount = 3;

            Assert.IsTrue(this.attribute.IsValid(new List<object>() { string.Empty, string.Empty }));
        }

        [Test]
        public void WithInvalidItemsCountShouldReturnFalse()
        {
            this.attribute.MinCount = 3;
            this.attribute.MaxCount = 3;

            Assert.IsFalse(this.attribute.IsValid(new List<object>() { string.Empty, string.Empty }));
        }

        [Test]
        public void WithValidItemsCountShouldReturnTrue()
        {
            this.attribute.MinCount = 1;
            this.attribute.MaxCount = 3;

            Assert.IsTrue(this.attribute.IsValid(new List<object>() { string.Empty, string.Empty }));
        }
    }
}
