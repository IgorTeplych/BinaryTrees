using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Tests
{
    public class AVLTreeTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void InsertInTrees()
        {
            BinaryTrees.AVLTrees avl = new BinaryTrees.AVLTrees(10);
            avl.Insert(4);
            avl.Insert(12);
            avl.Insert(14);
            avl.Insert(11);
            Assert.AreEqual(avl.Root.Left.Key, 4);
            Assert.AreEqual(avl.Root.Right.Key, 12);
            Assert.AreEqual(avl.Root.Right.Right.Key, 14);
            Assert.AreEqual(avl.Root.Right.Left.Key, 11);
        }
        [Test]
        public void InsertAndSearchOrderedNums()
        {
            int N = 500;
            int[] orderNums = GetOrderNumbers(N);
            AVLTrees aVLTrees = new AVLTrees(0);
            for (int i = 0; i < N; i++)
            {
                aVLTrees.Insert(orderNums[i]);
            }

            for (int i = 1; i < N; i++)
            {
                Assert.AreEqual(aVLTrees.Search(i), true);
            }
            Assert.AreEqual(false, aVLTrees.Search(555));
        }
        [Test]
        public void InsertBalanceAndSearchOrderedNums()
        {
            int N = 500;
            int[] orderNums = GetOrderNumbers(N);
            AVLTrees aVLTrees = new AVLTrees(0);
            for (int i = 0; i < N; i++)
            {
                aVLTrees.Insert(orderNums[i]);
            }

            //Балансировка дерева
            aVLTrees.BalanceFactor = 1; 
            aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
            Assert.AreEqual(aVLTrees.maxUnBalanceRoot.BalanceFactor, -497); //Проверка максимального баланса до балансировки
            Assert.AreEqual(aVLTrees.Root.Height, 499); //Проверка высоты дерева до балансировки
            while (Math.Abs(aVLTrees.maxUnBalanceRoot.BalanceFactor) > aVLTrees.BalanceFactor)
            {
                aVLTrees.Rebalance(aVLTrees.maxUnBalanceRoot);
                aVLTrees.MaxUnBalanceRoot(aVLTrees.Root.Right);
            }
            Assert.AreEqual(aVLTrees.maxUnBalanceRoot.BalanceFactor, -1); //Проверка максимального баланса после балансировки
            Assert.AreEqual(aVLTrees.Root.Height, 10); //Проверка высоты дерева после балансировки
            //конец балансировки дерева

            //Поиск в сбалансированном дереве
            for (int i = 1; i < N; i++)
            {
                bool searh = aVLTrees.Search(i);
                Assert.AreEqual(searh, true);
            }
        }


        static Random random = new Random();
        static int[] GetRandomNumbers(int N)
        {
            int[] mass = new int[N];
            for (int i = 0; i < N; i++)
            {
                mass[i] = random.Next(1, int.MaxValue);
            }
            return mass;
        }

        static int[] GetOrderNumbers(int N)
        {
            int[] mass = new int[N];
            for (int i = 1; i < N; i++)
            {
                mass[i] = i;
            }
            return mass;
        }
    }
}
