using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace MyRTS2018
{
    abstract class Building
    {
        protected int x;
        protected int y;
        protected int health;
        protected int speed;
        protected bool attack;
        protected int attackRange;
        protected string team;
        protected string symbol;


        //public abstract int isAlive();
        public abstract string toString();
        public abstract void save();
        public abstract void read();

        public Building(int x, int y, int health, int speed, bool attack, int attackRange, string team, string symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            this.attack = attack;
            this.attackRange = attackRange;
            this.speed = speed;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public bool Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
    }
}
