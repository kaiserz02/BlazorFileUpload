using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace BlazorFileUpload.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ReferenceNumber")]
        [Name("ReferenceNumber")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string ReferenceNumber { get; set; }

        [Column("Quantity")]
        [Name("Quantity")]
        [Required]
        public long Quantity { get; set; }

        [Column("Amount")]
        [Name("Amount")]
        [Required]
        public decimal Amount { get; set; }

        [Column("Name")]
        [Name("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("Symbol")]
        [Name("Symbol")]
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string Symbol { get; set; }

        [Column("OrderSide")]
        [Name("OrderSide")]
        [Required]
        public string OrderSide { get; set; }


        [Column("OrderStatus")]
        [Name("OrderStatus")]
        [Required]
        public string OrderStatus { get; set; }

    }
}
