using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls.Primitives;

namespace Library
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
        public string Book_Type { get; set; }
        public decimal Price { get; set; }
        public int Pages_Nbr { get; set; }
        public bool Disponibility { get; set; }
      

    }
}
