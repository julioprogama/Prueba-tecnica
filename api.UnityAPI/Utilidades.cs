using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using api.modelo;

namespace api.UnityAPI
{
    public class Utilidades
    {
        public static void Main()
        {
            using (StreamWriter w = File.AppendText("c:/log.txt"))
            {
                Log("Test1", w);
                Log("Test2", w);
            }

            using (StreamReader r = File.OpenText("/log.txt"))
            {
                DumpLog(r);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("{0} {1} {2}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(), logMessage);
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }


        /// <summary>
        /// Encripta
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="pubKeyPath"></param>
        /// <returns></returns>
        public static string EncryptPassword(string plainText, string pubKeyPath)
        {
            //converting the public key into a string representation
            string pubKeyString;
            {
                using (StreamReader reader = new StreamReader(pubKeyPath)) { pubKeyString = reader.ReadToEnd(); }
            }
            //get a stream from the string
            var sr = new StringReader(pubKeyString);

            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));

            //get the object back from the stream
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters((RSAParameters)xs.Deserialize(sr));
            byte[] bytesPlainTextData = Encoding.Default.GetBytes(plainText);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
            //we might want a string representation of our cypher text... base64 will do
            string encryptedText = Convert.ToBase64String(bytesCipherText);
            return encryptedText;
        }


        private string privateKey = Path.GetFullPath("private.key");

        /// <summary>
        /// Des encripta
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public string DecryptPassword(string encryptedText )
        {
            //we want to decrypt, therefore we need a csp and load our private key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();

            string privKeyString;
            {
                privKeyString = File.ReadAllText(privateKey);
                //get a stream from the string
                var sr = new StringReader(privKeyString);
                //we need a deserializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //get the object back from the stream
                RSAParameters privKey = (RSAParameters)xs.Deserialize(sr);
                csp.ImportParameters(privKey);
            }


            byte[] bytesCipherText = Convert.FromBase64String(encryptedText);

            //decrypt and strip pkcs#1.5 padding
            byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);

            //get our original plainText back...
            // File.WriteAllBytes(filePath, bytesPlainTextData);

            string str = Encoding.Default.GetString(bytesPlainTextData);
            Console.WriteLine("The String is: " + str);
            return str;
        }

        private const double EarthRadius = 6371;
        public static double GetDistance(GeoCoordinate point1, GeoCoordinate point2)
        {
            double distance = 0;
            double Lat = (point2.Latitude - point1.Latitude) * (Math.PI / 180);
            double Lon = (point2.Longitude - point1.Longitude) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitude * (Math.PI / 180)) * Math.Cos(point2.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            
            distance = EarthRadius * c;

            return distance;
        }

    }
}
