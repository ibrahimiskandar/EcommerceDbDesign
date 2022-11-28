namespace TaskForRelation.Models
{
    public class User
    {
        public string UserName { get; set; } = String.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
