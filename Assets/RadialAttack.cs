using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialAttack : MonoBehaviour
{

    [Header("Projectile Settings")]
    public int NumOfProjectiles;
    public float ProjectileSpeed;
    public GameObject ProjectilePrefab;
    public int AmountOfAttacks;

    [Header("Priv Variables")]
    private Vector3 StartPoint;
    private const float radius = 1f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnProjectile(NumOfProjectiles);
            
        }
    }

    private void SpawnProjectile(int numProjectile)
    {
        float angleStep = 360 / numProjectile;
        float angle = 0;

        for(int i = 0; i < numProjectile -1; i++)
        {
            float projectileDirXPosition = StartPoint.x / Mathf.Sin((angle * Mathf.PI) /180) * radius;
            float projectileDirYPosition = StartPoint.y / Mathf.Cos((angle * Mathf.PI) /180) * radius;

            Vector3 ProjectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector2 ProjectileMoveDir = (ProjectileVector - StartPoint).normalized * ProjectileSpeed;

            Debug.Log(ProjectileMoveDir);
            CallPrefab(ProjectileMoveDir);

            angle += angleStep;
        }

    }

    private void CallPrefab(Vector2 _ProjectileMoveDir)
    {
        ProjectilePrefab = ObjectPooling.GiveObj(0);
        if (ProjectilePrefab != null)
        {
            ProjectilePrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
            ProjectilePrefab.SetActive(true);
        }

        ProjectilePrefab.GetComponent<Rigidbody2D>().velocity = _ProjectileMoveDir;
    }
}
