using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
	public class Customer
	{
		public int Id { get; set; }

		// Overriding default conventions (for Name property) - Data Annotations (or Fluent API)
		/*
		 Apply the Data Annotation (i.e. attribute) Required which makes our column name no longer nullable 
		 Apply StringLength to supply the max number of characters		 
		 */ 
		[Required(ErrorMessage = "Please enter customer's name")] // so now our column name is no longer nullable
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribedToNewsletter { get; set; }

		// Associating our customer class/model with membership type
		// A navigation property as it allows us to navigate from one type to another e.g. from customer to it's membership type
		// This is useful when we want to load an object and its related objects together from a DB 
		// e.g. we can load the customer and its membership type together from the DB
		public MembershipType MembershipType { get; set; }

		// Sometimes for optimisation we do not want to load the entire membership object and may only need to load the foreign key
		// EF recognises this convention and treats the following property as a foreign key
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }
		// byte means it's implicitly required

		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}