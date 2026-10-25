using System;
using Core.Extensions;
using NUnit.Framework;

namespace HomeAssignment.Tests.EditMode
{
    public class ListExtensionsTests
    {
        [Test]
        public void GetRandomUniqueElements_ReturnsRequestedCountOfDistinctSourceElements()
        {
            var source = new[] { 1, 2, 3, 4, 5 };

            var result = source.GetRandomUniqueElements(3, new Random(0));

            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result, Is.Unique);
            Assert.That(result, Is.SubsetOf(source));
        }

        [Test]
        public void GetRandomUniqueElements_CountAboveSourceSize_ReturnsAllElements()
        {
            var source = new[] { 1, 2, 3 };

            var result = source.GetRandomUniqueElements(10, new Random(0));

            Assert.That(result, Is.EquivalentTo(source));
        }

        [Test]
        public void GetRandomUniqueElements_DoesNotModifySource()
        {
            var source = new[] { 1, 2, 3, 4, 5 };

            source.GetRandomUniqueElements(3, new Random(0));

            Assert.That(source, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
        }
    }
}
