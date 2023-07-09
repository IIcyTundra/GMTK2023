using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialAttack : MonoBehaviour
{
    
    [Header("Projectile Settings")]
    public GameObject ProjectilePrefab;
    public int numProjectiles = 10;
    public float waveRadius = 5f;
    public float waveSpeed = 5f;
    public float Cooldown = 15f;

    [Header("Priv Variables")]
    private Vector3 StartPoint;
    private const float radius = 1f;
    bool _CanUse;

    private void Start()
    {
        _CanUse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && _CanUse == true)
        {
            StartCoroutine(ShootWave());
        }
    }

    IEnumerator ShootWave()
    {
        _CanUse = false;
        float angleStep = 360f / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.right;

            CallPrefab();
            Rigidbody2D rb = ProjectilePrefab.GetComponent<Rigidbody2D>();
            rb.velocity = direction * waveSpeed;

            yield return new WaitForSeconds(0.1f);
        }

        
        Invoke("SkillCooldown", Cooldown);
    }
    public bool Get_CanUse()
    {
        return _CanUse;
    }


    private void CallPrefab()
    {
        ProjectilePrefab = ObjectPooling.GiveObj(0);
        if (ProjectilePrefab != null)
        {
            ProjectilePrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
            ProjectilePrefab.SetActive(true);
        }
    }

    private void SkillCooldown()
    {
        _CanUse = true;
    }

}
