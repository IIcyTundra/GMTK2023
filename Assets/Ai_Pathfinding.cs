using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Pathfinding : MonoBehaviour
{

    private const float SPEED = 30f;

    private EnemyMain enemyMain;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathfindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Awake()
    {
        enemyMain = GetComponent<EnemyMain>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfindingTimer = Time.deltaTime;

        HandleMovement();
    }

    private void FixedUpdate()
    {
        enemyMain.EnemyRb2D.velocity = moveDir * SPEED;
    }

    private void HandleMovement()
    {

    }
}
