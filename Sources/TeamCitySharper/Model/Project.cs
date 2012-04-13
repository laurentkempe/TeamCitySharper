namespace TeamCitySharper.Model
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }

        public string Description { get; set; }
        public bool Archived { get; set; }
        public string WebUrl { get; set; }

        //public string Parameters { get; set; }
        //public string Templates { get; set; }

        //Works
        public BuildTypes BuildTypes { get; set; }
    }
}