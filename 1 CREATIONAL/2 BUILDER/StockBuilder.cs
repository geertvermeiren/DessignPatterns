using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StockReportBuilder{


    //IBuilder

    public interface IProductStockReportBuilder
    {
        void BuildHeader();
        void BuildBody(); 
        void BuildFooter();
    }


    //ConcreteBuilder

    public class ProductStockReportBuilder:IProductStockReportBuilder
    {

        private ProductStockReport  _productStockReport;
        private IEnumerable<Product> _products;

        public ProductStockReportBuilder(IEnumerable<Product> product)
        {
            this._products = product;
            this._productStockReport = new ProductStockReport();

        }

        public void BuildHeader()
    {
        _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
    }
 
    public void BuildBody()
    {
        _productStockReport.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
    }
 
    public void BuildFooter()
    {
        _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
    }

    //GET PRODUCT

    public ProductStockReport GetReport()
    {
        var productStockReport = _productStockReport;
        Clear();
        return productStockReport;
    } 

    private void Clear()
    {
        var _productStockReport = new ProductStockReport();
    }


    }


    //Product

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductStockReport
    {
        public string HeaderPart {get;set;}
        public string BodyPart { get; set; }
        public string FooterPart { get; set; }

         public override string ToString() =>
        new StringBuilder()
        .AppendLine(HeaderPart)
        .AppendLine(BodyPart)
        .AppendLine(FooterPart)
        .ToString();
    }


    //Director

    public class StockReportDirector
    {
        private readonly IProductStockReportBuilder _productStockReport;

        public StockReportDirector(IProductStockReportBuilder productStockReport)
        {
            this._productStockReport = productStockReport;
            
        }

        public void BuildStockReport()
        {
            _productStockReport.BuildHeader();
            _productStockReport.BuildBody();
            _productStockReport.BuildFooter();
        }


    }

    public class ClientStockBuilder
    {
        public ClientStockBuilder()
        {
             var products = new List<Product>
            {
                new Product{Name = "monitor", Price = 15},
                new Product{Name = "monitor1", Price = 12},
                new Product{Name = "monitor2", Price = 133},
                new Product{Name = "monitor3", Price = 1},
                new Product{Name = "monitor4", Price = 145},
                

            };

            var builder = new ProductStockReportBuilder(products);
            var director = new StockReportDirector(builder);
            director.BuildStockReport();

            var report = builder.GetReport();
            System.Console.WriteLine(report);

            
        }
    }

}