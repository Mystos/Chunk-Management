using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Grid grid;
    
    private void Awake()
    {
        grid = new Grid();
        CreateCity city = GetComponent<CreateCity>();
        city.BuildCity();
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            List<Chunk> values = Enumerable.ToList(grid.chunks.Values);
            grid.ToggleChunk(values[0]);
        }
    }

}
