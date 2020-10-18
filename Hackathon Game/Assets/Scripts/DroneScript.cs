using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    public AudioClip droneStart;
    public AudioClip droneEnd;
    public float Speed = 5;
    public Quaternion Direction;
    private Vector3 TravelDir;
    // Start is called before the first frame update
    void Start()
    {
        if (Direction == new Quaternion(0, 0, 0.7071068f, 0.7071068f))
        {
            TravelDir = new Vector2(-1, 0);
        }
        else if (Direction == new Quaternion(0, 0, -0.7071068f, 0.7071068f))
        {
            TravelDir = new Vector2(1, 0);
        }
        else if (Direction == new Quaternion(0, 0, 0, 1))
        {
            TravelDir = new Vector2(0, 1);
        }
        else if (Direction == new Quaternion(0, 0, 1, 0))
        {
            TravelDir = new Vector2(0, -1);
        }

        transform.position = new Vector3(transform.position.x + TravelDir.x, transform.position.y + TravelDir.y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + TravelDir * Speed * Time.deltaTime;
        transform.position = new Vector3(newPos.x, newPos.y, -1);
        if (transform.position.x < -15 || transform.position.x > 15 || transform.position.y < -8 || transform.position.y > 8)
        {
            Destroy(this.gameObject);
        }
    }
}
