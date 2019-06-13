using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
	public class MembershipType
	{
		// In EF each entity must have a key which will be mapped to the primary key of the corresponding table 
		// in the DB. Conventionally named Id or name of type and id
		public byte Id { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }

		[Required]
		public string MembershipTypeName { get; set; }
	}
}