using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuroFusionLib
{
    public class dtotblPI_Applications
    {
        public int idPI_Application { get; set; }
        public string ApplicationName { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
    public class dtotblEmployee
    {
        public int idEmployee { get; set; }
        public string PI_EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public System.DateTime DateHired { get; set; }
        public string ActiveDirectoryName { get; set; }
        public Nullable<int> idEmployeeFunction { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public partial class tblPI_ApplicationUser
    {
        public int idPI_ApplicationUser { get; set; }
        public int idPI_Application { get; set; }
        public int idEmployee { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string EncryptedPassword { get; set; }
        public string Password { get; set; }
    }
    public class dtotblPI_ApplicationUserRole
    {
        public int idPI_ApplicationUserRole { get; set; }
        public int idPI_ApplicationUser { get; set; }
        public int idPI_ApplicationRole { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
    public class dtotblPI_ApplicationRoles
    {
        public int idPI_ApplicationRole { get; set; }
        public int idPI_Application { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }

}
