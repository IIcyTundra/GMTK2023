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
        if(Input.GetKeyDown(KeyCode.E))
            StartCoroutine(CallBullet(5));
    }


    public IEnumerator CallBullet(float remove)
    {
        
        bulletObj = ObjectPooling.GiveObj(0);
        if (bulletObj != null)
        {
            bulletObj.transform.position += new Vector3(Random.Range(-9f,9f),0f,0f);
            bulletObj.SetActive(true);
        }
        yield return new WaitForSeconds(remove);

        ObjectPooling.Takeobj(bulletObj);
    }
}

