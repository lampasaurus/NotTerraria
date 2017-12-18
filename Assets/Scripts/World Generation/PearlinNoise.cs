using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlinNoise{
    long seed;
    
    public PearlinNoise(long seed)
    {
        this.seed = seed;
    }

    public int getNoise(int x, int range, int chunkSize)
    {
        float noise = 0;
        range /= 2;

        while (chunkSize > 0)
        {
            int chunkIndex = x / chunkSize;

            float prog = (x % chunkSize) / (chunkSize * 1f);

            float left_random = random(chunkIndex, range);
            float right_random = random(chunkIndex + 1, range);


            noise += (1 - prog) * left_random + prog * right_random;

            chunkSize /= 2;
            range /= 2;

            range = Mathf.Max(1, range);
        }

        return (int)Mathf.Round(noise);
    }



    private int random(int x, int range)
    {
        if (range <= 1) range = 2;
        return (int)((x+seed)^5) % range;
    }
}
