using System;

namespace Alghorithms
{
    class Vertex
    {
        public int Number { get; set; }


        public Vertex(int number)
        {
            Number = number;
        }


        public override string ToString()
        {
            return Number.ToString();
        }
    }

}
