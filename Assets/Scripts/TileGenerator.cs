using UnityEngine;
using System.Collections;

public class TileItem<T> : MonoBehaviour
	where T : TileConfig
{
	protected static string keytag = "TileItem";
	private static string delimiter = "~";

	[System.NonSerialized]
	public int row;
	[System.NonSerialized]
	public int column;

	public string getID()
	{			
		return TileItem<T>.generateID(
			row,
			column
		);
	}
	
	public static string generateID(int row, int column)
	{
		string [] keys = {
			keytag,
			row.ToString(),
			column.ToString()
		};

		return string.Join (
			delimiter,
			keys
		);
	}

	/**
	 * Uses the TileConfig to initialize this TileItem. 
	 */
	public void setConfig(T config)
	{
		transform.position = config.getOffset (
			row,
			column
			);
	}
}

/**
 * Configuration object to pass into a TileGenerator. 
 */
public class TileConfig
{
	/**
	 * Number of rows in this tiling.
	 */
	public int rows = 3;

	/**
	 * Number of columns in this tiling.
	 */
	public int columns = 3;

	/**
	 * Where is the next item in a row located relative to this one?
	 */
	public Vector3 rowOffset = new Vector3 (
		0,
		32,
		0
		);

	/**
	 * Where is the next item in a column located relative to this one? 
	 */
	public Vector3 columnOffset = new Vector3 (
		16,
		32,
		0
		);

	public Vector3 getOffset(int row, int column)
	{
		return rowOffset * row 
			+ columnOffset * column;
	}
}

/**
 * Reads a TileConfig and creates a 2D array of TileItems based off it.
 */
public class TileGenerator<T, U> : MonoBehaviour
	where T : TileItem<U>, new()
	where U : TileConfig, new()
{
	[System.NonSerialized]	
	public Hashtable tiles;

	// Use this for initialization
	void Start ()
	{
		tiles = new Hashtable();
		U config = new U ();  

		//Can't use Enumerable.Range(0, rows).Select because not real C#. :C
		for(int x = 0; x < config.rows; x++)
		{
			for(int y = 0; y < config.columns; y++)
			{
				T newTileItem = new T();
				newTileItem.setConfig(config);
				tiles.Add(newTileItem.getID(), newTileItem);
			}
		}
	}

	public T getTile(int x, int y)
	{
		return (T)tiles[TileItem<U>.generateID(x, y)];
	}
}

