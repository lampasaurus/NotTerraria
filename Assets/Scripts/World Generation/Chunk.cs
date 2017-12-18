using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
    int chunkSize;
    GameObject[,] blocks;


    public Chunk(int size, int xpos, int ypos)
    {
        transform.SetPositionAndRotation(new Vector3(xpos, ypos), Quaternion.identity);
        chunkSize = size;
        blocks = new GameObject[size,size];
    }
    void addBlock(GameObject block, int x, int y)
    {
        blocks[x, y] = block;
    }
}
