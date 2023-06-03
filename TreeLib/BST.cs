using System;
using System.Collections.Generic;

namespace TreeLib
{
    public class BST<T> : Element<T> where T : IComparable<T>
    {
        /// <summary>Elemszám</summary>
        public int Count { get; private set; }

        /// <summary>Szintek száma</summary>
        public int Depth { get { return GetTreeDepth(this); } }

        public BST() { }

        public BST(T data) : base(data) { Count++; }

        /// <summary>Elem beszúrása</summary>
        /// <param name="newData">Beszúrandó elemhez tartozó adat</param>
        public void Insert(T newData)
        {
            Insert(this, newData);
        }

        /// <summary>Elem beszúrása</summary>
        /// <param name="parent">Gyökérelem</param>
        /// <param name="newData">Beszúrandó elemhez tartozó adat</param>
        private void Insert(Element<T> parent, T newData)
        {
            if (parent.Data == null || Count == 0)
            {
                parent.Data = newData;
                Count++;
                return;
            }

            int compare = newData.CompareTo(parent.Data);

            if (compare < 0 && parent.Left == null)
            {
                parent.Left = new Element<T>(newData);
                Count++;
                return;
            }

            if (compare < 0 && parent.Left != null)
            {
                Insert(parent.Left, newData);
            }

            if (compare > 0 && parent.Right == null)
            {
                parent.Right = new Element<T>(newData);
                Count++;
                return;
            }

            if (compare > 0 && parent.Right != null)
            {
                Insert(parent.Right, newData);
            }
        }

        /// <summary>Fa elemeinek kiírása sorrendben</summary>
        public void TraverseInOrder()
        {
            List<T> data = new List<T>();
            TraverseInOrder(this, data);

            foreach (T d in data)
            {
                Console.Write($"'{d}' ");
            }

            Console.WriteLine();
        }

        /// <summary>Fa elemeinek listába helyezése sorrendben</summary>
        /// <param name="parent">Gyökérelem</param>
        /// <param name="data">Lista, amibe az elemeket gyűjtse</param>
        private void TraverseInOrder(Element<T> parent, List<T> data)
        {
            if (parent == null)
            {
                return;
            }

            TraverseInOrder(parent.Left, data);
            data.Add(parent.Data);
            TraverseInOrder(parent.Right, data);
        }

        /// <summary>Fa kiegyenlítése</summary>
        public void Balance()
        {
            Balance(this);
        }

        /// <summary>Fa kiegyenlítése</summary>
        /// <param name="parent">Gyökérelem</param>
        private void Balance(Element<T> parent)
        {
            List<T> list = new List<T>();

            if (parent == null)
            {
                return;
            }

            TraverseInOrder(parent, list);
            Element<T> newRoot = Balance(list, 0, list.Count - 1);
            Data = newRoot.Data;
            Left = newRoot.Left;
            Right = newRoot.Right;
        }

        /// <summary>Fa kiegyenlítése</summary>
        /// <param name="data">Fa elemeit tartalmazó lista</param>
        /// <param name="start">Kezdőpont</param>
        /// <param name="end">Végpont</param>
        /// <returns>Visszaadja a kiegyenlített fa új gyökerét</returns>
        private Element<T> Balance(List<T> data, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Element<T> root = new Element<T>(data[mid]);
            root.Left = Balance(data, start, mid - 1);
            root.Right = Balance(data, mid + 1, end);
            return root;
        }

        /// <summary>Fa mélységének meghatározása</summary>
        /// <param name="parent">Gyökérelem</param>
        /// <returns>Visszaadja, hogy hány szintből áll a fa</returns>
        private int GetTreeDepth(Element<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.Left), GetTreeDepth(parent.Right)) + 1;
        }
    }
}