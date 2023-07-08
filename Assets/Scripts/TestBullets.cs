using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullets:MonoBehaviour
{
    GameObject bulletObj;
    public float bulletTime = 1f;

    private float timer = 0f;
    void Update()
    {
        CallBullet();
        RemoveBullet();
        
    }


    public void CallBullet()
    {
        timer -= Time.deltaTime;
        if (timer < 0.1f)
        {
            timer = bulletTime;
            bulletObj = ObjectPooling.GiveObj(0);
            if (bulletObj != null)
            {
                bulletObj.transform.position += new Vector3(Random.Range(-9f,9f),0f,0f);
                bulletObj.SetActive(true);
            }
        }
    }

    public void RemoveBullet()
    {
        if (bulletObj.transform.position.y < -7f)
        {
            ObjectPooling.Takeobj(bulletObj);
        }
    }
}
