namespace Assignment9.Models
{
    public class Recipe
    {
        public Recipe(int id, string author, string name, string type, string description)
        {
            Id = id;
            Author = author;
            Name = name;
            Type = type;
            Description = description;
        }

        public Recipe()
        {
        }

        public int Id { get; set; }
        
        public string Author { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}