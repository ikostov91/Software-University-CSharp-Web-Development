using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> allCharacters;
        private List<Item> itemPool;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            allCharacters = new List<Character>();
            itemPool = new List<Item>();
            lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string factionType = args[0];

            Faction faction;
            switch (factionType)
            {
                case "CSharp":
                    faction = Faction.CSharp;
                    break;
                case "Java":
                    faction = Faction.Java;
                    break;
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidFaction, factionType));
            }

            string classType = args[1];
            string name = args[2];

            Character character;
            switch (classType)
            {
                case "Warrior":
                    character = new Warrior(name, faction);
                    break;
                case "Cleric":
                    character = new Cleric(name, faction);
                    break;
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacterType, classType));
            }
            allCharacters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;
            switch (itemName)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
            itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            CheckIfCharacterIsPresent(characterName);
            Character character = allCharacters.FirstOrDefault(x => x.Name == characterName);

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(ErrorMessages.NoItemsInPool);
            }

            Item item = itemPool[itemPool.Count - 1];
            itemPool.RemoveAt(itemPool.Count - 1);
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            CheckIfCharacterIsPresent(characterName);

            Character character = allCharacters.FirstOrDefault(x => x.Name == characterName);
            Item item = character.Bag.GetItem(itemName);
            item.AffectCharacter(character);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckIfCharacterIsPresent(giverName);

            Character giver = allCharacters.FirstOrDefault(x => x.Name == giverName);

            CheckIfCharacterIsPresent(receiverName);

            Character receiver = allCharacters.FirstOrDefault(x => x.Name == receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckIfCharacterIsPresent(giverName);

            Character giver = allCharacters.FirstOrDefault(x => x.Name == giverName);

            CheckIfCharacterIsPresent(receiverName);

            Character receiver = allCharacters.FirstOrDefault(x => x.Name == receiverName);

            Item item = giver.Bag.GetItem(itemName);
            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Final stats:");
            foreach (var character in allCharacters.OrderByDescending(x => x.IsAlive).ThenByDescending(y => y.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            CheckIfCharacterIsPresent(attackerName);
            Character attacker = allCharacters.FirstOrDefault(x => x.Name == attackerName);

            CheckIfCharacterIsPresent(receiverName);
            Character receiver = allCharacters.FirstOrDefault(x => x.Name == receiverName);

            if (!(attacker.GetType().Name == "Warrior"))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            Warrior warrior = (Warrior) attacker;

            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();
            sb.Append($"{warrior.Name} attacks {receiver.Name} for {warrior.AbilityPoints} hit points! ");
            sb.AppendLine($"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            CheckIfCharacterIsPresent(healerName);
            Character healer = allCharacters.FirstOrDefault(x => x.Name == healerName);

            CheckIfCharacterIsPresent(healingReceiverName);
            Character healingReceiver = allCharacters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (!(healer.GetType().Name == "Cleric"))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            Cleric cleric = (Cleric) healer;

            cleric.Heal(healingReceiver);

            return $"{cleric.Name} heals {healingReceiver.Name} for {cleric.AbilityPoints}! " +
                   $"{healingReceiver.Name} has {healingReceiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (allCharacters.Where(x => x.IsAlive).Count() <= 1)
            {
                lastSurvivorRounds += 1;
            }

            foreach (var character in allCharacters)
            {
                if (character.IsAlive)
                {
                    double healthBefore = character.Health;
                    character.Rest();
                    sb.Append($"{character.Name} rests ({healthBefore} => {character.Health})" + Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        public bool IsGameOver()
        {
            return lastSurvivorRounds > 1;
        }

        private void CheckIfCharacterIsPresent(string name)
        {
            if (!allCharacters.Any(x => x.Name == name))
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, name));
            }
        }
    }
}
