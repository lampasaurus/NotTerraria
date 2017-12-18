using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour {

    private void Start()
    {
        Vector3 scale = new Vector3(1, 1, 1f);
        transform.localScale = scale;
    }
    private void Awake()
    {
        Vector3 scale = new Vector3(1, 1, 1f);
        transform.localScale = scale;
    }
}
