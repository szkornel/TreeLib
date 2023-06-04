namespace TreeLib
{
    public class HuffmanTree
    {
        /// <summary>Kódolandó szöveg</summary>
        public string Input { get; private set; }

        /// <summary>Kódolt szöveg</summary>
        public string Encoded { get; private set; }

        /// <summary>Gyökérelem</summary>
        private HuffmanElement Root { get; set; }

        /// <summary>Karakterek előfordulási gyakoriságát tároló tábla</summary>
        private Dictionary<char, int> FreqTable { get; set; } = new();

        /// <summary>Karakterekhez tartozó kódokat tároló tábla</summary>
        private Dictionary<char, string> CodeTable { get; set; } = new();

        /// <summary>Konstruktor</summary>
        /// <param name="input">Kódolandó szöveg</param>
        public HuffmanTree(string input)
        {
            Input = input;
            BuildFreqTable();
            Root = BuildTree();
            BuildCodeTable();
            Encoded = Encode();
        }

        /// <summary>Karakterek előfordulási gyakoriságát tartalmazó tábla feltöltése</summary>
        private void BuildFreqTable()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (FreqTable.ContainsKey(Input[i]))
                {
                    FreqTable[Input[i]]++;
                }
                else
                {
                    FreqTable.Add(Input[i], 1);
                }
            }
        }

        /// <summary>Karakterekhez tartozó kódokat tartalmazó tábla feltöltése</summary>
        private void BuildCodeTable()
        {
            BuildCodeTable(Root);
        }

        /// <summary>Karakterekhez tartozó kódokat tartalmazó tábla feltöltése</summary>
        /// <param name="parent">Gyökérelem</param>
        /// <param name="code">Adott karakterhez tartozó kód</param>
        private void BuildCodeTable(HuffmanElement? parent, string code = "")
        {
            if (parent == null)
            {
                return;
            }

            if (parent.IsLeaf)
            {
                CodeTable.Add(parent.Data, code);
                return;
            }

            BuildCodeTable((HuffmanElement?)parent.Left, $"{code}0");
            BuildCodeTable((HuffmanElement?)parent.Right, $"{code}1");
        }

        /// <summary>Fa felépítése</summary>
        /// <returns>Visszaadja a fa gyökérelemét</returns>
        private HuffmanElement BuildTree()
        {
            PriorityQueue<HuffmanElement, int> priorityQueue = new();

            foreach (KeyValuePair<char, int> freq in FreqTable)
            {
                priorityQueue.Enqueue(new(freq.Key, freq.Value), freq.Value);
            }

            while (priorityQueue.Count > 1)
            {
                HuffmanElement left = priorityQueue.Dequeue();
                HuffmanElement right = priorityQueue.Dequeue();
                int freq = right.Freq + left.Freq;
                HuffmanElement parent = new('\0', freq) { Left = left, Right = right };
                priorityQueue.Enqueue(parent, freq);
            }

            return priorityQueue.Dequeue();
        }

        /// <summary>Szöveg kódolása</summary>
        /// <returns>Visszaadja a kódolt szöveget</returns>
        private string Encode()
        {
            string encoded = "";

            foreach (char c in Input)
            {
                encoded += CodeTable[c];
            }

            return encoded;
        }

        /// <summary>Szöveg dekódolása</summary>
        /// <returns>Visszaadja a dekódolt szöveget</returns>
        public string Decode()
        {
            string decoded = "";
            HuffmanElement? current = Root;

            foreach (char bit in Encoded)
            {
                current = bit == '0' ? (HuffmanElement?)current?.Left : (HuffmanElement?)current?.Right;

                if (current != null && current.IsLeaf)
                {
                    decoded += current.Data;
                    current = Root;
                }
            }

            return decoded;
        }

        /// <summary>Táblák kirírása a konzolra</summary>
        public void PrintTables()
        {
            Console.WriteLine("Karakterek előfordulása:");
            foreach (var item in FreqTable)
            {
                Console.WriteLine($"'{item.Key}': {item.Value}");
            }

            Console.WriteLine("\nKarakterekhez tartozó kódok:");
            foreach (var item in CodeTable)
            {
                Console.WriteLine($"'{item.Key}': {item.Value}");
            }
        }
    }
}