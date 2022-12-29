using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class AVLTrees
    {
        Node _root;
        public AVLTrees(int x)
        {
            _root = new Node();
            _root.Key = x;
            BalanceFactor = 2;
            maxUnBalanceRoot = new Node();
        }
        /// <summary>
        /// Коэффициент для балансировки дерева от 1 до max
        /// </summary>
        public int BalanceFactor { get; set; }
        public Node Root
        {
            get
            { return _root; }
            set
            {
                _root = value;
            }
        }
        public bool Search(int x)
        {
            return Search(x, _root);
        }
        bool Search(int x, Node node)
        {
            if (node == null)
                return false;

            if (node.Key == x)
            {
                return true;
            }
            else
            {
                if (x > node.Key)
                {
                    return Search(x, node.Right);
                }
                else
                {
                    return Search(x, node.Left);
                }
            }
        }
        Node SearchNode(int x, Node tree)
        {
            if (tree == null)
                return null;

            if (tree.Key == x)
            {
                return tree;
            }
            else
            {
                if (x > tree.Key)
                {
                    return SearchNode(x, tree.Right);
                }
                else
                {
                    return SearchNode(x, tree.Left);
                }
            }
        }
        public Node Insert(int x)
        {
            Insert(x, _root);
            return _root;
        }
        void Insert(int x, Node node)
        {
            if (x > node.Key)
            {
                if (node.Right == null)
                {
                    Node newNode = new Node();
                    newNode.Key = x;
                    newNode.Parrent = node;
                    node.Right = newNode;
                }
                else
                {
                    Insert(x, node.Right);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    Node newNode = new Node();
                    newNode.Key = x;
                    newNode.Parrent = node;
                    node.Left = newNode;
                }
                else
                {
                    Insert(x, node.Left);
                }
            }
        }
        void Insert(Node insertNode, Node root)
        {
            if (insertNode.Key > root.Key)
            {
                if (root.Right == null)
                {
                    root.Right = insertNode;
                    insertNode.Parrent = root;
                }
                else
                {
                    Insert(insertNode, root.Right);
                }
            }
            else
            {
                if (root.Left == null)
                {
                    root.Left = insertNode;
                    insertNode.Parrent = root;
                }
                else
                {
                    Insert(insertNode, root.Left);
                }
            }
        }
        public void Remove(int x)
        {
            Remove(x, _root);
        }
        void Remove(int x, Node node)
        {
            if (node == null) return;

            if (x > node.Key)
                Remove(x, node.Right);
            else
                Remove(x, node.Left);

            if (node.Key == x)
            {
                Node node1 = node.Right;
                Node node2 = node.Left;
                Node _root = node.Parrent;

                if (node.Key < node.Parrent.Key)
                    node.Parrent.Left = null;
                else
                    node.Parrent.Right = null;

                node = null;

                if (node1 != null)
                    Insert(node1, _root);
                if (node2 != null)
                    Insert(node2, _root);
            }
        }
        public void SmallLeftRotation(Node tree)
        {
            Node root = tree;
            tree.Right.Parrent = tree.Parrent;   //правой ветви назначаем нового отца

            if (tree.Parrent.Right != null && tree.Parrent.Right.Key == tree.Key)
                tree.Parrent.Right = tree.Right;    //Новому отцу сообщаем о новом потомке справа

            if (tree.Parrent.Left != null && tree.Parrent.Left.Key == tree.Key)
                tree.Parrent.Left = tree.Right; //Новому отцу сообщаем о новом потомке слева

            tree = root.Right;
            root.Right = null;
            root.Parrent = null;
            Insert(root, tree);
        }
        public void SmallRightRotation(Node tree)
        {
            Node root = tree;
            tree.Left.Parrent = tree.Parrent;

            if (tree.Parrent.Left != null && tree.Parrent.Left.Key == tree.Key)
                tree.Parrent.Left = tree.Left;

            if (tree.Parrent.Right != null && tree.Parrent.Right.Key == tree.Key)
                tree.Parrent.Right = tree.Left;

            tree = root.Left;
            root.Left = null;
            root.Parrent = null;
            Insert(root, tree);
        }

        public void BigLeftRotation(Node root)
        {
            if (root.Right.BalanceFactor > BalanceFactor)
            {
                SmallRightRotation(root.Right);
            }
            if (root.Right.BalanceFactor < (-1 * BalanceFactor))
            {
                SmallLeftRotation(root.Right);
            }
            SmallLeftRotation(root);
        }
        public void BigRightRotation(Node root)
        {
            if (root.Left.BalanceFactor > BalanceFactor)
            {
                SmallRightRotation(root.Left);
            }
            if (root.Left.BalanceFactor < (-1 * BalanceFactor))
            {
                SmallLeftRotation(root.Left);
            }
            SmallRightRotation(root);
        }
        public void Rebalance(Node node)
        {
            if (node == null) return;
            if (node.Right == null && node.Left == null) return;

            if (node != null)
            {
                if (node.Right != null)
                    Rebalance(node.Right);

                if (node.Left != null)
                    Rebalance(node.Left);
            }
            if (Math.Abs(node.BalanceFactor) > BalanceFactor)
            {
                BigRotBalanceTree(node);
            }
        }
        public void BigRotBalanceTree(Node node)
        {
            if (Math.Abs(node.BalanceFactor) > BalanceFactor)
            {
                if (node.BalanceFactor > BalanceFactor)
                    BigRightRotation(node);

                if (node.BalanceFactor < (-1 * BalanceFactor))
                    BigLeftRotation(node);
            }
        }

        public Node maxUnBalanceRoot { get; private set; }
        public void MaxUnBalanceRoot(Node node)
        {
            if (node.Right == null && node.Left == null)
                return;

            if (node != null)
            {
                if (node.Right != null)
                    MaxUnBalanceRoot(node.Right);

                if (node.Left != null)
                    MaxUnBalanceRoot(node.Left);
            }

            if (Math.Abs(node.BalanceFactor) > Math.Abs(maxUnBalanceRoot.BalanceFactor))
                maxUnBalanceRoot = node;
        }


        List<Node> unbalanceRoot = new List<Node>();
        public List<Node> GetUnbalanceRoot()
        {
            unbalanceRoot = new List<Node>();
            SearchRebalanceOut(_root);
            return unbalanceRoot;
        }

        void SearchRebalanceOut(Node node)
        {
            if (node.Right == null && node.Left == null)
                return;

            if (node != null)
            {
                if (node.Right != null)
                    SearchRebalanceOut(node.Right);

                if (node.Left != null)
                    SearchRebalanceOut(node.Left);
            }
            if (Math.Abs(node.BalanceFactor) > this.BalanceFactor)
            {
                unbalanceRoot.Add(node);
            }
        }

    }
}
