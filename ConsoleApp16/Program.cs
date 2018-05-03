using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            var paljuTooteid = new List<Toode>();
            var toode1 = new Toode() { Nimi = "Banaan", Hind = "12" };
            var toode2 = new Toode() { Nimi = "Leib", Hind = "14" };
            var toode3 = new Toode() { Nimi = "Sai", Hind = "16" };
            var toode4 = new Toode() { Nimi = "Mahl", Hind = "17" };
            var toode5 = new Toode() { Nimi = "Liha", Hind = "77" };

            paljuTooteid.Add(toode1);
            paljuTooteid.Add(toode2);
            paljuTooteid.Add(toode3);
            paljuTooteid.Add(toode4);
            paljuTooteid.Add(toode5);

            var serializer = new XmlSerializer(paljuTooteid.GetType());
            using(var writer = XmlWriter.Create("tooted.xml"))
            {
                serializer.Serialize(writer, paljuTooteid);
            }

        }
    }
}
