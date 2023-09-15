using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemyBehaviour
{
    private float speed;

    public Skeleton(float health, float speed) : base(health)
    {
        this.speed = speed;
     
    }
}
