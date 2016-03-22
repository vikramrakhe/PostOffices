namespace PostOffices
{
    public class PostOffice
    {
        public PostOffice(string name, string pincode, string district, string state)
        {
            Name = name;
            PINCode = pincode;
            District = district;
            State = state;
        }

        public string Name { get; private set; }
        // ReSharper disable once InconsistentNaming
        public string PINCode { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, PINCode: {1}, District: {2}, State: {3}", Name, PINCode, District, State);
        }

        public string District { get; private set; }
        public string State { get; private set; }
    }
}
