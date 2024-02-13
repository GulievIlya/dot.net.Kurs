using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    public class Vertex// Вершина
    {
        public Vertex(uint name)
        {
            Name = name;
        }
        public uint Name { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }
        public string GetNameVertex()
        {
            return $"X{Name}";
        }
    }
}
