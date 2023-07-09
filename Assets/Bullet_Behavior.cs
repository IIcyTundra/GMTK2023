using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    public float bulletLifetime;


    public void Awake()
    {
        Invoke("RemoveBullet", bulletLifetime);
    }


    public void RemoveBullet()
    {
        ObjectPooling.Takeobj(gameObject);
    }
}
