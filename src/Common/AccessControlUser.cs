namespace Common
{
    public class AccessControlUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public int GroupType { get; set; } //if 1 then is Admin
    }
}
