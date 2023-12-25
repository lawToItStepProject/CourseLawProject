using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLawProject.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
    }

    public class Admin : User
    {
        public int? AccessMode { get; set; }
    }
    public class Client:User
    {
        public string Adress {  get; set; } = null!;
        
    }
    public class Individual : Client
    {
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string Surname { get; set; } = null!;
        public long RNOKPP { get; set; } 
    }

    public enum LegalOrganizationForms
    {
        TOV,
        TDV,
        PP,
        AO
    }

    public class LegalEntity : Client
    {
        public LegalOrganizationForms OrganizationForm { get; set; } 
        public string Name { get; set; } = null!;
        public int CodeEDRPOU {  get; set; }

    }

}
