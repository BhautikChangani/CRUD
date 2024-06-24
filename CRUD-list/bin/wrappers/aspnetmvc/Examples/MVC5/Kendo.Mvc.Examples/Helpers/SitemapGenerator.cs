using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Kendo.Mvc.Examples
{
    public static class SitemapGenerator
    {
        static XmlDocument doc;
        static XmlElement root;

        public static XmlDocument Generate(IEnumerable<NavigationWidget> widgets)
        {
            //create sitemap xml document
            doc = new XmlDocument();
            root = CreateBasicSitemapMetadata(doc);

            // add main demo page
            AddSitemapDemo(string.Empty);

            // add demo links
            foreach (NavigationWidget widget in widgets)
            {
                foreach (NavigationExample example in widget.Items)
                {
                    if (example.ShouldInclude())
                    {
                        AddSitemapDemo(example.Url);
                    }
                }
            }

            // add sample-app links
            (new List<string>() {
                "bootstrap", "tripxpert", "olympic-games", "webmail", "html5-dashboard-sample-app"
            }).ForEach(x => AddSitemapDemo(x));

            // return the generated xml document
            return doc;
        }

        private static void AddSitemapDemo(string exampleUrl)
        {
            string basePath = "https://demos.telerik.com/aspnet-mvc/";
            XmlElement url = doc.CreateElement(string.Empty, "url", string.Empty);
            XmlElement loc = doc.CreateElement(string.Empty, "loc", string.Empty);

            loc.InnerText = string.Concat(basePath, exampleUrl);

            url.AppendChild(loc);
            root.AppendChild(url);
        }

        public static XmlElement CreateBasicSitemapMetadata(XmlDocument doc)
        {
            //for sitemap xml generation
            string xmlnsXsi = @"http://www.w3.org/2001/XMLSchema-instance";
            string xmlns = @"http://www.sitemaps.org/schemas/sitemap/0.9";
            string schemaLocLocation = @"http://www.w3.org/2001/XMLSchema-instance";
            string schemaLocation = @"http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";

            XmlElement root = doc.CreateElement(string.Empty, "urlset", string.Empty);
            root.SetAttribute("xmlns:xsi", xmlnsXsi);
            root.SetAttribute("xmlns", xmlns);

            //creating this attribute is tough, the easy approaches drop the "xsi:" prefix for some reason
            XmlAttribute schemaLoc = doc.CreateAttribute("xsi", "schemaLocation", schemaLocLocation);
            schemaLoc.Value = schemaLocation;
            root.SetAttributeNode(schemaLoc);

            doc.AppendChild(root);

            return root;
        }
    }
}
