using GB_Final_test.animals;

namespace GB_Final_test.data
{
    public class AnimalList
    {
        public int id { get; set; } = 0!;
        public string type { get; set; } = null!;
        public string kind { get; set; } = null!;
        public string name { get; set; } = null!;
        public string birthday { get; set; } = null!;
        public string commands { get; set; } = null!;
        public double weight { get; set; } = 0!;
        public string toy { get; set; } = null!;

        public AnimalList() { }

        public AnimalList(Animal animal)
        {
            this.id = animal.Id;
            this.type = animal.Type;
            this.kind = animal.Kind;
            this.name = animal.Name;
            this.birthday = animal.Birthday;
            this.commands = string.Join(", ", animal.Commands.ToArray());

            if (animal is PetAnimal)
            {
                this.weight = 0;
                this.toy = ((PetAnimal)animal).LikeToy;
            }
            else
            {
                this.weight = ((PackAnimal)animal).BearingCapacity;
                this.toy = "-";
            }
        }

        public AnimalList(int id, string type, string kind, string name, string birthday, string commands, double weight, string toy)
        {
            this.id = id;
            this.type = type;
            this.kind = kind;
            this.name = name;
            this.birthday = birthday;
            this.commands = commands;
            this.weight = weight;
            this.toy = toy;
        }
    }
}
