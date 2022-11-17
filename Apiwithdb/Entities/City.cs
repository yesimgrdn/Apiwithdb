using System.ComponentModel.DataAnnotations;

namespace Apiwithdb.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }    
        public ICollection<Personel> ?Personel { get; set; }
    }
}
