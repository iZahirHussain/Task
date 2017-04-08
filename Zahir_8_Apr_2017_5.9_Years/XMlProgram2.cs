using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zahir_8_Apr_2017_5._5Years
{
    public class XMlProgram2
    {
        public static string xmlLocation=string.Empty;
        public static void Task2()
        {
            Console.WriteLine("Enter a Option:");
            Console.WriteLine("1. Add Address");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Delete Existing Employee");
            string option = Console.ReadLine();
            XMlProgram2 xmlProg2 = new XMlProgram2();

            string applicationLocation = AppDomain.CurrentDomain.BaseDirectory;
            XmlDocument xmlDoc = new XmlDocument();
            xmlLocation = applicationLocation + "/Employee.xml";
            xmlDoc.Load(xmlLocation);

            switch (option)
            {
                case "1":
                    xmlProg2.AddAddressElement(xmlDoc);
                    break;
                case "2":
                    XMLHelper.AddEmployee(xmlDoc);
                    break;
                case "3":
                    XMLHelper.DeleteEmployee(xmlDoc);
                    break;
            }
        }

        private void AddAddressElement(XmlDocument xmlDoc)
        {
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/employees/employee");
            foreach (XmlNode node in xmlNodeList)
            {
                if (node.SelectNodes("address").Count == 0)
                {
                    XmlNode addressNode = xmlDoc.CreateElement("address");
                    addressNode.InnerText = "Sample Address";
                    node.AppendChild(addressNode);
                }
            }
            xmlDoc.Save(xmlLocation);
            Console.WriteLine("Address Added Successfully.");
            XMLHelper.ReadXML(xmlDoc);
        }
    }
}
