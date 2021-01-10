using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Grid grid;
    public PlayerController player;

    private Chunk currentChunk;

    private void Awake()
    {
        grid = new Grid();
        CreateCity city = GetComponent<CreateCity>();
        city.BuildCity();
    }

    private void Update()
    {
        Chunk chunk = grid.GetChunkByPos(player.transform.position);
        chunk.ToggleChunk(false);
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            List<Chunk> chunks = Enumerable.ToList(grid.chunks.Values);
            chunks[0].ToggleChunk();
        }
    }

}
