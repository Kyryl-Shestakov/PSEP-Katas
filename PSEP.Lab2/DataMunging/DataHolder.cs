using System;

namespace DataMunging
{
    public class DataHolder
    {
        public string Identifier { get; }
        public int FirstValue { get; }
        public int SecondValue { get; }

        public int Difference => FirstValue - SecondValue;

        public DataHolder(string identifier, int firstValue, int secondValue)
        {
            if (ReferenceEquals(identifier, null))
            {
                throw new ArgumentNullException(nameof(identifier), "Identifier should not be null");
            }

            Identifier = identifier;
            FirstValue = firstValue;
            SecondValue = secondValue;
        }
    }
}
