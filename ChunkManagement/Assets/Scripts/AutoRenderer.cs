using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRenderer : MonoBehaviour
{
    Renderer renderer;
    public GameObject lod0;
    public GameObject lod1;


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
            lod0.SetActive(true);
            lod1.SetActive(false);
        }
        else
        {
            lod0.SetActive(false);
            lod1.SetActive(true);
        }
    }
}
