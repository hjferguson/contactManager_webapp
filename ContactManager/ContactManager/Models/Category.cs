using System;
using System.ComponentModel.DataAnnotations;

public class Category
{
	[Key] //added this to declare key of category
	public int CategoryId { get; set; }

	public string Name { get; set; }
}
