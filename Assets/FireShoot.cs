using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float Cooldown;
    bool _CanUse;

    AudioSource SkillSfx;


    private void Start()
    {
        _CanUse = true;
        SkillSfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _CanUse == true)
        {
            ShootFireBall();
        }
    }

    private void ShootFireBall()
    {
        Vector3 mousePosition = GameObject.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 shootDirection = (mousePosition - GameObject.Find("Player").GetComponent<Transform>().position).normalized;

        CallPrefab();
        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * projectileSpeed;

        Invoke("SkillCooldown", Cooldown);
    }

    private void CallPrefab()
    {
        projectilePrefab = ObjectPooling.GiveObj(1);
        if (projectilePrefab != null)
        {
            projectilePrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
            projectilePrefab.SetActive(true);
        }
    }

    public bool Get_CanUse()
    {
        return _CanUse;
    }

    private void SkillCooldown()
    {
        Debug.Log("Skil1 Back!");
        _CanUse = true;
    }


}
