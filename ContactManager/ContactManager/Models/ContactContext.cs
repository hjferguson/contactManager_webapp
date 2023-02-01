using Microsoft.EntityFrameworkCore;
using System;
//boilerplate for all context files in this class
public class ContactContext : DbContext //need to install Microsoft.EntityFrameworkCore. 
										//Also installed Microsoft.EntityFrameworkCore.SqlServer for migration scripts later on
{
	public ContactContext(DbContextOptions<ContactContext> options)
		: base(options) { }

	//need 2 db sets. category and contact

	public DbSet<Contact> Contacts { get; set;} //get records / modify records in the table

	public DbSet<Category> Categories { get; set;} //tend to pluralize names of db sets

	//need a means to seed our database. Helps with testing. Need data in the db to ensure everything working.

	protected override void OnModelCreating(ModelBuilder modelBuilder) //when creating model, insert this info
	{
		//contacts take categories, so we should seed categories table first
		//can add more later, this is just initial set up. 
		modelBuilder.Entity<Category>().HasData(
			new Category { CategoryId = 1, Name = "Friend" },
			new Category { CategoryId = 2, Name = "Work" },
			new Category { CategoryId = 3, Name = "Family" }
			);

		modelBuilder.Entity<Contact>().HasData(
			new Contact
			{
				ContactId = 1,
				Firstname = "Bruce",
				Lastname = "Wayne",
				Phone = "416-260-1234",
				Email = "notBatman@gmail.com",
				CategoryId = 1,
				DateAdded = DateTime.Now
			},
            new Contact
            {
                ContactId = 2,
                Firstname = "Peter",
                Lastname = "Parker",
                Phone = "446-460-1234",
                Email = "notSpiderman@gmail.com",
                CategoryId = 2,
                DateAdded = DateTime.Now
            }
            ) ;
    }



}
