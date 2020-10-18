using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Drone;
    public Tile sandCross;
    public Tile sandTrack;
    public Tile sandSide;
    public Tilemap Tilemap;
    public Vector3Int currentCell;
    public float Drones = 3;
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
        if (Input.GetKeyDown("q") && Drones > 0)
        {
            GameObject newDrone = Instantiate(Drone, new Vector3(CurrentPos.x, CurrentPos.y, -1), Quaternion.identity);
            newDrone.GetComponent<DroneScript>().Direction = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            Drones--;
        }
        if (Input.GetKey("a")&& CurrentPos.x > -14.5)
        {
            
   
            this.transform.rotation = new Quaternion(0, 0, 0.7071068f, 0.7071068f);
            this.transform.position = new Vector3(CurrentPos.x - moveSpeed * Time.deltaTime, CurrentPos.y, -1);
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

        if (Input.GetKey("d") && CurrentPos.x < 14.3)
        {
            
            this.transform.rotation = new Quaternion(0, 0, 0.7071068f, -0.7071068f);
            this.transform.position = new Vector3(CurrentPos.x + moveSpeed * Time.deltaTime, CurrentPos.y, -1);
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
            
            this.transform.rotation = new Quaternion(0, 0, 0, 1);
            this.transform.position = new Vector3(CurrentPos.x, CurrentPos.y + moveSpeed * Time.deltaTime, -1);
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
           
            this.transform.rotation = new Quaternion(0, 0, 1, 0);
            this.transform.position = new Vector3(CurrentPos.x, CurrentPos.y - moveSpeed * Time.deltaTime, -1);
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
