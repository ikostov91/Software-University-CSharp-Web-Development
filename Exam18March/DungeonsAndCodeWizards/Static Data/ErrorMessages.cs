using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public static class ErrorMessages
    {
        public static string InvalidName = "Name cannot be null or whitespace";
        public static string FullBag = "Bag is full!";
        public static string EmptyBag = "Bag is empty!";
        public static string InvalidCharacterType = "Invalid character type \"{0}\"!";
        public static string InvalidFaction = "Invalid faction \"{0}\"!";
        public static string CharacterNotFound = "Character {0} not found!";
        public static string NoItemsInPool = "No items left in pool!";
        public static string ItemNotInBag = "No item with name {0} in bag!";
        public static string CannotAttackSelf = "Cannot attack self!";
        public static string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";
        public static string CannotAttack = "{0} cannot attack!";
        public static string CannotHealEnemy = "Cannot heal enemy character";
        public static string CannotHeal = "{0} cannot heal!";
    }
}
