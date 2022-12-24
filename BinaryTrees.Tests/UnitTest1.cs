namespace BinaryTrees.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void InsertInTrees()
        {
            BinaryTrees.SimpleTrees simpleTrees = new BinaryTrees.SimpleTrees(10);
            simpleTrees.Insert(4);
            simpleTrees.Insert(12);
            simpleTrees.Insert(14);
            simpleTrees.Insert(11);
            Assert.AreEqual(simpleTrees.Root.Left.Key, 4);
            Assert.AreEqual(simpleTrees.Root.Right.Key, 12);
            Assert.AreEqual(simpleTrees.Root.Right.Right.Key, 14);
            Assert.AreEqual(simpleTrees.Root.Right.Left.Key, 11);
        }
        [Test]
        public void SearchInTrees()
        {
            BinaryTrees.SimpleTrees simpleTrees = new BinaryTrees.SimpleTrees(10);
            simpleTrees.Insert(4);
            simpleTrees.Insert(12);
            simpleTrees.Insert(14);
            simpleTrees.Insert(11);
            simpleTrees.Insert(18);
            simpleTrees.Insert(20);
            simpleTrees.Insert(102);

            Assert.AreEqual(simpleTrees.Search(102), true);

            Assert.AreEqual(simpleTrees.Search(21), false);
        }

        [Test]
        public void RemoveNodeWithoutChild()
        {
            BinaryTrees.SimpleTrees simpleTrees = new BinaryTrees.SimpleTrees(10);
            simpleTrees.Insert(4);
            simpleTrees.Insert(12);
            simpleTrees.Insert(14);
            simpleTrees.Insert(11);
            simpleTrees.Insert(18);
            simpleTrees.Insert(20);
            simpleTrees.Insert(102);

            Assert.AreEqual(simpleTrees.Search(4), true);
            Assert.AreEqual(simpleTrees.Search(12), true);
            Assert.AreEqual(simpleTrees.Search(14), true);
            Assert.AreEqual(simpleTrees.Search(11), true);
            Assert.AreEqual(simpleTrees.Search(18), true);
            Assert.AreEqual(simpleTrees.Search(20), true);
            Assert.AreEqual(simpleTrees.Search(102), true);

            simpleTrees.Remove(4);

            Assert.AreEqual(simpleTrees.Search(4), false);
            Assert.AreEqual(simpleTrees.Search(12), true);
            Assert.AreEqual(simpleTrees.Search(14), true);
            Assert.AreEqual(simpleTrees.Search(11), true);
            Assert.AreEqual(simpleTrees.Search(18), true);
            Assert.AreEqual(simpleTrees.Search(20), true);
            Assert.AreEqual(simpleTrees.Search(102), true);
        }
        [Test]
        public void RemoveNodeWithoutOneChild()
        {
            BinaryTrees.SimpleTrees simpleTrees = new BinaryTrees.SimpleTrees(10);
            simpleTrees.Insert(4);
            simpleTrees.Insert(12);
            simpleTrees.Insert(14);
            simpleTrees.Insert(11);
            simpleTrees.Insert(18);
            simpleTrees.Insert(20);
            simpleTrees.Insert(102);

            Assert.AreEqual(simpleTrees.Search(4), true);
            Assert.AreEqual(simpleTrees.Search(12), true);
            Assert.AreEqual(simpleTrees.Search(14), true);
            Assert.AreEqual(simpleTrees.Search(11), true);
            Assert.AreEqual(simpleTrees.Search(18), true);
            Assert.AreEqual(simpleTrees.Search(20), true);
            Assert.AreEqual(simpleTrees.Search(102), true);

            simpleTrees.Remove(14);

            Assert.AreEqual(simpleTrees.Search(4), true);
            Assert.AreEqual(simpleTrees.Search(12), true);
            Assert.AreEqual(simpleTrees.Search(14), false);
            Assert.AreEqual(simpleTrees.Search(11), true);
            Assert.AreEqual(simpleTrees.Search(18), true);
            Assert.AreEqual(simpleTrees.Search(20), true);
            Assert.AreEqual(simpleTrees.Search(102), true);
        }
    }
}