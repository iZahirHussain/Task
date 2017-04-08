using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zahir_8_Apr_2017_5._5Years
{
    public static class XMLHelper
    {
        public static XmlDocument AddEmployee(XmlDocument doc)
        {
            Employee emp = new Employee();
            Console.WriteLine("Getting Employee Details:");
            Console.WriteLine("Enter Name:");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int age = 0;
            emp.Age = age;
            if (int.TryParse(Console.ReadLine(), out age))
                emp.Age = age;
            else
                Console.WriteLine("Invalid Age !!!");
            
            Console.WriteLine("Enter Desgination:");
            emp.Desigination = Console.ReadLine();

            XmlNode fileNode = doc.SelectSingleNode("/employees");

            //Employee
            XmlNode employeeNode = doc.CreateElement("employee");



            //Details:
            //name
            XmlNode xmlNode = doc.CreateElement("name");
            xmlNode.InnerText = emp.Name;
            employeeNode.AppendChild(xmlNode);

            //age
            xmlNode = doc.CreateElement("age");
            xmlNode.InnerText = Convert.ToString(emp.Age);
            employeeNode.AppendChild(xmlNode);

            //designation
            xmlNode = doc.CreateElement("designation");
            xmlNode.InnerText = emp.Desigination;
            employeeNode.AppendChild(xmlNode);


            //XmlNode importNewsItem = doc.ImportNode(doc.SelectSingleNode("employees"), true);
            //importNewsItem.AppendChild(employeeNode);


            fileNode.AppendChild(employeeNode);


            //doc.DocumentElement.AppendChild(importNewsItem);

            return doc;


        }


        public static void ReadXML(XmlDocument xmlDoc)
        {
            string applicationLocation = AppDomain.CurrentDomain.BaseDirectory;
            string xmlLocation = applicationLocation + "/Employee.xml";
            xmlDoc.Load(xmlLocation);

            XmlNode employeeListNode =
                xmlDoc.SelectSingleNode("/employees");

            XmlNodeList employeeListNodeList =
                employeeListNode.SelectNodes("employee");
            List<Employee> employeeList = new List<Employee>();
            foreach (XmlNode node in employeeListNodeList)
            {
                Employee emp = new Employee();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "name":
                            emp.Name = childNode.InnerText;
                            break;
                        case "age":
                            emp.Age = Convert.ToInt32(childNode.InnerText);
                            break;


                        case "designation":
                            emp.Desigination = childNode.InnerText;
                            break;

                        case "address":
                            emp.Desigination = childNode.InnerText;
                            break;
                    }
                }
                if(emp.Name!=null)
                employeeList.Add(emp);
            }

            int i = 0;
            foreach (Employee emp in employeeList)
            {
                i++;
                Console.WriteLine("Employee No." + i);
                Console.WriteLine("Name:" + emp.Name);
                Console.WriteLine("Age:" + emp.Age);
                Console.WriteLine("Designation:" + emp.Desigination);
                Console.WriteLine("Address:" + emp.Address);
                Console.WriteLine();
            }
            Console.ReadKey();

        }

        public static void DeleteEmployee(XmlDocument xmlDoc)
        {
            string empName;
            Console.WriteLine("Enter Name to Delete:");
            empName = Console.ReadLine();


            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/employees/employee");
            foreach (XmlNode node in xmlNodeList)
            {
                 bool isDeletedNode = false;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                   
                    if (childNode.InnerText.Trim().ToLower() == empName.ToLower())
                    {

                        childNode.ParentNode.RemoveAll();
                        isDeletedNode = true;
                    }
                    if (isDeletedNode)
                    {
                        childNode.RemoveAll();
                    }

                }

                if (isDeletedNode)
                {
                    node.RemoveAll();
                    Console.WriteLine("Employee: " + empName + " Deleted successfully.");
                }
            }
            string applicationLocation = AppDomain.CurrentDomain.BaseDirectory;
            string xmlLocation = applicationLocation + "/Employee.xml";
            xmlDoc.Save(xmlLocation);

            XMLHelper.ReadXML(xmlDoc);

        }
    }
}
