using BinaryTrees;

static class Programm
{
    public static void Main()
    {
        int count = 0;
        SimpleTrees simpleTrees = new SimpleTrees(9);

        simpleTrees.Insert(6);
        simpleTrees.Insert(8);
        simpleTrees.Insert(3);
        simpleTrees.Insert(7);
        simpleTrees.Insert(4);
        simpleTrees.Insert(2);
        simpleTrees.Insert(5);
        simpleTrees.Insert(1);

        simpleTrees.Insert(17);
        simpleTrees.Insert(16);
        simpleTrees.Insert(20);
        simpleTrees.Insert(12);
        simpleTrees.Insert(11);
        simpleTrees.Insert(14);
        simpleTrees.Insert(10);
        simpleTrees.Insert(13);
        simpleTrees.Insert(15);
        simpleTrees.Insert(19);
        simpleTrees.Insert(18);


        simpleTrees.Insert(21);
        var isSearch = simpleTrees.Search(17);

        simpleTrees.Remove(17);

        isSearch = simpleTrees.Search(18);

        var isSearchDel = simpleTrees.Search(17);

        var vr = simpleTrees.Root;
    }
}
