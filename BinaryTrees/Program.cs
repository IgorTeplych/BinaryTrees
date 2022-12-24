using BinaryTrees;

static class Programm
{
    public static void Main()
    {
        BinaryTrees.SimpleTrees simpleTrees = new BinaryTrees.SimpleTrees(10);
        simpleTrees.Insert(4);
        simpleTrees.Insert(12);
        simpleTrees.Insert(14);
        simpleTrees.Insert(11);
        simpleTrees.Insert(18);
        simpleTrees.Insert(20);
        simpleTrees.Insert(102);

        simpleTrees.Remove(4);
    }
}
