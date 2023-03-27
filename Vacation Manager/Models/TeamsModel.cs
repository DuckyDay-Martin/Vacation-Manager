namespace Vacation_Manager.Models
{
    public class TeamsModel
    {
        int TeamID { get; set; }

        string TeamName { get; set; }

        string ProjectWorkingOn { get; set; }

        public List<UserModels> Developers { get; set; }

        string TeamLead { get; set; }
    }
}
