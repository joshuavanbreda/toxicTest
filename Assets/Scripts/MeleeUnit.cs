using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Diagnostics;
using System.IO;

namespace MyRTS2018
{
	abstract class MeleeUnit : Unit
	{
		public MeleeUnit(int x, int y, int health, int speed, bool attack, int attackRange, string team, string symbol, string name)
			: base(x, y, health, speed, attack, attackRange, team, symbol, name)
		{

		}


		public override void move(int x, int y)
		{
			if (x >= 0 && x < 20)
				X = x;
			if (y >= 0 && y < 20)
				Y = y;
		}

		public override void combat(Unit enemy)
		{
			if (this.isWithinAttackRange(enemy))
			{
				enemy.Health -= DAMAGE;
			}
		}

		public override bool isWithinAttackRange(Unit enemy)
		{
			if (!this.Team.Equals(enemy.Team))
			{
				if ((Math.Abs(this.X - enemy.X) <= this.AttackRange) ||
					(Math.Abs(this.Y - enemy.Y) <= this.AttackRange))
					return true;

			}
			return false;
		}
		public override Unit nearestUnit(List<Unit> List)
		{

			Unit closest = null;
			int attackRangeX, attackRangeY;
			int shortestRange = 1000;
			double range;

			foreach (Unit u in List)
			{
				attackRangeX = Math.Abs(this.x - u.X);
				attackRangeY = Math.Abs(this.Y - u.Y);

				range = Math.Sqrt(Math.Pow(attackRangeX, 2) + Math.Pow(attackRangeY, 2));

				if (attackRangeX < shortestRange)
				{
					shortestRange = attackRange;
					closest = u;
				}

				if (attackRangeY < shortestRange)
				{
					shortestRange = attackRange;
					closest = u;
				}
			}
			return closest;

		}

		/*public bool IsAlive()
		{
			if (Health <= 0)
				return false;
			else
				return true;
		} */

		public override string ToString()
		{
			string output;

			output = "X position: " + x + Environment.NewLine;
			output += "Y position: " + y + Environment.NewLine;
			output += "Health: " + health + Environment.NewLine;
			output += "Speed: " + speed + Environment.NewLine;
			output += "Attack: " + attack + Environment.NewLine;
			output += "Attack Range" + attackRange + Environment.NewLine;
			output += "Team: " + team + Environment.NewLine;
			output += "Name: " + name + Environment.NewLine;

			return output;
		}

		public override void save()
		{
			FileStream outFile = new FileStream(@"Files\MeleeUnit.txt",
				FileMode.Append, FileAccess.Write);
			StreamWriter writer = new StreamWriter(outFile);

			writer.WriteLine(x);
			writer.WriteLine(y);
			writer.WriteLine(health);
			writer.WriteLine(speed);
			writer.WriteLine(attack);
			writer.WriteLine(attackRange);
			writer.WriteLine(team);
			writer.WriteLine(symbol);
			writer.WriteLine(DAMAGE);
			writer.WriteLine(name);
		}


	}
}
