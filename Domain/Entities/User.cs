using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entites;

public class User : BaseEntity
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string PasswordHash { get; set; }
}
