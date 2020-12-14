using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public string glmPath;
    public List<Building> city;


    private void Awake()
    {
        if(glmPath != "")
        {
            city = ParserGML.GetBuildingsFromGML(glmPath);
        }
        else
        {
            Debug.Log("GlmPath Empty");
        }
    }
}
