using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxEffect = 0.5f;
    [SerializeField] private float speed = 1.0f;
    private float length, startPos;
    private float time, timeDelay;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 1.0f;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1.0f * Time.deltaTime;
        if(time >= timeDelay)
        {
            isMoving = true;
            transform.Translate(Vector3.left * parallaxEffect * Time.deltaTime);

            if (transform.position.x < startPos - length)
            {
                transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
            }
        }
    }

    public bool getIsMoving()
    {
        return this.isMoving;
    }
}
