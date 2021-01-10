using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Grid grid;
    public PlayerController player;

    private Chunk[] displayedChunks;

    private void Awake()
    {
        displayedChunks = new Chunk[5];
        grid = new Grid();
        CreateCity city = GetComponent<CreateCity>();
        city.BuildCity();
    }

    private void Update()
    {
        if (player)
        {
            foreach (Chunk c in grid.chunks.Values)
            {
                if (!displayedChunks.Contains(c))
                    c.ToggleChunk(false);
            }

            Chunk chunk = grid.GetChunkByPos(player.transform.position);
            Vector2Int chunkXY = grid.GetCellPosition(player.transform.position);

            displayedChunks[0] = chunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(-1, 0), out Chunk leftChunk);
            displayedChunks[1] = leftChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(1, 0), out Chunk rightChunk);
            displayedChunks[2] = rightChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(0, 1), out Chunk topChunk);
            displayedChunks[3] = topChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(0, -1), out Chunk downChunk);
            displayedChunks[4] = downChunk;

            for (int i = 0; i < displayedChunks.Length; i++)
            {
                if (displayedChunks[i] != null)
                    displayedChunks[i].ToggleChunk(true);
            }
        }
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
