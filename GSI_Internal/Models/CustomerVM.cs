﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class CustomerVM
    {

        [Key]
        public int ID { get; set; }
        public DateTime Thedate { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustName { get; set; }
        [Required]
        public int GovermnetID { get; set; }
        public string GovermentName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string PersonKeyNAme { get; set; }
        [Required]
        public string PersonKeyPhone { get; set; }
        [Required]
        public string PersonKeyJop { get; set; }
        public string Email { get; set; }
    }
}
