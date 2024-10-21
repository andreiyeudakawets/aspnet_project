﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_253505_Yeudakavets.Domain.Entities
{
	public class Clothing
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public Category Category { get; set; }
		public int CategoryId { get; set; }
		public decimal Price { get; set; }
		public string? Image {  get; set; }
	}
}
