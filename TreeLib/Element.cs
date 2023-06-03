namespace TreeLib
{
    public class Element<T>
    {
        /// <summary>Elemhez tartozó adat</summary>
        public T Data { get; set; }

        /// <summary>Elemhez balról csatlakozó másik elem</summary>
        public Element<T> Left { get; set; }

        /// <summary>Elemhez jobbról csatlakozó másik elem</summary>
        public Element<T> Right { get; set; }

        public Element() { }

        public Element(T data) { Data = data; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}