using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Final_test.animals
{
    public class Donkey : PackAnimal
    {
        public Donkey(int id, string type, string kind, string name, string birthday, List<string> commands, double bearingCapacity) : base(id, type, kind, name, birthday, commands, bearingCapacity)
        {
        }
    }
}
