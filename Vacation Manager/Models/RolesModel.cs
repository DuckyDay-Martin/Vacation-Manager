namespace Vacation_Manager.Models
{
    public class RolesModel
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }

        public string RoleUser { get; set; }

        public RolesModel()
        {
            RoleName = "Unsigned";
        }


        public RolesModel(string roleName)
        {
            RoleName = roleName;
        }
    }
}
