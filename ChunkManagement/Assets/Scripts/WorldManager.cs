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
        displayedChunks = new Chunk[9];
        grid = new Grid();
        CreateCity city = GetComponent<CreateCity>();
        city.BuildCity();
    }

    private void Update()
    {
        if (player)
        {
            Chunk chunk = grid.GetChunkByPos(player.transform.position);
            Vector2Int chunkXY = grid.GetCellPosition(player.transform.position);

            //Add center chunk to display array
            displayedChunks[0] = chunk;

            //Add closest chunks to display array
            grid.chunks.TryGetValue(chunkXY + new Vector2Int(-1, 0), out Chunk leftChunk);
            displayedChunks[1] = leftChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(1, 0), out Chunk rightChunk);
            displayedChunks[2] = rightChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(0, 1), out Chunk topChunk);
            displayedChunks[3] = topChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(0, -1), out Chunk downChunk);
            displayedChunks[4] = downChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(-1, 1), out Chunk topleftChunk);
            displayedChunks[5] = topleftChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(1, 1), out Chunk toprightChunk);
            displayedChunks[6] = toprightChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(-1, -1), out Chunk downleftChunk);
            displayedChunks[7] = downleftChunk;

            grid.chunks.TryGetValue(chunkXY + new Vector2Int(1, -1), out Chunk downrightChunk);
            displayedChunks[8] = downrightChunk;

            //Enable proximity chunks
            for (int i = 0; i < displayedChunks.Length; i++)
            {
                if (displayedChunks[i] != null)
                    displayedChunks[i].ToggleChunk(true);
            }

            //Disable all other chunks
            foreach (Chunk c in grid.chunks.Values)
            {
                if (!displayedChunks.Contains(c))
                    c.ToggleChunk(false);
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
