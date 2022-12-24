using BinaryTrees;
using System.Diagnostics;

static class Programm
{
    public static void Main()
    {
        int N = 30000;
        BinaryTrees.SimpleTrees simpleTreesRnd = new BinaryTrees.SimpleTrees(N);

        int[] rndNum = GetRandomNumbers(N);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            simpleTreesRnd.Insert(rndNum[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в дерево неупорядоченных чисел от 0 до {N} занимает: {sw.ElapsedMilliseconds} мс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < (N / 10); i++)
        {
            bool searh = simpleTreesRnd.Search(random.Next(1, int.MaxValue));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в неупорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedMilliseconds} мс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < (N / 10); i++)
        {
            simpleTreesRnd.Remove(random.Next(1, int.MaxValue));
        }
        sw.Stop();
        Console.WriteLine($"Удаление в неупорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedMilliseconds} мс.");

        Console.WriteLine();

        BinaryTrees.SimpleTrees simpleTreesOrder = new BinaryTrees.SimpleTrees(N);
        int[] orderNum = GetOrderNumbers(N);
        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
          simpleTreesOrder.Insert(orderNum[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в дерево упорядоченных по возрастанию чисел от 0 до {N} занимает: {sw.ElapsedMilliseconds} мс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
           bool searh = simpleTreesOrder.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в упорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedMilliseconds} мс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            simpleTreesOrder.Remove(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Удаление в упорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedMilliseconds} мс.");
    }


    static Random random = new Random();
    static int[] GetRandomNumbers(int N)
    {
        int[] mass = new int[N];
        for (int i = 0; i < N; i++)
        {
            if (i != N)
                mass[i] = random.Next(1, int.MaxValue);
        }
        return mass;
    }

    static int[] GetOrderNumbers(int N)
    {
        int[] mass = new int[N];
        for (int i = 1; i < N; i++)
        {
            if (i != N)
                mass[i] = i;
        }
        return mass;
    }
}
