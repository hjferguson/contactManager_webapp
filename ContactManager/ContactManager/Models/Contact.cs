using System;
using System.ComponentModel.DataAnnotations;

public class Contact
{
	//always start with a primary key
	[Key]
	public int ContactId { get; set; }

	//Set attributes to '?' because we our binding our model to contact view, and on first build, all fields
	//will automatically be null. 
	[Required(ErrorMessage = "Please enter a valid first name")]
	public string? Firstname { get; set; }
    [Required(ErrorMessage = "Please enter a valid last name")]
    public string? Lastname { get; set; }
    [Required(ErrorMessage = "Please enter a valid phone number")]
    public string? Phone { get; set; }
    [Required(ErrorMessage = "Please enter a valid email")]
    public string? Email { get; set; }
	public string? Organization { get; set; }
	public DateTime DateAdded { get; set; }
	[Range(1,10,ErrorMessage = "Please select a valid category")] //index 0 will be default, hence range 1-10
	public int? CategoryId { get; set; } //this most important link. But need Category object to read data
	public Category Category { get; set; } //For associating CatID. Want access to the name in the category

	public string Slug => Firstname?.Replace(' ', '-').ToLower() + "-" 
						+ Lastname?.Replace(" ", "-").ToLower(); //=> is lambda. ? for if not null
}
