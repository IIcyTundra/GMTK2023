using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullets:MonoBehaviour
{
    public static List<GameObject> bullets = new List<GameObject>();
    public GameObject bulletObj;
    public float bulletTime = 1f;

    private float timer = 0f;
    void Update()
    {
        foreach(GameObject bullet in bullets)
        {
            if (bullet.transform.position.y < -7f)
            {
                bullets.Remove(bullet);
                Destroy(bullet);
            }
        }
        timer -= Time.deltaTime;
        if (timer < 0.1f)
        {
            timer = bulletTime;
            GameObject newbullet = Instantiate(bulletObj);
            newbullet.transform.position += new Vector3(Random.Range(-9f,9f),0f,0f);
            newbullet.SetActive(true);
            bullets.Add(newbullet);
        }
    }
}
