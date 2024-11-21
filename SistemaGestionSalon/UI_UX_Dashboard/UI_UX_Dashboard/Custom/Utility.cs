using iTextSharp.text.log;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace UI_UX_Dashboard_P1.Custom
{
    public static class Utility
    {
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

        public static string CleanXMLToParse(string xml)
        {
            var result = string.Empty;
            result = xml.Replace("utf-16", "utf-8").Trim().Replace("^([\\W]+)<", "<");
            return result;
        }

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                // Writes a block of bytes to this stream using data from a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Flush();
                _FileStream.Close();
                _FileStream.Dispose();
                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        public static void deleteFiles(string path, string fileName)
        {
            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);

                foreach (System.IO.FileInfo file in di.GetFiles())
                {
                    if (file.Name == fileName)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void DeleteFile(string filename)
        {
            try
            {
                System.IO.File.Delete(filename);
            }
            catch (Exception ee)
            { }
        }
        public static bool IsEncoded(string input)
        {
            try
            {
                var decodedBytes = Convert.FromBase64String(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #region fill marbete pasta
        private static string CopyFile(string filename = null, string targPath = "", string MarbetePath = "", bool isFull = false)
        {
            filename = filename.Replace(".pdf", "") ?? "Marbete";
            string targetPath = string.Concat(targPath, filename, ".pdf");


            File.Copy(MarbetePath, targetPath, true);
            return targetPath;
        }

        public static void DeleteTemplate(bool isFull = false, string path = "")
        {
            //if (isFull)
            //{
            //    var files = Directory.GetFiles(path).Where(o => o.Contains("Marbete_full")).ToList();
            //    if (files.Any())
            //        files.ForEach(o => File.Delete(o));
            //}
            //else
            //{
            var files = Directory.GetFiles(path).Where(o => o.Contains("Marbete")).ToList();
            if (files.Any())
                files.ForEach(o => File.Delete(o));
            //}

        }

        private static Tuple<byte[], int> GeneratePDF(string pdfPath, Dictionary<string, string> formFieldMap, bool applyBoldText = false)
        {
            var tupleResult = new Tuple<byte[], int>(null, 0);
            var output = new MemoryStream();
            var reader = new PdfReader(pdfPath);
            var stamper = new PdfStamper(reader, output);
            var formFields = stamper.AcroFields;
            foreach (var fieldName in formFieldMap.Keys)
            {
                if (applyBoldText)
                    formFields.SetFieldProperty(fieldName, "textfont", iTextSharp.text.Font.BOLD, null);
                formFields.SetField(fieldName, formFieldMap[fieldName]);
            }
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            tupleResult = Tuple.Create(output.ToArray(), reader.NumberOfPages);
            return tupleResult;
        }
        #endregion


    }
}
