namespace TreeLib
{
    public class Element<T>
    {
        /// <summary>Elemhez tartozó adat</summary>
        public T Data { get; set; }

        /// <summary>Elemhez balról csatlakozó másik elem</summary>
        public Element<T>? Left { get; set; }

        /// <summary>Elemhez jobbról csatlakozó másik elem</summary>
        public Element<T>? Right { get; set; }

        /// <summary>Konstruktor</summary>
        /// <param name="data">Elemhez tartozó adat</param>
        public Element(T data) { Data = data; }

        /// <summary>ToString() metódus felülírása</summary>
        public override string ToString()
        {
            return $"{Data}";
        }
    }
}