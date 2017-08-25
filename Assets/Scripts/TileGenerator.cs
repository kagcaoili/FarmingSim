using UnityEngine;

// Summary: Creates a length X and width Y terrain by instantiating a given prefab tile. Terrain is centered at (0,0,0).
// Author: Kristin Agcaoili
// Date: 08/24/2017
public class TileGenerator : MonoBehaviour {

    [SerializeField]
    private Tile tile; // Holds the prefab tile

    public Vector2 size; // The size X and Y width and length of the terrain to create

    private Vector3 startPosition; // The starting position dependent on the size of the terrain
    private float tileRadius; // Radius of the tile. If default 1.0f, then the radius is 0.5f to offset correctly

    // Summary: Initializes starting position and the tile radius. Calls CreateTerrain.
    //          Starting position is NOT 0,0,0. The starting position is the Vector3 in which the center of the terrain (middle tile) is at 0,0,0.
	void Start ()
    {
        startPosition = new Vector3(-(size.x / 2.0f), 0.0f, -(size.y / 2.0f)); // Shifts the starting position to the negative area by half the size of the terrain
        if (tile)
        {
            tileRadius = tile.gameObject.transform.localScale.x / 2.0f;
            CreateTerrain();
        } else
        {
            Debug.LogWarning("TileGenerator: Tile not found.");
        }
	}

    // Summary: Iterates through the given length and width and instantiates the tile by offsetting with the radius of the tile and the # tile being created.
    private void CreateTerrain()
    {
        float length = size.x;
        float width = size.y;

        if (length == 0.0f && width == 0.0f)
        {
            Debug.LogWarning("TileGenerator: Length and Width are zero. No terrain is created.");
        }

        Vector3 currPosition;
        for (int currLenTile = 0; currLenTile < length; currLenTile++)
        {
            for (int currWidTile = 0; currWidTile < width; currWidTile++)
            {
                currPosition = new Vector3(startPosition.x + currLenTile + tileRadius, startPosition.y, startPosition.z + currWidTile + tileRadius);
                GameObject newTile = GameObject.Instantiate(tile.gameObject, currPosition, Quaternion.identity);
                newTile.transform.parent = gameObject.transform;
            }
        }
    }
}
