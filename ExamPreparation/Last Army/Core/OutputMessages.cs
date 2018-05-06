using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class OutputMessages
{
    // Soldier name - OverallSkill
    public const string SoldierToString = "{0} - {1}";

    // Mission name
    public const string MissionDeclined = "Mission declined - {0}";
    public const string MissionSuccessful = "Mission completed - {0}";
    public const string MissionOnHold = "Mission on hold - {0}";

    // Soldier type - Name
    public const string SoldierCannotBeEquiped = "There is no weapon for {0} {1}!";

    public const string Results = "Results:";
    public const string SuccessfulMissionsCount = "Successful missions - {0}";
    public const string FailedMissionsCount = "Failed missions - {0}";
    public const string Soldiers = "Soldiers:";
}

