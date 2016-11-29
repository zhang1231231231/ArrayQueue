using System;

namespace ArrayQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue<int> queue = new ArrayQueue<int>(10);
            queue.EnQueue(2);
            queue.EnQueue(4);
            queue.EnQueue(6);
            Console.WriteLine("queue size = {0}", queue.Size);
            Console.WriteLine("queue.DeQueue() = {0}", queue.DeQueue());
            Console.WriteLine("queue size = {0}", queue.Size);
            Console.WriteLine("queue.DeQueue() = {0}", queue.DeQueue());
            Console.ReadLine();
        }
    }

    public class ArrayQueue<T>
    {
        private T[] items;
        private int first;
        private int tail;
        private int index;

        public ArrayQueue(int capacity)
        {
            this.items = new T[capacity];
            this.index = 0;
            this.first = this.tail = 0;
        }

        public ArrayQueue()
        {

        }
        /// <summary>
        /// 入队列
        /// </summary>
        /// <param name="item"></param>
        public void EnQueue(T item)
        {
            if (index == items.Length)
            {
                ResizeCapasize(index * 2);
            }
            items[tail] = item;
            tail++;
            index++;
        }
        /// <summary>
        /// 出队列
        /// </summary>
        /// <returns>队列元素</returns>
        public T DeQueue()
        {
            if (Size == 0)
            {
                return default(T);
            }

            T item = items[first];
            items[first] = default(T);
            first++;
            if (first > 0 && Size == items.Length / 4)
            {
                ResizeCapasize(items.Length / 2);
            }
            index--;
            return item;
        }
        /// <summary>
        /// 重新分配数组长度
        /// </summary>
        /// <param name="newCapasize">新的容量</param>
        private void ResizeCapasize(int newCapasize)
        {
            T[] newItems = new T[newCapasize];
            int size = 0;
            if (newCapasize > items.Length)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    newItems[size++] = items[i];
                }
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (!items[i].Equals(default(T)))
                    {
                        newItems[size++] = items[i];
                    }
                }

                first = tail = 0;
            }
            items = newItems;
        }
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.index == 0;
        }
        /// <summary>
        /// 栈中节点数
        /// </summary>
        public int Size
        {
            get
            {
                return this.index;
            }
        }

    }
}
