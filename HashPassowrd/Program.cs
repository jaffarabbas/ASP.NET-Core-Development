using HashPassowrd;
using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16]; // 16 bytes (128 bits) is a common size for salt
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public static byte[] HashPassword(string password, byte[] salt,string type)
    {
        if(type == "sha256")
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                return sha256.ComputeHash(saltedPassword);
            }
        }else if(type == "sha1")
        {
            using (var sha1 = new SHA1Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                return sha1.ComputeHash(saltedPassword);
            }
        }
        else
        {
            return null;
        }
    }
    public static byte[] StringToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] byteArray = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            byteArray[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return byteArray;
    }
    public static void Main()
    {
        byte[] salt = GenerateSalt();
        byte[] hashedPassword = HashPassword("admin123", salt,"sha1");

        User newUser = new User
        {
            Username = "user_username",
            Salt = salt,
            PasswordHash = hashedPassword
        };

        Console.WriteLine(BitConverter.ToString(newUser.Salt).Replace("-", ""));
        Console.WriteLine(BitConverter.ToString(newUser.PasswordHash).Replace("-", ""));

        byte[] saltFromDatabase = StringToByteArray(BitConverter.ToString(newUser.Salt).Replace("-", "")); // Retrieve salt from the database for the user
        byte[] storedHashedPassword = StringToByteArray(BitConverter.ToString(newUser.PasswordHash).Replace("-", "")); // Retrieve hashed password from the database for the user

        byte[] hashedPasswordAttempt = HashPassword("admin123", saltFromDatabase, "sha1");

        // Compare hashedPasswordAttempt with storedHashedPassword
        if (hashedPasswordAttempt.SequenceEqual(storedHashedPassword))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
