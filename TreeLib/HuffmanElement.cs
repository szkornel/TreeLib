namespace TreeLib
{
    public class HuffmanElement : Element<char>
    {
        /// <summary>Adott karakter előfordulási gyakorisága a szövegben</summary>
        public int Freq { get; set; }

        /// <summary>Levél az adott elem?</summary>
        public bool IsLeaf { get { return Left == null && Right == null; } }

        /// <summary>Konstruktor</summary>
        /// <param name="character">Elemhez tartozó karakter</param>
        /// <param name="freq">Karakter előfordulási gyakorisága</param>
        public HuffmanElement(char character, int freq) : base(character)
        {
            Freq = freq;
        }
    }
}