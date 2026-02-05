using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tutorial.Linq
{
    public class LinqWhere : MonoBehaviour
    {
        private void Awake()
        {
            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Enemy("Goblin", 30));
            enemies.Add(new Enemy("Orc", 80));
            enemies.Add(new Enemy("Troll", 100));

            List<Enemy> filteredEnemies = enemies.Where(enemy => enemy.Health < 90).ToList();
        }
    }

    public class Enemy
    {
        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public string Name { get; }
        public int Health { get; }
    }
}

