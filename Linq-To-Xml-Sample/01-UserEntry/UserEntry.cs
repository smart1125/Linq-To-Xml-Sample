using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_To_Xml_Sample._01_UserEntry
{
    public class UserEntry
    {
        #region LINQtoXML及方法語法形式改寫
        /// <summary>
        /// LINQtoXML及方法語法形式改寫
        /// </summary>
        public void LINQtoXML()
        {
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);
            XElement purchaseOrder = XElement.Load($"{purchaseOrderFilepath}");
            IEnumerable<string> partNos = from item in purchaseOrder.Descendants("Item")
                                          select (string)item.Attribute("PartNumber");

            //方法語法的形式改寫
            //IEnumerable<string> partNos = purchaseOrder.Descendants("Item").Select(x => (string)x.Attribute("PartNumber"));


            IEnumerable<XElement> pricesByPartNos = from item in purchaseOrder.Descendants("Item")
                                                    where (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100
                                                    orderby (string)item.Element("PartNumber")
                                                    select item;

            //方法語法的形式改寫
            /*IEnumerable<XElement> pricesByPartNos = purchaseOrder.Descendants("Item")
                                        .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                                        .OrderBy(order => order.Element("PartNumber"));*/


        }
        #endregion  

        #region 建立XML排列方式
        /// <summary>
        /// 建立XML排列方式
        /// </summary>
        public void createXml()
        {
            XElement contacts =
            new XElement("Contacts",
              new XElement("Contact",
                new XElement("Name", "Patrick Hines"),
                new XElement("Phone", "206-555-0144",
                  new XAttribute("Type", "Home")),
                new XElement("phone", "425-555-0145",
                  new XAttribute("Type", "Work")),
                new XElement("Address",
                  new XElement("Street1", "123 Main St"),
                  new XElement("City", "Mercer Island"),
                  new XElement("State", "WA"),
                  new XElement("Postal", "68042")
                    )
                )
            );

        }
        #endregion
    }
}
