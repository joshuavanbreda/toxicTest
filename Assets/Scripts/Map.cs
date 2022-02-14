using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace MyRTS2018
{
	class Map
	{
		private const int MAX_RANDOM_UNITS = 50;
		private const string FIELD_SYMBOL = ".";
		private string[,] grid = new string[20, 20];
		private List<Unit> unitsOnMap = new List<Unit>();
		public int numberOfUnitsOnMap = 0;

		public string[,] Grid
		{
			get
			{
				return grid;
			}
		}

		public List<Unit> UnitsOnMap
		{
			get
			{
				return UnitsOnMap;
			}

		}

		public void populate()
		{
			Random rnd = new Random();
			int numberRandomUnits = rnd.Next(0, MAX_RANDOM_UNITS) + 1;
			int x, y, randomAttackRange;
			bool attackOption;
			string team;


			//clear
			for (int i = 0; i < 20; i++)
			{
				for(int j = 0; j < 20; j++)
				{
					grid[i, j] = FIELD_SYMBOL;
				}
			}

			for(int k = 0; k < numberRandomUnits; k++)
			{
				do
				{
					x = rnd.Next(0, 20);
					y = rnd.Next(0, 20);
				} while (grid[x, y] != FIELD_SYMBOL);

				if (rnd.Next(1, 3) == 1)
				{
					attackOption = rnd.Next(0, 2) == 1 ? true : false;
					team = rnd.Next(0, 2) == 1 ? "RED" : "GREEN";
					MeleeUnit m = new MeleeUnit(x, y, 100, -1, attackOption, 1, team, "M");
					unitsOnMap.Add(m);

					grid[x, y] = m.Symbol;
					numberOfUnitsOnMap++;
				}
				else
				{
					attackOption = rnd.Next(0, 2) == 1 ? true : false;
					randomAttackRange = rnd.Next(1, 20);
					team = rnd.Next(0, 2) == 1 ? "RED" : "GREEN";
					RangedUnit tmp = new RangedUnit(x, y, 100, -1, attackOption, randomAttackRange, team, "R");
					unitsOnMap.Add(tmp);

					grid[x, y] = unitsOnMap[numberOfUnitsOnMap].Symbol;


					numberOfUnitsOnMap++;
				}

			}
		}

		private void moveOnMap(Unit u, int newX, int newY)
		{
			grid[u.X, u.Y] = FIELD_SYMBOL;
			grid[newX, newY] = u.Symbol;
		}

		public void update(Unit u, int newX, int newY)
		{
			if ((newX >= 0 && newX < 20) && (newY >= 0 && newY < 20))
			{
				moveOnMap(u, newX, newY);
				u.move(newX, newY);
			}
		}

		/* public void checkHealth()
		{
			for (int i = 0; i < numberOfUnitsOnMap; i++)
			{
				if (!unitsOnMap[i].IsAlive())
				{
					grid[unitsOnMap[i].X, unitsOnMap[i].Y] = FIELD_SYMBOL;
					unitsOnMap.RemoveAt(i);
					numberOfUnitsOnMap--;
				}
			}
		} */

		/*public void save()
		{
			FileStream outFile = new FileStream(@"Files\Map.txt",
				FileMode.Append, FileAccess.Write);
			StreamWriter writer = new StreamWriter(outFile);

			writer.WriteLine(resType);
			writer.WriteLine(resPerGameTick);
			writer.WriteLine(resRemaining);
			writer.Close();
			outFile.Close();
		} */
	}
}
