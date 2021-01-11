using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRenderer : MonoBehaviour
{
    Renderer[] renderers;
    public GameObject lod0;
    public GameObject lod1;


    // Use this for initialization
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckVisibility())
        {
            lod0.SetActive(true);
            lod1.SetActive(false);
            lod0.GetComponentsInChildren<Renderer>()[0].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            lod1.GetComponentsInChildren<Renderer>()[0].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        else
        {
            lod0.SetActive(false);
            lod1.SetActive(true);
            lod0.GetComponentsInChildren<Renderer>()[0].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            lod1.GetComponentsInChildren<Renderer>()[0].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }

    private bool CheckVisibility()
    {
        foreach (Renderer renderer in renderers)
        {
            if (renderer.isVisible)
                return true;
        }
        return false;
    }
}
