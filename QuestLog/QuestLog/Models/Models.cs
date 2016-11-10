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

        public QuestContext()
        {
            Database.SetInitializer<QuestContext>(new MyInitializer());
        }

        public class MyInitializer : DropCreateDatabaseIfModelChanges<QuestContext>
        {
            public override void InitializeDatabase(QuestContext context)
            {
                base.InitializeDatabase(context);
                if (!context.Quests.Any(x => x.Name == "Your First Quests!"))
                {
                    context.Quests.Add(new Models.Quest()
                    {
                        Name = "Your First Quests!",
                        Level = 1,
                        Alignment = Quest.AlignmentSide.Neutral,
                        Reward = Quest.RewardType.Supplies,
                        ExperiencePoints = 10
                    });
                    context.Quests.Add(new Models.Quest()
                    {
                        Name = "Kill Kobolds",
                        Level = 3,
                        Alignment = Quest.AlignmentSide.Good,
                        Reward = Quest.RewardType.Gold,
                        ExperiencePoints = 30
                    });
                    context.Quests.Add(new Models.Quest()
                    {
                        Name = "Kick NPC",
                        Level = 2,
                        Alignment = Quest.AlignmentSide.Evil,
                        Reward = Quest.RewardType.Fame,
                        ExperiencePoints = 20
                    });
                    context.SaveChanges();
                }
            }
        }
    }


}