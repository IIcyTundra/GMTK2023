using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class AI_Behavior : MonoBehaviour
{
    //private Ai_Pathfinding pathfindingMovement;
    //private Vector3 StartingPosition;
    //private Vector3 RoamPosition;

    //private void Awake()
    //{
    //    pathfindingMovement = GetComponent<Ai_Pathfinding>();
    //}
    //private void Start()
    //{
    //    StartingPosition = transform.position;
    //}

    //private void Update()
    //{
    //    pathfindingMovement.MoveTo(RoamPosition);

    //    float reachedPositionDistance = 1f;
    //    if(Vector3.Distance(transform.positionm, RoamPosition) < reachedPositionDistance)
    //    {
    //        RoamPosition = GetRoamingPosition();
    //    }
    //}

    //private Vector3 GetRoamingPosition()
    //{
    //    return StartingPosition + UtilsClass.GetRandomDir() * Random.Range(10f, 10f);
    //}

}
