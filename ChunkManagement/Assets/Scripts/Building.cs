using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Building
{
    public List<Vector3> points;

    public Building(List<Vector3> pts)
    {
        points = new List<Vector3>(pts);
    }
}
