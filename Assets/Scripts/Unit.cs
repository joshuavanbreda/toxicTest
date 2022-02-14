using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace MyRTS2018
{
	abstract class Unit
	{
		protected int x;
		protected int y;
		protected int health = 10;
		protected int speed;
		protected bool attack;
		protected int attackRange;
		protected string team;
		protected string symbol;
		protected const int DAMAGE = 2;
		protected string name;

		public Unit(int x, int y, int health, int speed, bool attack, int attackRange, string team, string symbol, string name)
		{
			this.x = x;
			this.y = y;
			this.health = health;
			this.speed = speed;
			this.attack = attack;
			this.attackRange = attackRange;
			this.team = team;
			this.symbol = symbol;
			this.name = name;
		}

		public Unit()
		{

		}

		#region Accessors

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

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		#endregion

		public abstract void move(int x, int y);

		public abstract void save();

		public abstract void combat(Unit enemy);

		public abstract bool isWithinAttackRange(Unit enemy);

		public abstract Unit nearestUnit(List<Unit> u);

		//public abstract bool isAlive();

		public abstract string toString();


	}
}
