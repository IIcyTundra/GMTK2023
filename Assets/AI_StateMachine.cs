using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateMachine : MonoBehaviour
{
    public float HeroHealth = 100;
    public Transform target;
    public float shootingRange = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootingForce = 3f;

    private bool _canShoot = false;

    float distanceToPlayer;
    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        CheckRange();
        if (_canShoot)
        {
            Debug.Log(_canShoot);
           StartCoroutine(Shoot(2f));
        }

        if(HeroHealth < 0)
        {
            DestroyEnemy();
        }
    }

    void CheckRange()
    {
        if (distanceToPlayer < shootingRange)
        {
            _canShoot = true;
        }
        else
        {
            _canShoot = false;
        }
    }

    IEnumerator Shoot(float time)
    {
        yield return new WaitForSeconds(time);

        Vector2 shootingDirection = (target.position - bulletSpawnPoint.position).normalized;
        CallPrefab();
        Debug.Log(bulletPrefab);
        
        if (bulletPrefab != null)
        {
            bulletPrefab.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootingForce, ForceMode2D.Impulse);
        }

    }

    private void CallPrefab()
    {
        bulletPrefab = ObjectPooling.GiveObj(3);
        if (bulletPrefab != null)
        {
            bulletPrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bulletPrefab.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PBullet")
        {
            HeroHealth -= 10;
        }

    }

    private void DestroyEnemy()
    {
        //change to add back to object pool
        Destroy(gameObject);
    }
}
