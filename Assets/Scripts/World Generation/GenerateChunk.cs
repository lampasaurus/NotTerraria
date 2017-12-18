using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour {
    public GameObject[] blocks;
    public int width;
    public int height;
    public int renderDistance;

    [HideInInspector]
    public float seed;

    public void CheckIfEnabled()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        Vector3 position = transform.position;
        foreach(GameObject p in player)
        {
            Vector3 diff = p.transform.position - position;
            float distance = diff.sqrMagnitude;
            Debug.Log(distance);
            if(distance > renderDistance)
            {
                gameObject.SetActive(false);
                foreach(Transform child in this.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
    public void GenerateSurface(float heightMultiplier, float smoothness)
    {
        for(int x = 0; x < width; x++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (x + transform.position.x) / smoothness) * heightMultiplier) + height; //Height at given x position
            
            for (int y = 0;y<h; y++)
            {
                GameObject currentBlock;

                if (y == h-1) currentBlock = blocks[1];    //If top block, grass
                else currentBlock = blocks[0];              //Default to dirt

                GameObject newBlock = Instantiate(currentBlock, Vector3.zero, Quaternion.identity) as GameObject;
                newBlock.transform.parent = this.gameObject.transform;
                newBlock.transform.localPosition = new Vector3(x, y);

            }
        }
        CheckIfEnabled();
    }
    public void GenerateUnderground()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject currentBlock;

                currentBlock = blocks[0];           //Default to dirt

                GameObject newBlock = Instantiate(currentBlock, Vector3.zero, Quaternion.identity) as GameObject;
                newBlock.transform.parent = this.gameObject.transform;
                newBlock.transform.localPosition = new Vector3(x, y);
            }
        }
        CheckIfEnabled();
    }


    
}
