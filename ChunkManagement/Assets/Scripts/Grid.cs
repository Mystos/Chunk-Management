using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Grid
{
    [SerializeField]
    public float chunkSize = 500;

    public Dictionary<Vector2Int, Chunk> chunks;

    public Grid()
    {
        chunks = new Dictionary<Vector2Int, Chunk>();
    }

    public void AddBuildingToGrid(HouseConstructor building)
    {
        Chunk chunk = GetChunkByPos(building.building.BuildingCenter);
        chunk.buildings.Add(building);
    }

    public Chunk GetChunkByPos(Vector3 pos)
    {
        int xChunk = Mathf.FloorToInt(pos.x / chunkSize);
        int yChunk = Mathf.FloorToInt(pos.z / chunkSize);
        Vector2Int chunkPos = new Vector2Int(xChunk, yChunk);
        if (!chunks.TryGetValue(chunkPos, out Chunk chunk))
        {
            chunk = new Chunk();
            chunks.Add(chunkPos, chunk);
        }
        return chunk;
    }

}

public class Chunk
{
    //public Vector2Int chunkPos;
    public List<HouseConstructor> buildings;

    public bool Active { get; private set; }

    public Chunk()
    {
        Active = true;
        buildings = new List<HouseConstructor>();
    }

    public void ToggleChunk()
    {
        foreach (HouseConstructor item in buildings)
        {
            item.gameObject.SetActive(!item.gameObject.activeSelf);
        }
        Active = !Active;
    }

    public void ToggleChunk(bool activate)
    {
        if (Active == activate) return;

        foreach (HouseConstructor item in buildings)
        {
            item.gameObject.SetActive(activate);
        }
        Active = activate;
    }
}
