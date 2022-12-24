using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class SimpleTrees
    {
        Node root;
        public SimpleTrees(int x)
        {
            root = new Node();
            root.Key = x;
        }
        public Node Root { get { return root; } }
        public Node Insert(int x)
        {
            Insert(x, root);
            return root;
        }
        void Insert(int x, Node node)
        {
            if (x > node.Key)
            {
                if (node.Right == null)
                {
                    node.Right = new Node();
                    node.Right.Key = x;
                    node.Right.Parrent = node;
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
                    node.Left = new Node();
                    node.Left.Key = x;
                    node.Left.Parrent = node;
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
        public bool Search(int x)
        {
            return Search(x, root);
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
        public void Remove(int x)
        {
            Remove(x, root);
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
                if(node.Left == null && node.Right == null)
                {
                    ClearParrent(node);
                    return;
                }

                Node node1 = node.Right;
                Node node2 = node.Left;
                Node _root = node.Parrent;

                ClearParrent(node);

                node = null;

                Insert(node1, _root);
                Insert(node2, _root);
            }
        }

        void ClearParrent(Node node)
        {
            if (node.Key < node.Parrent.Key)
                node.Parrent.Left = null;
            else
                node.Parrent.Right = null;
        }
    }
}
