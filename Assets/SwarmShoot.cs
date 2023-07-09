using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwarmShoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float Cooldown;
    bool _CanUse;

    AudioSource SkillSfx;
    // Start is called before the first frame update
    void Start()
    {
        _CanUse = true;
        SkillSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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

        if (mousePosition.y >= 1f)
        {
            shootDirection = (-mousePosition - GameObject.Find("Player").GetComponent<Transform>().position).normalized;
        }
        else
        {
             shootDirection = (mousePosition - GameObject.Find("Player").GetComponent<Transform>().position).normalized;
        }

            CallPrefab(shootDirection);
        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * projectileSpeed;

        Invoke("SkillCooldown", Cooldown);
    }


    private void CallPrefab(Vector3 _shootDirection)
    {
        projectilePrefab = ObjectPooling.GiveObj(2);
        if (projectilePrefab != null)
        {
            projectilePrefab.transform.SetPositionAndRotation(new Vector3(_shootDirection.x, _shootDirection.y+10, 0), transform.rotation);
      
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
