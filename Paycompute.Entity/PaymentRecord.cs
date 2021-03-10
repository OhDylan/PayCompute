using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paycompute.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public string Nino { get; set; } // National Insurance No.
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal(18, 2)")] // For OvertimeHours is decimal time, so 18 represents the scale and 2 represents two decvimal points to the right
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal NIC { get; set; } // National Insurance Contribution
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; } // By placing '?' means this property is optional
        [Column(TypeName = "money")]
        public Nullable<decimal> SLC { get; set; } //Student loan repayment // This is another way of making the property optional
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName ="money")] // Avoid truncation
        public decimal NetPayment { get; set; }
    }
}
