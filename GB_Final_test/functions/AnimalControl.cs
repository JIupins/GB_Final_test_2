using GB_Final_test.animals;
using GB_Final_test.data;
using System.Data.Common;

namespace GB_Final_test.functions
{
    public class AnimalControl
    {
        public enum AnimalType : int
        {
            Pet_Animal,
            Pack_Animal
        }

        enum PetAnimalKind
        {
            Cat,
            Dog,
            Hamster
        }

        enum PackAnimalKind
        {
            Horse,
            Camel,
            Donkey
        }

        public Animal CreateAnimal(int type, int kind, string name, string birthday, List<string> commands, double bearingCapacity, string likeToys)
        {
            IDCounter _IDCounter = new IDCounter();
            int id = _IDCounter.GetNewIDNum();

            if (type == (int)AnimalType.Pet_Animal)
            {
                if (kind == (int)PetAnimalKind.Cat)
                {
                    Cat cat = new Cat(id, "Домашнее животное", "Кошка", name, birthday, commands, likeToys);
                    return cat;
                }
                else if (kind == (int)PetAnimalKind.Dog)
                {
                    Dog dog = new Dog(id, "Домашнее животное", "Собака", name, birthday, commands, likeToys);
                    return dog;
                }
                else
                {
                    Hamster hamster = new Hamster(id, "Домашнее животное", "Хомяк", name, birthday, commands, likeToys);
                    return hamster;
                }
            }
            else
            {
                if (kind == (int)PackAnimalKind.Horse)
                {
                    Horse horse = new Horse(id, "Вьючное животное", "Лошадь", name, birthday, commands, bearingCapacity);
                    return horse;
                }
                else if (kind == (int)PackAnimalKind.Camel)
                {
                    Camel camel = new Camel(id, "Вьючное животное", "Верблюд", name, birthday, commands, bearingCapacity);
                    return camel;
                }
                else
                {
                    Donkey donkey = new Donkey(id, "Вьючное животное", "Осёл", name, birthday, commands, bearingCapacity);
                    return donkey;
                }
            }
        }

        public void UpdateAnimal()
        {

        }

        public void TrainAnimal()
        {

        }

        public void RemoveAnimal()
        {

        }
    }
}
