using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyArmory.Lib.WoW {
    public class GearInformation {

        private GearInformation() { }

        private static string[] gearNames = { 
                                         "Head",
                                         "Neck", 
                                         "Shoulder", 
                                         "Shirt", 
                                         "Chest", 
                                         "Belt", 
                                         "Legs", 
                                         "Boots", 
                                         "Wrist", 
                                         "Hands", 
                                         "Ring", 
                                         "Ring", 
                                         "Trinket", 
                                         "Trinket", 
                                         "Back", 
                                         "Main-Hand", 
                                         "Off-Hand", 
                                         "Ranged", 
                                         "Tabard", 
                                         "Ammo", 
                                     };

        public static string GetSlotName(int slot) {
            if (slot == -1) {
                return "Ammo";
            } else {
                return gearNames[slot];
            }
        }
    }
}
