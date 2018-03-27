using System.Text;

namespace hearme_backend.domain.Entities
{
    public class CriptografaJa
    {
        public string generateHashString(string password)
        {
            byte[] encodedpassword;
            byte[] sha1hash;

            System.Security.Cryptography.SHA1Managed hash = new System.Security.Cryptography.SHA1Managed();

            // get the byte representation of the password
            encodedpassword = Encoding.ASCII.GetBytes(password);

            // Compute the SHA1 hash of the password.
            sha1hash = hash.ComputeHash(encodedpassword);

            // String builder to create the final Hex encoded hash string
            StringBuilder hashedkey = new StringBuilder(sha1hash.Length);


            // Convert to Hex encoded string
            foreach (byte b in sha1hash)
            {
                // This generates the hex encoded string in lower case. Use "X2" to get hash string in upper-case.
                hashedkey.Append(b.ToString("x2"));
            }
            string hashValue;
            // Final Hex encoded SHA1 hash string
            return hashValue = hashedkey.ToString();  
        }
    }
}