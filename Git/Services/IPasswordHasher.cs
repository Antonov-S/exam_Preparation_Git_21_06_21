namespace Git.Services
{
    interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
