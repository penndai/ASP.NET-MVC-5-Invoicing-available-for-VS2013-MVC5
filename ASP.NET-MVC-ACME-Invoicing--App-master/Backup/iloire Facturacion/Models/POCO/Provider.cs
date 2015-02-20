﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public class Provider {

    public int ProviderID {get;set;}

    [Required]
    public string Name { get; set; }

    [DisplayName("Company Number")]
    //[Required]
    public string CompanyNumber { get; set; }

    //[Required]
    public string Address { get; set; }

    //[Required]
    [DisplayName("Zip Code")]
    public string CP { get; set; }
    
    //[Required]
    public string City { get; set; }

    //[Required]
    [DisplayName("Telephone")]
    public string Phone1 { get; set; }

     [DisplayName("Mobile")]
    public string Phone2 { get; set; }

    public string Fax { get; set; }

    //[Required]
    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
    public string Email { get; set; }
    
    public virtual ICollection<Purchase> Purchases { get; set; }
}