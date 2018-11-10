using UnityEngine;
using System.Collections;

public class RubikMap : MonoBehaviour {
	
	public Texture[] Textures;
	public int PositionX = 0;
	public int PositionY = 0;
	public int FaceWidth = 0;
	public int FaceHeight = 0;
	private Rect[] Coordinates;
	
	// Use this for initialization
	void Start()
	{
		StartCoordinates();
	}
	
	void OnGUI()
	{
		Render();
	}
	
	private void StartCoordinates()
	{
		Coordinates = new Rect[6];
		Coordinates[0] = new Rect(PositionX + FaceWidth, PositionY, FaceWidth, FaceHeight);
		Coordinates[1] = new Rect(PositionX + FaceWidth, PositionY - FaceHeight, FaceWidth, FaceHeight);
		Coordinates[2] = new Rect(PositionX + FaceWidth, PositionY - 2 * FaceHeight, FaceWidth, FaceHeight);
		Coordinates[3] = new Rect(PositionX + FaceWidth, PositionY + FaceHeight, FaceWidth, FaceHeight);
		Coordinates[4] = new Rect(PositionX, PositionY - FaceHeight, FaceWidth, FaceHeight);
		Coordinates[5] = new Rect(PositionX + 2 * FaceWidth, PositionY - FaceHeight, FaceWidth, FaceHeight);
	}
	
	private void Render()
	{
		for(int i = 0; i < Textures.Length; i++)
		{
			int angle = 0;
			float x = (Coordinates[i].xMax + Coordinates[i].x) / 2;
			float y = (Coordinates[i].yMax + Coordinates[i].y) / 2;

			switch(i)
			{
				case 0:
					angle = 0;
					break;
				case 1:
					angle = 0;
					break;
				case 2:
					angle = -180;
					break;
				case 3:
					angle = 0;
					break;
				case 4:
					angle = 90;
					break;
				case 5:
					angle = -90;
					break;
			}
			// Rotaciona a GUI ao redor de um Pivo
			GUIUtility.RotateAroundPivot(angle, new Vector2(x, y));
			// Renderiza o Render Texture na posicao atual da GUI
			GUI.DrawTexture(Coordinates[i], Textures[i]);
			// Reseta a matriz de rotaçao da GUI
			GUI.matrix = Matrix4x4.identity;
		}
	}
}
