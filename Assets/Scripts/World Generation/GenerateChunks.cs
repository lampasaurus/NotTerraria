using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour {
    public GameObject chunk;
    int chunkWidth;
    int chunkHeight;

    public int surfaceHeight;
    public int surfaceSmoothness;

    public int numChunksX;
    public int numChunksY;

    GameObject world;
    float seed;
	// Use this for initialization
	void Start () {
        chunkWidth = chunk.GetComponent<GenerateChunk>().width;
        chunkHeight = chunk.GetComponent<GenerateChunk>().height;
        seed = Random.Range(-1000000f, 1000000f);
        world = new GameObject();
        Instantiate(world, Vector3.zero, Quaternion.identity);
        Generate();
	}
	public void Generate()
    {
        int lastX = -chunkWidth;
        for (int y = 0; y < numChunksY; y++)
        {
            //If it's the surface, use perlin noise to generate surface layer
            if (y == 0) { 
                for (int i = 0; i < numChunksX; i++)
                {
                    GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity) as GameObject;
                    newChunk.transform.parent = world.transform;
                    newChunk.GetComponent<GenerateChunk>().seed = seed;
                    newChunk.GetComponent<GenerateChunk>().GenerateSurface(surfaceHeight, surfaceSmoothness);
                    lastX += chunkWidth;
                }
            }
            //Underground generation
            else
            {
                lastX = -chunkWidth;
                int posY = (-y) * chunkHeight;
                for (int i = 0; i < numChunksX; i++)
                {
                    GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, posY), Quaternion.identity) as GameObject;
                    newChunk.transform.parent = world.transform;
                    newChunk.GetComponent<GenerateChunk>().seed = seed;
                    newChunk.GetComponent<GenerateChunk>().GenerateUnderground();
                    lastX += chunkWidth;
                }
            }
        }

    }
}
