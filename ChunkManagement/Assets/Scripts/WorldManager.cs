using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<CreateCity>().BuildCity();
    }
}
