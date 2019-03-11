using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表反转
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4= new Node(4);

            node.Next = node2;
            node2.Next = node3;
            node3.Next = node4;


            //node=ReverseList(node);

            node = ReserverNodeByPoint(node);

            Console.WriteLine(GetNodeString(node));


            Console.ReadKey();

        }
        // 辅助方法：生成链表元素的字符串用于对比
        public static string GetNodeString(Node head)
        {
            if (head == null)
            {
                return null;
            }

            StringBuilder sbResult = new StringBuilder();
            Node temp = head;
            while (temp != null)
            {
                sbResult.Append(temp.Data.ToString());
                temp = temp.Next;
            }

            return sbResult.ToString();
        }
        /// <summary>
        /// 第一种
        /// 借助外部空间 实现，可以将链表存储为数组或者栈来实现，比较浪费空间，效率不占优势
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node ReverseList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            List<Node> nodeList = new List<Node>();
            while (head != null)
            {
                nodeList.Add(head);
                head = head.Next;
            }
            int startIndex = nodeList.Count - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                Node node = nodeList[i];
                if (i == 0)
                {
                    node.Next = null;
                }
                else
                {
                    node.Next = nodeList[i - 1];
                }
            }
            head = nodeList[startIndex];
            return head;
        }

        /// <summary>
        /// 高效法  三个指针解法，
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node ReserverNodeByPoint(Node head)
        {
            if (head == null)
                return null;
            Node reserverHead = null;
            // 指针1:当前节点
            Node currentNode = head;
            //指针2：当前节点的前一个节点
            Node preNode = null;
            while (currentNode != null)
            {
                //指针3：当前节点的后一个节点
                Node nextNode = currentNode.Next;
                if (nextNode == null)
                {
                    reserverHead = currentNode;
                }
                //将当前节点的后一个节点指向前一个节点
                currentNode.Next = preNode;
                //将前一个节点指向当前节点
                preNode = currentNode;
                //将当前节点指向后一个节点
                currentNode = nextNode;
            }
            return reserverHead;
        }
    }

    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int Data)
        {
            this.Data = Data;
        }
        public Node(int data,Node next)
        {
            this.Data = data;
            Next = next;
        }

        
    }
  

}
