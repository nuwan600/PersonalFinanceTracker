using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Entities.DTO
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
