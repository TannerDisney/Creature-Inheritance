using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritenceSample
{
    /// <summary>
    /// A base class to represent human and AI controlled characters
    /// </summary>
    class Creature
    {

        public Creature(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of a creature
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The health points of a creature
        /// </summary>
        public double Health { get; set; }

        /// <summary>
        /// The attack points of a creature
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// The defence points of a creature
        /// </summary>
        public int Defence { get; set; }

        /// <summary>
        /// The speed points of a creature
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// The creature's race -
        /// example: Human, Half-Orc, Demon
        /// </summary>
        public string Race { get; set; }

        public virtual string GetDisplayText(string sep)
        {
            return $"{Name}{sep}{Health}{sep}{Race}";
        }
    }

    /// <summary>
    /// A Human Class to repesent a Non-AI Controlled character
    /// </summary>
    class Player : Creature
    {
        public Player(string playerName) : base(playerName)
        {  }

        /// <summary>
        /// Stamina is used when running or performing physical action's
        /// </summary>
        public double Stamina { get; set; }
        /// <summary>
        /// These are magic points to be spent on casting spells
        /// </summary>
        public double Mana { get; set; }

        public override string GetDisplayText(string sep)
        {
            return "Player: " + base.GetDisplayText(sep) + sep + Stamina;
        }
    }

    /// <summary>
    /// An AI Class to represent an AI-Controlled character
    /// </summary>
    [DebuggerDisplay("EnemyId: {EnemyId}")]
    class Enemy : Creature
    {
        public Enemy(string enemyName) : base(enemyName)
        { }

        /// <summary>
        /// The Id of the enemy
        /// </summary>
        public int EnemyId { get; set; }

        /// <summary>
        /// How long the enemy takes to repsawn after they are defeated.
        /// If the enemy does not have a RespawnRate, once they are defeated they never respawn.
        /// </summary>
        public TimeSpan? RespawnRate { get; set; }

        /// <summary>
        /// The number of experience points a player
        /// gains on deafeating an enemy.
        /// </summary>
        public int ExperienceDropRate { get; set; }

        /// <summary>
        /// Items the enemy may be able to drop on being defeated
        /// </summary>
        public List<Item> ItemDrops { get; set; }
    }
}
