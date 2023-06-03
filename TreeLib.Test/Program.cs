using System;

namespace TreeLib.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> BST = new BST<int>();

            foreach (int element in new int[7] { 18, 20, 30, 40, 48, 50, 53 })
            {
                BST.Insert(element);
            }

            Console.WriteLine($"Bejárás sorrendben ({BST.Count} elem):");
            BST.TraverseInOrder();

            Console.WriteLine($"\nA fa {BST.Depth} szintből áll kiegyenlítés előtt.");
            BST.Balance();
            Console.WriteLine($"A fa {BST.Depth} szintből áll kiegyenlítés után.");

            Console.ReadKey();
        }
    }
}