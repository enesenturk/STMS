using System.Security.Cryptography;
using System.Text;

namespace NS.STMS.Core.Helpers
{
	public class PasswordHasher
	{

		private static readonly int _keySize = 64;
		private static readonly int _iterations = 350 * 1000;
		private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

		public static string HashPasword(string password, out byte[] salt)
		{
			salt = RandomNumberGenerator.GetBytes(_keySize);

			var hash = Rfc2898DeriveBytes.Pbkdf2(
				Encoding.UTF8.GetBytes(password),
				salt,
				_iterations,
				_hashAlgorithm,
				_keySize);
		
			return Convert.ToHexString(hash);
		}

		public static bool VerifyPassword(string password, string hash, byte[] salt)
		{
			var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);

			return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
		}

	}
}
