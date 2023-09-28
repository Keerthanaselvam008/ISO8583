using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISO
{
    class PinPanBlockCalculator
    {
        public static string CalculatePinBlock(string pin)
        {
            string pinblock = "";
            int len = pin.Length;
            if (len >= 10)
            {
                string lenn = len.ToString("X");
                pinblock = "0" + lenn + pin;
                pinblock = pinblock.PadRight(16, 'F');
            }
            else
            {
                pinblock = "0" + len + pin;
                pinblock = pinblock.PadRight(16, 'F');

            }
            return pinblock;
        }
        public static string CalculatePanBlock(string track2Data)
        {

            // Split the track2Data by '=' to extract the portion before '='
            string[] parts = track2Data.Split('=');
            string panblock = parts[0].Substring(1);
            panblock = panblock.Substring(0, panblock.Length - 1);
            int len = panblock.Length;
            if (len <= 12)
            {
                // If the length is less than or equal to 12, pad with '0' on the left
                panblock = panblock.PadLeft(16, '0');
            }
            else if (len >= 13)
            {
                // If the length is greater than or equal to 13, take the last 12 characters and add '0000' in front
                panblock = panblock.Substring(len - 12);
                panblock = "0000" + panblock;
            }

            return panblock;


            // Handle invalid track2Data format
            throw new ArgumentException("Invalid track2Data format");
        }
        public static string CalculatePinPanBlock(string hexString1, string hexString2)
        {


            char[] result = new char[hexString1.Length];
            for (int i = 0; i < hexString1.Length; i++)
            {
                int value1 = Convert.ToInt32(hexString1[i].ToString(), 16);
                int value2 = Convert.ToInt32(hexString2[i].ToString(), 16);
                int xorResult = value1 ^ value2;
                result[i] = Convert.ToChar(xorResult.ToString("X"));
            }

            return new string(result);

        }
        public static byte[] HexStringToByteArray(string hex)
        {
            int byteCount = hex.Length / 2;
            byte[] bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
            }
            return hex.ToString();
        }
        public static byte[] Encrypt3DES(byte[] data, byte[] key)
        {
            using (TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider())
            {
                // Set the encryption mode and padding
                desProvider.Mode = CipherMode.ECB;
                desProvider.Padding = PaddingMode.None;

                // Set the provided key
                desProvider.Key = key;

                // Create the encryptor
                ICryptoTransform encryptor = desProvider.CreateEncryptor();

                // Encrypt the data
                return encryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }
        public static string Encryption(List<DataElement> requiredDataelements)
        {
            string pin = "1234";
            string pinblock = PinPanBlockCalculator.CalculatePinBlock(pin)
;
            string pan = "";
            foreach (DataElement dataElement in requiredDataelements)
            {
                if (dataElement.Name == "Track 2 Data")
                {
                    pan = dataElement.Value;
                }
            }
            string panblock = CalculatePanBlock(pan);
            string key = "ED2307743BAFC53FA0315C89116BCABF";
            string pinpanblock = CalculatePinPanBlock(pinblock, panblock);
            byte[] dataBytes = HexStringToByteArray(pinpanblock);
            byte[] keyBytes = HexStringToByteArray(key)
;
            byte[] encryptedData = Encrypt3DES(dataBytes, keyBytes);
            string encryptedHex = ByteArrayToHexString(encryptedData);
            return encryptedHex;
        }
    }
}
