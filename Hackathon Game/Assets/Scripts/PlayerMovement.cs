using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tile sandCross;
    public Tile sandTrack;
    public Tile sandSide;
    public Tilemap Tilemap;
    public Vector3Int currentCell;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 CurrentPos = this.transform.position;
        Vector3Int cell = Tilemap.WorldToCell(transform.position);
        if (Input.GetKey("a")&& CurrentPos.x > -12.5)
        {
            this.transform.position = new Vector2(CurrentPos.x - moveSpeed * Time.deltaTime, CurrentPos.y);

            if (currentCell != cell)
            {
                if (Tilemap.GetTile(cell) == sandTrack)
                {
                    Tilemap.SetTile(cell, sandCross);
                    Vector3Int cameFrom = new Vector3Int(cell.x + 1, cell.y, cell.z);
                    Tilemap.SetTile(cameFrom, sandCross);
                }
                else if (Tilemap.GetTile(cell) != sandCross)
                {
                    Tilemap.SetTile(cell, sandSide);
                }
            }
            
        }

        if (Input.GetKey("d") && CurrentPos.x < 12.3)
        {
            this.transform.position = new Vector2(CurrentPos.x + moveSpeed * Time.deltaTime, CurrentPos.y);
            if (currentCell != cell)
            {
                if (Tilemap.GetTile(cell) == sandTrack)
                {
                    Tilemap.SetTile(cell, sandCross);
                    Vector3Int cameFrom = new Vector3Int(cell.x - 1, cell.y, cell.z);
                    Tilemap.SetTile(cameFrom, sandCross);
                }
                else if (Tilemap.GetTile(cell) != sandCross)
                {
                    Tilemap.SetTile(cell, sandSide);
                }
            }

        }

        if (Input.GetKey("w") &&CurrentPos.y<6.3)
        {
            this.transform.position = new Vector2(CurrentPos.x, CurrentPos.y + moveSpeed * Time.deltaTime);
            if (currentCell != cell)
            {
                if (Tilemap.GetTile(cell) == sandSide)
                {
                    Vector3Int cameFrom = new Vector3Int(cell.x, cell.y -1, cell.z);
                    Tilemap.SetTile(cameFrom, sandCross);
                    Tilemap.SetTile(cell, sandCross);
                }
                else if (Tilemap.GetTile(cell) != sandCross)
                {
                    Tilemap.SetTile(cell, sandTrack);
                }
            }
        }

        if (Input.GetKey("s")&&CurrentPos.y >-6.4)
        {
            this.transform.position = new Vector2(CurrentPos.x, CurrentPos.y - moveSpeed * Time.deltaTime);
            if (currentCell != cell)
            {
                if (Tilemap.GetTile(cell) == sandSide)
                {
                    Tilemap.SetTile(cell, sandCross);
                    Vector3Int cameFrom = new Vector3Int(cell.x, cell.y+1, cell.z);
                    Tilemap.SetTile(cameFrom, sandCross);
                }
                else if (Tilemap.GetTile(cell) != sandCross)
                {
                    Tilemap.SetTile(cell, sandTrack);
                }
            }
        }
        currentCell = cell;
    }
}
