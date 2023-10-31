using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 2.5f, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if(offset.y > 0)
        {
            offset.y -= 0.01f;
        }
        // offset = new Vector3(0, 0, -1);
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
