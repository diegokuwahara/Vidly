using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "The Max Length is 255")]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool isSubscribedToNewsLetter { get; set; }

        [Required(ErrorMessage = "Membership Type is required")]
        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }

        [Min18YearsIfWholeYear]
        public DateTime? Birthdate { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }
    }
}