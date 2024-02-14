namespace GB_Final_test.animals
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public List<string> Commands { get; set; }

        protected Animal(int id, string type, string kind, string name, string birthday, List<string> commands)
        {
            Id = id;
            Type = type;
            Kind = kind;
            Name = name;
            Birthday = birthday;
            Commands = commands;
        }
    }
}