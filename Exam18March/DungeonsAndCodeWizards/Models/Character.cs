using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public enum Faction { CSharp, Java }

    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public Faction Faction
        {
            get { return this.faction; }
            protected set { this.faction = value; }
        }

        public bool IsAlive { get; protected set; }

        public double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (hitPoints > this.Armor)
                {
                    hitPoints -= this.Armor;
                    this.Armor = 0;
                    this.Health -= hitPoints;
                }
                else
                {
                    this.Armor -= hitPoints;
                }

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health += this.BaseHealth * this.RestHealMultiplier;
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                  item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.isAlive)
            {
                character.Bag.AddItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
        }

        public override string ToString()
        {
            string status;
            if (this.IsAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }

            return $"{this.name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}


