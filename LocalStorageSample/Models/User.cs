namespace LocalStorageSample.Models
{
    public class User(string nom, string email)
    {
        public string Nom { get; } = nom;
        public string Email { get; } = email;

    }
}
