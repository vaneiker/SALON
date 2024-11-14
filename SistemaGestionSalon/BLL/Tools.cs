using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Globalization;
using System.Reflection.Emit;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net.Http;
using System.Windows.Forms;
using iTextSharp.tool.xml;

namespace BLL
{
    public static class Tools
    {

        public class Validate
        {
            public string msj { get; set; }
            public bool? isValid { get; set; }
        }
        public class Img
        {
            public string Url { get; set; }
        }
        public static string NumberFormat = "#,0.00";
        public static Validate ValidatePassword(string password)
        {
            var result = new Validate();
            var input = password;


            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                result.msj = "La contraseña debe contener al menos una letra minúscula";
                result.isValid = false;
                return result;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                result.msj = "La contraseña debe contener al menos una letra mayúscula";
                result.isValid = false;
                return result;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                result.msj = $"La contraseña no debe tener menos ni más de 12 caracteres";
                result.isValid = false;
                return result;
            }
            else if (!hasNumber.IsMatch(input))
            {
                result.msj = "La contraseña debe contener al menos un valor numérico";
                result.isValid = false;
                return result;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                result.msj = "La contraseña debe contener al menos un carácter de caso especial";
                result.isValid = false;
                return result;
            }
            else
            {
                result.msj = Guid.NewGuid().ToString().Replace("-", "");
                result.isValid = true;
            }

            return result;
        }

        public static int GetRandomNumber(int min = 0, int max = 0)
        {
            Random num = new Random();
            return num.Next(min, max);
        }

        public static string Encrypt_Query(string cadena)
        {

            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            try
            {

                byte[] keyArray;
                //arreglo de bytes donde guardaremos el texto  
                //que vamos a encriptar  
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
                //se utilizan las clases de encriptación  
                //provistas por el Framework  
                //Algoritmo MD5     
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                //se guarda la llave para que se le realice  
                //hashing          
                keyArray = hashmd5.ComputeHash(

                UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo 3DAS  
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                //se empieza con la transformación de la cadena  
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                //arreglo de bytes donde se guarda la  
                //cadena cifrada  

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();

                //se regresa el resultado en forma de una cadena  

                return Convert.ToBase64String(ArrayResultado,

                      0, ArrayResultado.Length);

            }

            catch (Exception)
            {

            }

            return string.Empty;

        }

        public static string Decrypt_Query(string clave)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            try
            {

                byte[] keyArray;
                //convierte el texto en una secuencia de bytes  

                byte[] Array_a_Descifrar =
              Convert.FromBase64String(clave);

                //se llama a las clases que tienen los algoritmos  

                //de encriptación se le aplica hashing  

                //algoritmo MD5  
                MD5CryptoServiceProvider hashmd5 =
               new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(
                 UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes =
                new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;


                ICryptoTransform cTransform =

                 tdes.CreateDecryptor();


                byte[] resultArray =

                cTransform.TransformFinalBlock(Array_a_Descifrar,
                0, Array_a_Descifrar.Length);


                tdes.Clear();

                //se regresa en forma de cadena  
                return UTF8Encoding.UTF8.GetString(resultArray);
            }

            catch (Exception)
            {

            }

            return string.Empty;

        }

        public static string SerializeToXMLString(object obj)
        {
            string xmlString = string.Empty;
            XmlSerializer s = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, new UTF8Encoding());
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = ' ';
            writer.Indentation = 5;

            try
            {
                s.Serialize(writer, obj);
                xmlString = UTF8Encoding.UTF8.GetString(ms.ToArray());

            }
            finally
            {
                writer.Close();
                ms.Close();
            }

            return
                xmlString;
        }

        public static int QuantityOfMonth(DateTime dt, DateTime df)
        {
            int monthsApart = 12 * (dt.Year - df.Year) + dt.Month - df.Month;
            return Math.Abs(monthsApart);
        }

        public static int QuantityOfDays(DateTime dt, DateTime df)
        {
            int DaysApart = df.Date.Subtract(dt.Date).Days;
            return Math.Abs(DaysApart);
        }

        public static int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            return age;
        }

        public static string Encode(string encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }

        public static string getRamdonString()
        {
            Random rnd = new Random();
            int rndCode = rnd.Next(10000, 99999);
            return rndCode.ToString();
        }

        public static string MyRemoveInvalidCharacters(string value)
        {
            return value.Replace("\\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace(":", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("í", "i")
                         .Replace("á", "a").Replace("é", "e").Replace("ó", "o").Replace("ú", "u");
        }
        public static DateTime ConvertToDateTime(string datetimeEntry)
        {
            var result = DateTime.ParseExact(datetimeEntry.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return result;
        }
        public static string GenerarNombreUsuario(string nombreCompleto)
        {
            // Separar el nombre completo en partes
            var partes = nombreCompleto.Split(' ');

            // Tomar la primera inicial y el apellido o una combinación de nombres
            string nombreUsuario;

            if (partes.Length > 1)
            {
                // Obtener la primera inicial y el primer apellido
                string inicial = partes[0].Substring(0, 1).ToLower(); // Inicial del primer nombre
                string apellido = partes[partes.Length - 1].ToLower(); // Último apellido

                // Combinar para formar el nombre de usuario
                nombreUsuario = $"{inicial}{apellido}";
            }
            else
            {
                // Si solo hay un nombre, usarlo directamente
                nombreUsuario = partes[0].ToLower();
            }

            return nombreUsuario;
        }

        public static string GenerarCodigoProducto(int? contadorDiario)
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd"); // formato: 20241108 
            string secuencia = contadorDiario.Value.ToString("D3"); // 001, 002, etc. 
            return $"{fecha}{secuencia}";
        }

        public static void SavePDF(SaveFileDialog savefile,string htmlContent)
        { 
            using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(""));
                using (StringReader sr = new StringReader(htmlContent))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }
                pdfDoc.Close();
                stream.Close();
            }
        }

    }
}
