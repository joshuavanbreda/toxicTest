using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyRTS2018
{
	public class GameEngine : MonoBehaviour
	{
		public int height;
		public int width;
		private Map map = new Map();

			//map.populate();
		void start()
		{
			// draw
			int xStart = 48;
			int yStart = 24;
			var tileSize = new Vector2 (2, 2);

			//Grass Tiles
			for (int k = 0; k < height; k++)
			{
				var yPos = -k * tileSize.y + yStart;
				for (int i = 0; i < width; i++)
				{
					var xPos = i * tileSize.x - xStart;
					Instantiate(Resources.Load("grass"), new Vector3(xPos, yPos, 0), Quaternion.identity);
				}
			}

			// Create a new game
			//map.populate();
			Debug.Log ("Number of units: " + map.numberOfUnitsOnMap.ToString ());
			foreach (Unit temp in map.UnitsOnMap)
			{
				if (temp != null)
				{
					var unitType = temp.GetType ().ToString ();
					var xPos = temp.X * tilesize.x - xStart;
					var yPos = temp.Y * tilesize.y + yStart;
					if (unitType.Contains ("MeleeUnit"))
					{
						if (temp.Team.Equals ("RED"))
							Instantiate (Resources.Load ("MeleeUnit"), new Vector3 (xPos, yPos, -2), Quaternion.identity);
						else
							Instantiate (Resources.Load ("MeleeUnit2"), new Vector3 (xPos, yPos, -2), Quaternion.identity);
					}
					else
					{
						if (temp.Team.Equals ("RED"))
							Instantiate (Resources.Load ("RangedUnit"), new Vector3 (xPos, yPos, -2), Quaternion.identity);
						else
							Instantiate (Resources.Load ("RangedUnit2"), new Vector3 (xPos, yPos, -2), Quaternion.identity);
					}
				}
			}
				
			int newX, newY;
			Unit closest;

			// update units on map
			//map.checkHealth();

			// combat

			for (int j = 0; j < map.UnitsOnMap.Count; j++)
			{
				// Rules
				if (!map.UnitsOnMap[j].Attack)
				{
					closest = map.UnitsOnMap[j].nearestUnit(map.UnitsOnMap);
					if (map.UnitsOnMap[j].X < closest.Y)
						newX = map.UnitsOnMap[j].X + 1;
					else if (map.UnitsOnMap[j].X > closest.X)
						newX = map.UnitsOnMap[j].X - 1;
					else
						newX = map.UnitsOnMap[j].X;

					if (map.UnitsOnMap[j].Y < closest.Y)
						newY = map.UnitsOnMap[j].Y + 1;
					else if (map.UnitsOnMap[j].Y > closest.Y)
						newY = map.UnitsOnMap[j].Y - 1;
					else
						newY = map.UnitsOnMap[j].Y;
					map.update(map.UnitsOnMap[j], newX, newY);
				}


				if (map.UnitsOnMap[j].Attack)
				{
					for (int i = 0; i < map.UnitsOnMap.Count; i++)
					{
						if (map.UnitsOnMap[j].Team != map.UnitsOnMap[i].Team)
							map.UnitsOnMap[j].combat(map.UnitsOnMap[i]);
					}
				}
				if (!map.UnitsOnMap[j].Attack)
				{
					for (int i = 0; i < map.UnitsOnMap.Count; i++)
					{
						if ((map.UnitsOnMap[j].Team != map.UnitsOnMap[i].Team) && (map.UnitsOnMap[j].Team != map.UnitsOnMap[i].Team))
							map.UnitsOnMap[j].Attack = true;
					}

					if (map.UnitsOnMap[j].Health < 25)
					{
						newX = map.UnitsOnMap[j].X + 1;
						newY = map.UnitsOnMap[j].Y - 1;
						map.update(map.UnitsOnMap[j], newX, newY);
					}
				}
			}
		}

		void Update()
		{
		}
	}	
}
