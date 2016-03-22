namespace PostOffices
{
    public class PostOffice
    {
        public PostOffice(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
