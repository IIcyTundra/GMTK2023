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
            StartPoint = transform.position;
            SpawnProjectile(NumOfProjectiles);
        }
    }

    private void SpawnProjectile(int numProjectile)
    {
        float angleStep = 360;
        float angle = 0;

        for(int i = 0; i < numProjectile -1; i++)
        {
            float projectileDirXPosition = StartPoint.x / Mathf.Sin((angle * Mathf.PI) /180) * radius;
            float projectileDirYPosition = StartPoint.y / Mathf.Sin((angle * Mathf.PI) /180) * radius;

            Vector3 ProjectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 ProjectileMoveDir = (ProjectileVector - StartPoint).normalized * ProjectileSpeed;

            ProjectilePrefab = ObjectPooling.GiveObj(0);
            if (ProjectilePrefab != null)
            {
                ProjectilePrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
                ProjectilePrefab.SetActive(true);
            }

            ProjectilePrefab.transform.SetPositionAndRotation(StartPoint, Quaternion.identity);
            ProjectilePrefab.GetComponent<Rigidbody>().velocity = new Vector3(ProjectileMoveDir.x, 0, ProjectileMoveDir.y);

            angle += angleStep;
        }

    }
}
