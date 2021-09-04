using System.Collections;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

	[SerializeField] private int width;
	[SerializeField] private int height;
	[SerializeField] private SpriteRenderer sample;
	[SerializeField] private float sampleSize = 1;
	private int[,] map;

	void Start()
	{
		CreateMap();
	}

	public void Clear()
	{
		SpriteRenderer[] ren = GetComponentsInChildren<SpriteRenderer>();
		for(int i = 0; i < ren.Length; i++)
		{
			DestroyImmediate(ren[i].gameObject);
		}
	}
	
	public void CreateMap()
	{
		Clear();

		map = Maze.Generate(width, height); // генерируем лабиринт

		if(map == null) return;

		width = Maze.Round(width); // проверка на четные/нечетные
		height = Maze.Round(height);

		float posX = -sampleSize * width / 2f - sampleSize / 2f;
		float posY = sampleSize * height / 2f - sampleSize / 2f;
		float Xreset = posX;
		int z = 0;
		for(int y = 0; y < height; y++)
		{
			for(int x = 0; x < width; x++)
			{
				posX += sampleSize;
				SpriteRenderer clone = Instantiate(sample, new Vector3(posX, posY, 0), Quaternion.identity, transform) as SpriteRenderer;
				clone.transform.name = "Block-" + z;
				clone.color = (map[x, y] == 1) ? Color.white : Color.cyan; // красим проходимые клетки в белый, а стены в серый цвет
				if (map[x,y] != 1) {
					clone.gameObject.AddComponent<BoxCollider2D>();
					clone.gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				}
				z++;
			}
			posY -= sampleSize;
			posX = Xreset;
		}
	}
}
