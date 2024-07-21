using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var empolyee = new emp
            {
                id = 100,
                name = "test",
                age = 5,
                titles = new List<string> { "staff","supervisor"}
            };
            var Xmlcontent = SerializationXmlString(empolyee);
            Console.WriteLine(Xmlcontent);
            File.WriteAllText("document.xml", Xmlcontent);

            var conten2 = File.ReadAllText("document.xml");
            emp emp1 = DeserializationxmlString(conten2);

            Console.ReadKey();
        }

        private static emp DeserializationxmlString(string conten2)
        {
            emp emp = null;
            var xmlSerializor = new XmlSerializer(typeof(emp));
            using(TextReader reader = new StringReader(conten2))
            {
                emp = xmlSerializor.Deserialize(reader) as emp;
            }
            return emp;
        }

        public static string SerializationXmlString(emp empolyee)
        {
            var result = "";
            var XmlSerializor = new XmlSerializer(empolyee.GetType());
            using(var sw = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sw,new XmlWriterSettings { Indent= true}))
                {
                    XmlSerializor.Serialize(writer, empolyee);
                    result = sw.ToString();

                }
            }
            return result ;
        }
    }
}
