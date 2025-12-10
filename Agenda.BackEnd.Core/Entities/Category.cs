using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class Category: BaseEntity
    {
        public Category(string alias):base(DateTime.Now)
        {
            Alias = alias;
        }

        [MaxLength(15)]
        public string Alias { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public void Update(Category  categoryUpdated)
        {
            Alias = string.IsNullOrEmpty(categoryUpdated.Alias) ? Alias : categoryUpdated.Alias;
        }
    }
}