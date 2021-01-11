using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Grid
{
    [SerializeField]
    public float chunkSize = 100;

    public Dictionary<Vector2Int, Chunk> chunks;

    public Grid()
    {
        chunks = new Dictionary<Vector2Int, Chunk>();
    }

    public void AddBuildingToGrid(HouseConstructor building)
    {
        Chunk chunk = GetChunkByPos(building.building.BuildingCenter);
        chunk.buildings.Add(building);
        building.gameObject.SetActive(false);
    }

    public Chunk GetChunkByPos(Vector3 pos)
    {
        Vector2Int chunkPos = GetCellPosition(pos);
        if (!chunks.TryGetValue(chunkPos, out Chunk chunk))
        {
            chunk = new Chunk();
            chunks.Add(chunkPos, chunk);
        }
        return chunk;
    }

    public Vector2Int GetCellPosition(Vector3 position)
    {
        int xChunk = Mathf.FloorToInt(position.x / chunkSize);
        int yChunk = Mathf.FloorToInt(position.z / chunkSize);
        return new Vector2Int(xChunk, yChunk);
    }

}

public class Chunk
{
    //public Vector2Int chunkPos;
    public List<HouseConstructor> buildings;

    public bool Active { get; private set; }

    public Chunk()
    {
        Active = false;
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
