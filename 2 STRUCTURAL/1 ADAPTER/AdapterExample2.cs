using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;


namespace adap4
{

    public class Manufacturer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Year { get; set; }

    }

    public  class ManufacturerDataProvider
{
    public List<Manufacturer> GetData() => new List<Manufacturer>
       {
            new Manufacturer { City = "Italy", Name = "Alfa Romeo", Year = 2016 },
            new Manufacturer { City = "UK", Name = "Aston Martin", Year = 2018 },
            new Manufacturer { City = "USA", Name = "Dodge", Year = 2017 },
            new Manufacturer { City = "Japan", Name = "Subaru", Year = 2016 },
            new Manufacturer { City = "Germany", Name = "BMW", Year = 2015 }
       };
}
 
public class XmlConverter
{
    public XDocument GetXML()
    {
        var xDocument = new XDocument();
        var xElement = new XElement("Manufacturers");     
        var xAttributes =  new ManufacturerDataProvider().GetData()
            .Select(m => new XElement("Manufacturer", 
                                new XAttribute("City", m.City),
                                new XAttribute("Name", m.Name),
                                new XAttribute("Year", m.Year)));
 
        xElement.Add(xAttributes);
        xDocument.Add(xElement);
 
        Console.WriteLine(xDocument);
 
        return xDocument;
    }
}

public class JsonConverter
{
    private IEnumerable<Manufacturer> _manufacturers;
    
    public JsonConverter(IEnumerable<Manufacturer> manufacturer)
    {
     this._manufacturers = manufacturer;

    }

    public void ConvertJson()
    {
        var JsonManufacturers = JsonConvert.SerializeObject(_manufacturers, Formatting.Indented);
        System.Console.WriteLine(JsonManufacturers);
    }
}


//ITarget interface 
public interface IXmlToJson
{
    void ConvertXmlToJson();
}

//adapter => 
public class XmlToJsonAdapter:IXmlToJson
{

    private readonly XmlConverter _xmlConverter;
    public XmlToJsonAdapter(XmlConverter xmlConverter)
    {
        this._xmlConverter = xmlConverter;
        
    }

    public void ConvertXmlToJson()
    {
        var manufacturers = _xmlConverter.GetXML()
            .Element("Manufacturers").Elements("Manufacturer")
            .Select(m => new Manufacturer
            {
                City = m.Attribute("City").Value,
                Name = m.Attribute("Name").Value,
                Year = Convert.ToInt32(m.Attribute("Year").Value)

            });

            new JsonConverter(manufacturers).ConvertJson();

    }

}



//adaptee 


}