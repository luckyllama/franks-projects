using LuckyArmoryLibrary.WoW;

namespace LuckyArmoryLibrary.Data.Type {

    public class TalentData {
        public TalentData(int treeOne, int treeTwo, int treeThree, string playerClass) { 
            this.talentTreeOne = treeOne;
            this.talentTreeTwo = treeTwo;
            this.talentTreeThree = treeThree;
            this.playerClass = playerClass;
        }

        private string playerClass;
        private int talentTreeOne;
        private int talentTreeTwo;
        private int talentTreeThree;

        public string Talents {
            get {
                return talentTreeOne + "/" +
                    talentTreeTwo + "/" +
                    talentTreeThree;
            }
        }

        public string TalentSpec {
            get {
                int totalTalents = talentTreeOne + talentTreeTwo + talentTreeThree;
                int pointsNeeded = (int)((totalTalents / 3) * 1.9);

                if (talentTreeOne < pointsNeeded &&
                    talentTreeTwo < pointsNeeded &&
                    talentTreeThree < pointsNeeded) {
                    return "Hybrid";
                } else {
                    if (talentTreeOne >= pointsNeeded) {
                        return getTalentTreeName(1);
                    } else if (talentTreeTwo >= pointsNeeded) {
                        return getTalentTreeName(2);
                    } else {
                        return getTalentTreeName(3);
                    }
                }
            }
        }

        private string getTalentTreeName(int tree) {
            int treeIndex = tree - 1;

            switch (playerClass) {
                case "Druid":
                    return TalentInformation.DruidTrees[treeIndex];
                case "Hunter":
                    return TalentInformation.HunterTrees[treeIndex];
                case "Mage":
                    return TalentInformation.MageTrees[treeIndex];
                case "Paladin":
                    return TalentInformation.PaladinTrees[treeIndex];
                case "Priest":
                    return TalentInformation.PriestTrees[treeIndex];
                case "Rogue":
                    return TalentInformation.RogueTrees[treeIndex];
                case "Shaman":
                    return TalentInformation.ShamanTrees[treeIndex];
                case "Warlock":
                    return TalentInformation.WarlockTrees[treeIndex];
                case "Warrior":
                    return TalentInformation.WarriorTrees[treeIndex];
                case "Death Knight":
                    return TalentInformation.DeathKnightTrees[treeIndex];
                default: return "Unknown";
            }
        }
    }
}