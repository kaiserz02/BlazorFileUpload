using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace BlazorFileUpload.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Ignore]
        public int Id { get; set; }

        [Column("reference_number")]
        [Name("reference_number")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string ReferenceNumber { get; set; }

        [Column("remarks")]
        [Name("remarks")]
        [StringLength(20)]
        public string Remarks { get; set; }

        [Column("quantity")]
        [Name("quantity")]
        [Required]
        public long Quantity { get; set; }

        [Column("amount")]
        [Name("amount")]
        [Required]
        public decimal Amount { get; set; }

        [Column("name")]
        [Name("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("transaction_date")]
        [Name("transaction_date")]
        [Required]
        public DateTime TransactionDate { get; set; }

        [Column("symbol")]
        [Name("symbol")]
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string Symbol { get; set; }

        [Column("order_side")]
        [Name("order_side")]
        [Required]
        public string OrderSide { get; set; }


        [Column("order_status")]
        [Name("order_status")]
        [Required]
        public string OrderStatus { get; set; }

    }
}
