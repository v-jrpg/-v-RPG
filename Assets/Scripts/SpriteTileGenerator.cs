using UnityEngine;
using System.Collections;

public class SpriteTileItem<T> : TileItem<SpriteTileConfig>
{

}

public class SpriteTileConfig : TileConfig
{
	public Texture2D texture;
}

public class SpriteTileGenerator<T,U> : TileGenerator<SpriteTileItem<SpriteTileConfig>,SpriteTileConfig>
{
	// Use this for initialization
	void Start ()
	{
		//TODO: set goddamn textures now!
		Debug.Log ("SpriteTileGenerator :: Start");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

