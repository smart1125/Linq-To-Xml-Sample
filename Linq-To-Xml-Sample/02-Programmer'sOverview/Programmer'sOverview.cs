using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_To_Xml_Sample._02_Programmer_sOverview
{
    class Programmer_sOverview
    {
        #region 使用 LINQ 查詢的結果填入 XML 樹狀結構
        /// <summary>
        /// 使用 LINQ 查詢的結果填入 XML 樹狀結構
        /// </summary>
        public void LINQCreateXml()
        {
            XElement srcTree = new XElement("Root",
            new XElement("Element", 1),
            new XElement("Element", 2),
            new XElement("Element", 3),
            new XElement("Element", 4),
            new XElement("Element", 5)
        );
            XElement xmlTree = new XElement("Root",
                new XElement("Child", 1),
                new XElement("Child", 2),
                from el in srcTree.Elements()
                where (int)el > 2
                select el
            );
            Console.WriteLine(xmlTree);

        }
        #endregion

        #region 使用功能結構建立XDocument
        /// <summary>
        /// 使用功能結構建立XDocument
        /// </summary>
        public void CreateXDocumentSample()
        {
            XDocument d = new XDocument(
                new XComment("This is a comment."),
                new XProcessingInstruction("xml-stylesheet",
                    "href='mystyle.css' title='Compact' type='text/css'"),
                new XElement("Pubs",
                    new XElement("Book",
                        new XElement("Title", "Artifacts of Roman Civilization"),
                        new XElement("Author", "Moreno, Jordao")
                    ),
                    new XElement("Book",
                        new XElement("Title", "Midieval Tools and Implements"),
                        new XElement("Author", "Gazit, Inbar")
                    )
                ),
                new XComment("This is another comment.")
            );

            d.Declaration = new XDeclaration("1.0", "utf-8", "true");
            Console.WriteLine(d);

            d.Save("test.xml");
        } 
        #endregion
    }
}
