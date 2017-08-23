using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject tile;

    public Vector2 size;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        CreateTerrain();
	}

    private void CreateTerrain()
    {
        float length = size.x;
        float width = size.y; 
        for (int currLen = 0; currLen < length; currLen++)
        {
            GameObject.Instantiate(tile, )
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
