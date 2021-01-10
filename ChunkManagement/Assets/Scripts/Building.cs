using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Building
{
    public List<Vector3> points;

    public Vector3 BuildingCenter
    {
        get
        {
            Vector3 center = Vector3.zero;
            int count = 0;
            foreach (Vector3 point in points)
            {
                center += point;
                count++;
            }
            center /= count;
            return center;
        }
    }

    public Building(List<Vector3> pts)
    {
        points = new List<Vector3>(pts);
    }
}
