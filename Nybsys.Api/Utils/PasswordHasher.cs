
using System.Security.Cryptography;
namespace Nybsys.Api.Utils
{
	public class PasswordHasher
	{

		private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

		private static readonly int SaltSize = 16;
		private static readonly int HashSize = 20;
		private static readonly int Iteration = 10000;

		public static string HashPassword(string password)
		{
			byte[] salt;
			rng.GetBytes(salt = new byte[SaltSize]);
			var key = new Rfc2898DeriveBytes(password, salt, Iteration);
			var hash = key.GetBytes(HashSize);
			var hashBytes= new byte[SaltSize+ HashSize];
			Array.Copy(salt, 0, hashBytes, 0, SaltSize);
			Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

			var base64hash=Convert.ToBase64String(hashBytes);
			return base64hash;

		}

		public static bool VerifyPassword(string password,string base64hash)
		{ 	
		 var hashBytes= Convert.FromBase64String(base64hash);
		 var salt= new byte[SaltSize];
			Array.Copy(hashBytes,0, salt, 0, SaltSize);
			var key = new Rfc2898DeriveBytes(password, salt, Iteration);
			byte[] hash = key.GetBytes(HashSize);

			for (var i = 0; i < HashSize; i++)
			{
				if (hashBytes[i+SaltSize] != hash[i])
				{
					return false;
				}
			}
			return true;

		}

	}
}
