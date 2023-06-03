using System;

namespace TreeLib.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> BST = new BST<int>();

            // Insert:
            foreach (int element in new int[7] { 18, 20, 30, 40, 48, 50, 53 })
            {
                BST.Insert(element);
            }

            // TraverseInOrder:
            Console.WriteLine("Bejárás sorrendben:");
            BST.TraverseInOrder();

            // Depth, PrintAllLevels:
            Console.WriteLine($"\nA fa {BST.Depth} szintből áll:");
            BST.PrintAllLevels();
            Console.WriteLine();

            // IsBalanced, Balance:
            if (!BST.IsBalanced)
            {
                BST.Balance();
                Console.WriteLine("A fa nem kiegyenlített!");
                Console.WriteLine($"A fa {BST.Depth} szintből áll kiegyenlítés után:");
                BST.PrintAllLevels();
                Console.WriteLine();
            }

            // Count, Min, Max:
            Console.WriteLine($"Elemszám: {BST.Count}");
            Console.WriteLine($"Legkisebb elem: {BST.Min}");
            Console.WriteLine($"Legnagyobb elem: {BST.Max}\n");

            // Contains:
            foreach (int data in new int[2] { 18, 49 })
            {
                Console.WriteLine($"Szerepel '{data}' a fában? {BST.Contains(data)}");
            }

            // Find:
            Console.WriteLine($"Mi szerepel a '20' jobb ágán? {BST.Find(20)?.Right}\n");

            // Delete:
            foreach (int data in new int[3] { 40, 18, 48 })
            {
                Console.WriteLine($"'{data}' törlése...");
                BST.Delete(data);
            }
            BST.Balance();
            Console.WriteLine($"\nTörlés és kiegyenlítés után a fa {BST.Depth} szintből áll:");
            BST.PrintAllLevels();
            Console.ReadKey();
        }
    }
}