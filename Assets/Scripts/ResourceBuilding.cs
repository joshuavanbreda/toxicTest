using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace MyRTS2018
{
	class ResourceBuilding : Building
	{

		protected string resourceType;
		protected int resourcesPerTick;
		protected int resourcesRemaining;

		// Constructor
		public ResourceBuilding(int x, int y, int health, string team, string symbol, string resourceType, int resourcesPerTick, int resourcesRemaining)
			: base(x, y, health, team, symbol)
		{
			this.x = x;
			this.y = y;
			this.health = health;
			this.team = team;
			this.symbol = symbol;
		}

		/*public override bool isAlive()
		{
			if (this.health <= 0) 
			{
				return false;

			}
			else
			{
				return true;

			}

		} */
		public override string toString()
		{
			string output = "X : " + x + Environment.NewLine
			                + "Y : " + y + Environment.NewLine
			                + "Health: " + health + Environment.NewLine
			                + "Team: " + team + Environment.NewLine
			                + "Symbol: " + symbol + Environment.NewLine;
			return output;
		}

		public override void save()
		{
			FileStream outFile = null;
			StreamWriter writer = null;

			try
			{
				outFile = new FileStream(@"Files\ResourceBuilding.txt", FileMode.Append, FileAccess.Write);
				writer = new StreamWriter(outFile);

				writer.WriteLine(x);
				writer.WriteLine(y);
				writer.WriteLine(health);
				writer.WriteLine(team);
				writer.WriteLine(symbol);

				writer.Close();
				outFile.Close();
			}
			catch (IOException fe)
			{
				Console.WriteLine(fe.Message);
			}
			finally
			{
				if (writer != null)
					writer.Close();
				if (outFile != null)
					outFile.Close();
			}
		}
	}
}


