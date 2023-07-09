using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    public float bulletLifetime;


    public void Update()
    {
        if(gameObject.activeSelf)
            StartCoroutine(RemoveBullet(bulletLifetime));
    }


    public IEnumerator RemoveBullet(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.Takeobj(gameObject);
    }
}
