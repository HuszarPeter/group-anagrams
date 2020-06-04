using System.Collections.Generic;
using System.Linq;
using GroupAnagrams;
using NUnit.Framework;

namespace GroupAnagramsTests
{
    public class AnagramsGrouperTest
    {
        private readonly AnagramsGrouper grouper = new AnagramsGrouper();

        [Test]
        public void ValidThreeGroupAllLowerCase()
        {
            var inputs = new List<string> {"eat", "tea", "tan", "ate", "nat", "bat"};
            var result = grouper.Group(inputs);

            var first = result.Where(current => current.Count == 1).SelectMany(flatten => flatten).ToList();
            first.Sort();
            var second = result.Where(current => current.Count == 2).SelectMany(flatten => flatten).ToList();
            second.Sort();
            var third = result.Where(current => current.Count == 3).SelectMany(flatten => flatten).ToList();
            third.Sort();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("bat", first.ElementAt(0));
            Assert.AreEqual("nat", second.ElementAt(0));
            Assert.AreEqual("tan", second.ElementAt(1));
            Assert.AreEqual("ate", third.ElementAt(0));
            Assert.AreEqual("eat", third.ElementAt(1));
            Assert.AreEqual("tea", third.ElementAt(2));
        }

        [Test]
        public void ValidThreeGroupSomeUpperCase()
        {
            var inputs = new List<string> {"Eat", "tea", "tan", "aTe", "nat", "bat"};
            var result = grouper.Group(inputs);

            var first = result.Where(current => current.Count == 1).SelectMany(flatten => flatten).ToList();
            first.Sort();
            var second = result.Where(current => current.Count == 2).SelectMany(flatten => flatten).ToList();
            second.Sort();
            var third = result.Where(current => current.Count == 3).SelectMany(flatten => flatten).ToList();
            third.Sort();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("bat", first.ElementAt(0));
            Assert.AreEqual("nat", second.ElementAt(0));
            Assert.AreEqual("tan", second.ElementAt(1));
            Assert.AreEqual("ate", third.ElementAt(0));
            Assert.AreEqual("eat", third.ElementAt(1));
            Assert.AreEqual("tea", third.ElementAt(2));
        }

        [Test]
        public void ValidOneGroup()
        {
            var inputs = new List<string> {"eat"};
            var result = grouper.Group(inputs);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(result.ElementAt(0).ElementAt(0), "eat");
        }

        [Test]
        public void NoGroup()
        {
            var inputs = new List<string>();
            var result = grouper.Group(inputs);
            Assert.AreEqual(0, result.Count);
        }
    }
}