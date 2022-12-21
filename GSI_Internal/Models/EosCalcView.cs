using GSI_Internal.Entites;
using Microsoft.CodeAnalysis;
using System;

namespace GSI_Internal.Models
{
    public class EosCalcView
    {
        public int MoveType { get; set; } //0 , 1
        public DateTime JoiningDate { get; set; }
        public DateTime EndingDate { get; set; }

        public string JoiningDate_Result { get; set; }
        public string EndingDate_Result{ get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public int NumberOfUnpaidLeaveDays { get; set; }
        public double ActWorkPerMonth { get; set; }
        public double BasicSalary { get; set; }
        public double OtherAllowance { get; set; }
        public double TotalSalary { get; set; }
        public double EndOfServiceBenefit { get; set; }

        public double AccruedVacationDays { get; set; }
        public double ExhaustedVacationDays { get; set; }
        public double remainingVacationDays { get; set; }
        public double AmountDue { get; set; }
        public double TotalBenefitsAndVacations { get; set; }


    }
}
