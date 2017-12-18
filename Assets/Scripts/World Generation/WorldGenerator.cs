using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
    public GameObject[] blocks; //A list of all blocks generated with the world
    
    public int worldSizeX;
    public int worldSizeY;

    public int pearlAmp;        //The potential height of bumps in the surface generation
    public int pearlFreq;       //The frequency of bumps in the surface generation

    public int chunkSize;       

    Chunk[,] chunks;
    PearlinNoise noise;


    /*
     * Generates a new world
     */
    void Start () {
        noise = new PearlinNoise(Random.Range(1000000, 10000000));
        chunks = new Chunk[worldSizeX/chunkSize+1, worldSizeY/chunkSize +1];
        Regenerate();
        int[,] world = new int[worldSizeX, worldSizeY];
	}
	

    /*
     * Generates chunks, fills chunks with blocks
     */
    void Regenerate()
    {
        Vector2 chunkPos = new Vector2(0,0);
        float tileWidth = blocks[0].GetComponent<SpriteRenderer>().bounds.size.x;

        for (int x = -worldSizeX; x<worldSizeX; x++)
        {
            int columnHeight = worldSizeY + noise.getNoise(x, pearlAmp, pearlFreq);


            for (int y = -worldSizeY; y < columnHeight; y++)
            {
                GameObject newBlock = (y == columnHeight - 1) ? blocks[1] : blocks[0];
                GameObject newBlockObject = Instantiate(newBlock, new Vector2(x*tileWidth, y*tileWidth), Quaternion.identity);
                
            }
        }
    }
}
