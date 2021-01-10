using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRenderer : MonoBehaviour
{
    Renderer renderer;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
        {
            renderer.enabled = true;
        }
        else
            renderer.enabled = false;

    }
}
