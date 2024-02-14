using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Final_test.animals
{
    public class Hamster : PetAnimal
    {
        public Hamster(int id, string type, string kind, string name, string birthday, List<string> commands, string likeToy) : base(id, type, kind, name, birthday, commands, likeToy)
        {
        }
    }
}
