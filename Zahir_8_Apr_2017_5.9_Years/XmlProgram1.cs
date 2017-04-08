using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zahir_8_Apr_2017_5._5Years
{
    class XmlProgram1
    {
        

        public static void Task1()
        {
            Console.WriteLine("Enter a Option:");
            Console.WriteLine("1. Read XML");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Delete Existing Employee");
            string option = Console.ReadLine();
            XmlProgram1 xmlProg1 = new XmlProgram1();

            string applicationLocation = AppDomain.CurrentDomain.BaseDirectory;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(applicationLocation + "/Employee.xml");

            switch (option)
            {
                case "1":
                    XMLHelper.ReadXML(xmlDoc);
                    Task1();
                    break;
                case "2":
                    
                    xmlDoc = XMLHelper.AddEmployee(xmlDoc);
                    xmlDoc.Save(applicationLocation + "/Employee.xml");
                    XMLHelper.ReadXML(xmlDoc);
                    Task1();
                    break;

                case "3":
                    
                    XMLHelper.DeleteEmployee(xmlDoc);
                    Task1();
                    break;
            }
           
        }

       
        
    }
}
