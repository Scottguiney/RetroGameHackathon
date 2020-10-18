using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivillianScript : MonoBehaviour
{
    public float MoveSpeed;
    public float SleepTime;
    bool Awake;
    float Timer;
    public float FollowPlayerDistance;
    public GameObject Player;
    public Sprite AwakeSprite;
    // Start is called before the first frame update
    void Start()
    {
        Awake = false;
        FollowPlayerDistance = 5;
        Timer = 0;
        SleepTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Awake)
        {
            Timer += Time.deltaTime;
            if (Timer >= SleepTime)
            {
                Awake = true;
                this.GetComponent<SpriteRenderer>().sprite = AwakeSprite;
            }
        }
        else
        {
            Vector3 CurrentPos = transform.position;
            Vector3 PlayerPos = Player.transform.position;
            Vector3 VectorToPlayer = PlayerPos - CurrentPos;
            VectorToPlayer.z = -1;
            CurrentPos.z = -1;
            if (VectorToPlayer.magnitude < FollowPlayerDistance)
            {
                if (VectorToPlayer.magnitude > 2)
                {
                    transform.position = CurrentPos + VectorToPlayer * MoveSpeed * Time.deltaTime;
                }
            }
            else
            {
                Vector3 newPos = CurrentPos + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0) * Time.deltaTime * MoveSpeed*4;
                newPos.z = -1;
                transform.position = newPos;
            }
        }
    }


}
