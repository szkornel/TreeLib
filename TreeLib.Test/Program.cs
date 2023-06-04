using TreeLib;

// BST:
Console.WriteLine("\n=================\n====== BST ======\n=================\n");
BST<int> BST = new(18);

// Insert:
foreach (int element in new int[6] { 20, 30, 40, 48, 50, 53 })
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

// Huffman:
Console.WriteLine("\n=================\n==== Huffman ====\n=================\n");
string input = "Ez egy teszt szöveg, amit kódolni kell.";
Console.WriteLine($"Kódolni kívánt szöveg: '{input}'\n");

HuffmanTree ht = new(input);
ht.PrintTables();

Console.WriteLine($"\nKódolt szöveg: {ht.Encoded}");
Console.WriteLine($"\nDekódolt szöveg: '{ht.Decode()}'");
Console.ReadKey();