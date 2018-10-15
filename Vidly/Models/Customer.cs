﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "The Max Length is 255")]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool isSubscribedToNewsLetter { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Membership Type is required")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Min18YearsIfWholeYear]
        public DateTime? Birthdate { get; set; }
    }
}