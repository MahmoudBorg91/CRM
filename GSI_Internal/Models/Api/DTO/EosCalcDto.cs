using System;

namespace GSI_Internal.Models.Api.DTO
{
    public class EosCalcDto
    {
        public DateTime JoiningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public double BasicSalary { get; set; }
        public double OtherAllowance { get; set; }
        public int NumberOfUnpaidLeaveDays { get; set; }
        public double ExhaustedVacationDays { get; set; }
    }
}
