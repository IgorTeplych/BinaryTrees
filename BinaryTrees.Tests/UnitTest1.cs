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

        }
    }
}