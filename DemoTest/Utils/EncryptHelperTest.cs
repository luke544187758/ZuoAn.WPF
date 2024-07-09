using Gao.MvvmToolkit.Demo.Utils;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Xunit.Abstractions;

namespace DemoTest.Utils
{
    public class EncryptHelperTest
    {
        private ITestOutputHelper output;

        public EncryptHelperTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void Encrypt_Test()
        {
            string expected = "Here is some data to encrypt!";
            using var myAes = Aes.Create();

            var secret = new AesSecret
            {
                Key = myAes.Key,
                IV = myAes.IV
            };
            var content = JsonSerializer.Serialize<AesSecret>(secret);
            output.WriteLine($"secret:{content}");
            byte[] encrypted = EncryptHelper.EncryptStringToBytes_Aes(expected, myAes.Key, myAes.IV);
            var encryptText = Convert.ToBase64String(encrypted);

            var secretObj = JsonSerializer.Deserialize<AesSecret>(content);

            var cipher = Convert.FromBase64String(encryptText);
            var actual = EncryptHelper.DecryptStringFromBytes_Aes(cipher, secretObj.Key, secretObj.IV);
            output.WriteLine($"key:{Convert.ToBase64String(secret.Key)} iv:{Convert.ToBase64String(secret.IV)}");
            Assert.Equal(expected, actual);
        }
    }
}
