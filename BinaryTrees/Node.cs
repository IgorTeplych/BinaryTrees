using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Node
    {
        public int Height
        {
            get
            {
                return (Math.Max((this.Left != null ? this.Left.Height + 1 : 0), (this.Right != null ? this.Right.Height + 1 : 0)));
            }
        }
        public int Key { get; set; }
        public Node Parrent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        /// <summary>
        /// Если BalanceFactor больше 1, то поворачивать нужно вправо. Если BalanceFactor меньше -1, то поворачивать нужно влево
        /// </summary>
        public int BalanceFactor
        {
            get
            {
                return (this.Left != null ? this.Left.Height : 0) - (this.Right != null ? this.Right.Height : 0);
            }
        }
    }
}
