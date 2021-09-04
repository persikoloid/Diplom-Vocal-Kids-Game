using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Maze {

	struct Node
	{
		public bool path, check;
	}

	public static int Round(int value) // если число четное, возвращаем нечетное
	{
		if(value % 2 == 0) return value + 1; else return value;
	}

	public static int[,] Generate(int width, int height)
	{
		if(width < 10 || height < 10) return null;

		width = Round(width);
		height = Round(height);

		int x, y;
		bool finish = false;

		List<string> dir = new List<string>();
		Node[,] field = new Node[width, height];

		int j = Round(Random.Range(0, height-1));

		field[1, j].path = true; // развилка
		field[1, j].check = true; // проходимое место

		while(true)
		{
			finish = true;

			for(y = 0; y < height; y++)
			{
				for(x = 0; x < width; x++)
				{
					if(field[x, y].path) // ищем флажок развилки
					{
						finish = false;

						if(x-2 >= 0)
						if(!field[x-2, y].check) dir.Add("Left"); // если путь свободен, добавляем направление

						if(y-2 >= 0)
						if(!field[x, y-2].check) dir.Add("Down");

						if(x+2 < width)
						if(!field[x+2, y].check) dir.Add("Right");

						if(y+2 < height)
						if(!field[x, y+2].check) dir.Add("Up");

						if(dir.Count > 0)
						{
							switch(dir[Random.Range(0, dir.Count)]) // выбираем случайное направление
							{
							case "Left":
								field[x-1, y].check = true;
								field[x-2, y].check = true;
								field[x-2, y].path = true;
								break;

							case "Down":
								field[x, y-1].check = true;
								field[x, y-2].check = true;
								field[x, y-2].path = true;
								break;

							case "Right":
								field[x+1, y].check = true;
								field[x+2, y].check = true;
								field[x+2, y].path = true;
								break;

							case "Up":
								field[x, y+1].check = true;
								field[x, y+2].check = true;
								field[x, y+2].path = true;
								break;
							}
						}
						else // если направление добавить невозможно, убираем флажок развилки
						{
							field[x, y].path = false;
						}

						dir.Clear(); // чистим массив
					}
				}
			}

			if(finish) break; // если не нашлось ни одного флажка развилки, выходим
		}

		int[,] result = new int[width, height];

		// создаем новый массив, где 1 проходимое место, а -1 стена
		for(y = 0; y < height; y++)
		{
			for(x = 0; x < width; x++)
			{
				if(field[x, y].check)
				{
					result[x, y] = 1;
				}
				else
				{
					result[x, y] = -1;
				}
			}
		}

		return result;
	}
}
