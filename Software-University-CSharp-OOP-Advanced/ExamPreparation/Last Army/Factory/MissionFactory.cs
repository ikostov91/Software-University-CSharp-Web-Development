using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == difficultyLevel);
        // Activator.CreateInstance returns object (cast to IMission is needed)
        return (IMission)Activator.CreateInstance(type, neededPoints);
    }
}

