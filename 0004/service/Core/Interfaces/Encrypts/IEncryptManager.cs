namespace Core.Interfaces.Encrypts
{
    public interface IEncryptManager
    {
        string Encrypt(string text, string key);
        string Decrypt(string text, string key);
    }
}
