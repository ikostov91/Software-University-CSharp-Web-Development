using System.Xml.Serialization;
using FastFood.DataProcessor.Dto.Export;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("Category")]
    public class CategoryDto
    {
        public string Name { get; set; }

        public ItemDto MostPopularItem { get; set; }
    }
}
