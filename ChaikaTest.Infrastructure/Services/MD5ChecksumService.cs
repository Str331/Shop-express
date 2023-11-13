using System.Text;

namespace ChaikaTest.Infrastructure.Services
{
    public class MD5ChecksumService : IMD5ChecksumService
    {
        public string MD5Checksum(byte[] inputBuffer)
        {
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(inputBuffer);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            return builder.ToString();
        }
    }
}
