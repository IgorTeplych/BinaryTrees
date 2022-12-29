using BinaryTrees;
using System.Diagnostics;

static class Programm
{
    public static void Main()
    {
        UnOrdered();
        Ordered();
        AVLOrderedAndBalance();
        AVLNonOrderedAndBalance();
    }


    static void UnOrdered()
    {
        int N = 10000;
        Console.WriteLine();
        Console.WriteLine($"ТЕСТ ПРОСТОГО ДЕРЕВА С {N} НЕУПОРЯДОЧЕННЫМИ ЧИСЛАМИ");
        BinaryTrees.SimpleTrees simpleTreesRnd = new BinaryTrees.SimpleTrees(N);

        int[] rndNum = GetRandomNumbers(N);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            simpleTreesRnd.Insert(rndNum[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в дерево неупорядоченных чисел от 0 до {N} занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < (N / 10); i++)
        {
            bool searh = simpleTreesRnd.Search(random.Next(1, int.MaxValue));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в неупорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < (N / 10); i++)
        {
            simpleTreesRnd.Remove(random.Next(1, int.MaxValue));
        }
        sw.Stop();
        Console.WriteLine($"Удаление в неупорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");
    }
    static void Ordered()
    {
        int N = 10000;
        Console.WriteLine();
        Console.WriteLine($"ТЕСТ ПРОСТОГО ДЕРЕВА С {N} УПОРЯДОЧЕННЫМИ ЧИСЛАМИ");
        Stopwatch sw = new Stopwatch();
        BinaryTrees.SimpleTrees simpleTreesOrder = new BinaryTrees.SimpleTrees(N);
        int[] orderNum = GetOrderNumbers(N);
        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            simpleTreesOrder.Insert(orderNum[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в дерево упорядоченных по возрастанию чисел от 0 до {N} занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            bool searh = simpleTreesOrder.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в упорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            simpleTreesOrder.Remove(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Удаление в упорядоченном дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");
    }
    static void AVLOrderedAndBalance()
    {
        int N = 10000;
        Console.WriteLine();
        Console.WriteLine($"ТЕСТ АВЛ ДЕРЕВА С {N} УПОРЯДОЧЕННЫМИ ЧИСЛАМИ");
        //Формируем массив упорядоченнных по убыванию чисел
        int[] orderNum = GetOrderNumbers(N);
        //Создаем двоичное дерево АВЛ с корнем 10000
        AVLTrees aVLTrees = new AVLTrees(0);

        Stopwatch sw = new Stopwatch();
        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            aVLTrees.Insert(orderNum[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в АВЛ дерево упорядоченных по возрастанию чисел от 0 до {N} занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            bool searh = aVLTrees.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в несбалансированном АВЛ дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");

        //Балансируем правое поддерево
        aVLTrees.BalanceFactor = 1; //Устанавливаем фактор балансировки
        sw = new Stopwatch();
        sw.Start();
        Console.WriteLine($"Балансировка АВЛ дерева. Высота дерева до балансировки {aVLTrees.Root.Height}.");
        aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
        while (Math.Abs(aVLTrees.maxUnBalanceRoot.BalanceFactor) > aVLTrees.BalanceFactor)
        {
            aVLTrees.Rebalance(aVLTrees.maxUnBalanceRoot);
            aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
        }
        sw.Stop();
        Console.WriteLine($"Высота дерева после балансировки {aVLTrees.Root.Height}. Время балансировки: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            bool searh = aVLTrees.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в сбалансированном АВЛ дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");
    }
    static void AVLNonOrderedAndBalance()
    {
        int N = 10000;
        Console.WriteLine();
        Console.WriteLine($"ТЕСТ АВЛ ДЕРЕВА С {N} НЕУПОРЯДОЧЕННЫМИ ЧИСЛАМИ");
        //Формируем массив упорядоченнных по убыванию чисел
        int[] rndNums = GetRandomNumbers(N);
        //Создаем двоичное дерево АВЛ с корнем 10000
        AVLTrees aVLTrees = new AVLTrees(0);

        Stopwatch sw = new Stopwatch();
        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N; i++)
        {
            aVLTrees.Insert(rndNums[i]);
        }
        sw.Stop();
        Console.WriteLine($"Добавление в АВЛ дерево случайных числе от 0 до {N} занимает: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            bool searh = aVLTrees.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в несбалансированном АВЛ дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");

        //Балансируем правое поддерево
        aVLTrees.BalanceFactor = 2; //Устанавливаем фактор балансировки
        sw = new Stopwatch();
        sw.Start();
        Console.WriteLine($"Балансировка АВЛ дерева. Высота дерева до балансировки {aVLTrees.Root.Height}.");
        aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
        while (Math.Abs(aVLTrees.maxUnBalanceRoot.BalanceFactor) > aVLTrees.BalanceFactor)
        {
            aVLTrees.Rebalance(aVLTrees.maxUnBalanceRoot);
            aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
        }
        sw.Stop();
        Console.WriteLine($"Высота дерева после балансировки {aVLTrees.Root.Height}. Время балансировки: {sw.ElapsedTicks * 100} нс.");

        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < N / 10; i++)
        {
            bool searh = aVLTrees.Search(random.Next(0, N));
        }
        sw.Stop();
        Console.WriteLine($"Поиск в сбалансированном АВЛ дереве {N / 10} случайных чисел занимает: {sw.ElapsedTicks * 100} нс.");
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
