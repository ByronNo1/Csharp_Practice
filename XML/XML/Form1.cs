using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;



namespace XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument docT = new XmlDocument();
            XmlNode rootNode = docT.CreateNode(XmlNodeType.Element, "root", "");
            docT.AppendChild(rootNode);
            XmlDocument doc = new XmlDocument();
            string StrXml = string.Empty;
            string StrT = string.Empty;
            using (StreamReader SR = new StreamReader(Application.StartupPath + "\\XML.txt"))
            {
                StrXml = SR.ReadToEnd();
            }
            doc.LoadXml(StrXml);
            //XmlNodeList xnlA = doc.ChildNodes;
            //foreach (XmlNode xn in xnlA)
            //{
            //    XmlNodeList xnlB = xn.ChildNodes;
            //    foreach (XmlNode xnB in xnlB)
            //    {
            //        foreach (XmlNode xnC in xnB)
            //        {
            //            StrT = ((XmlElement)xnC).GetAttribute("titleA") ?? "";
            //            if (StrT != "" )
            //            {
            //                XmlNode importedNode = docT.ImportNode(xnC.Clone(), true);
            //                //XmlNode xnD = xnC.Clone();
            //                rootNode.AppendChild(importedNode);
            //            } 

                        
            //        }
            //    }
            //}
            DeepXML(doc, ref docT, "bookT");

        }



        private void DeepXML(XmlDocument SourceXmlDocument,ref XmlDocument outXml,string StrNoNODE = "")
        {
            XmlNodeList xnlA = SourceXmlDocument.ChildNodes;
            DeepXML(xnlA, ref outXml, StrNoNODE);

        }
        private void DeepXML(XmlNodeList SourceXmlDocument, ref XmlDocument outXml, string StrNoNODE = "")
        {
            foreach (XmlNode item in SourceXmlDocument)
            {
                if (item.NodeType.ToString() == "Text")
                {
                    //XmlElement TT =((XmlElement)item);
                    XmlNode importedNode = outXml.ImportNode(item.ParentNode.Clone(), true);
                    outXml.ChildNodes[0].AppendChild(importedNode);
                }
                else
                {
                    if (item.Name == StrNoNODE)
                    {

                    }
                    else
                    {
                        DeepXML(item.ChildNodes, ref outXml, StrNoNODE);
                    }
                   
                }
            }
        }


    }

}
