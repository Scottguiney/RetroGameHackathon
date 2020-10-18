using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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
    public GameObject Light;
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

            UpdateLight();
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
            UpdateLight();
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
            UpdateLight();
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
            UpdateLight();
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

    void UpdateLight()
    {
        Vector3 CurrentPos = this.transform.position;
        Collider2D[] BoxOverlap = Physics2D.OverlapBoxAll(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(5, 5), 0);
        if (BoxOverlap.Length == 0)
        {
            Light.GetComponent<Image>().color = new Color32(52, 255, 0, 125);
        }
        foreach (Collider2D item in BoxOverlap)
        {
            if (item.gameObject.tag == "Mine")
            {
                Vector3 MinePos = item.transform.position;
                Vector3 MineDistance = CurrentPos - MinePos;
                if (MineDistance.magnitude <= 2)
                {
                    Light.GetComponent<Image>().color = new Color32(255, 7, 0, 125);
                    break;
                }
                else
                {
                    Light.GetComponent<Image>().color = new Color32(255, 206, 0, 125);
                }
            }
        }
        
    }
}
