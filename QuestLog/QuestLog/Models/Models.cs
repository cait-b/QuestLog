using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuestLog.Models
{
    public class Quest
    {
        public enum AlignmentSide
        {
            Good,
            Neutral,
            Evil
        }
        public enum RewardType
        {
            Gold,
            Armor,
            Fame,
            Food,
            Supplies,
            Other
        }

        public int QuestID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public AlignmentSide Alignment { get; set; }
        public RewardType Reward { get; set; }
        [Display(Name = "Experience Points")]
        public int ExperiencePoints { get; set; }
    }

    public class QuestContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
    }
}