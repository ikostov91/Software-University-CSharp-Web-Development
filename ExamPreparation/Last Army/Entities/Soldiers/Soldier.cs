using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int baseRegenerateIncrease = 10;

    private const double maxEndurance = 100;

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    private double endurance;
    public double Endurance
    {
        get { return endurance; }
        private set
        {
            endurance = Math.Min(value, maxEndurance);
        }
    }

    protected abstract double OverallSkillMultiplier { get; }
    public double OverallSkill => (this.Age + this.Experience) * OverallSkillMultiplier;

    protected abstract List<string> WeaponsAllowed { get; }
    public IDictionary<string, IAmmunition> Weapons { get; }

    protected virtual int RegenerateIncrease => baseRegenerateIncrease; 

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values.Where(w => w != null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0)
            {
                Weapons[weapon.Name] = null;
            }
        }
    }

   public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        // Check whether all weapons are not null
        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        // If all weapons' wear level is above zero, soldier is ready for mission
        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + RegenerateIncrease;
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}