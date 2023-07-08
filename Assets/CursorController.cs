using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 1f;

    private void Update()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 direction = mousePos - player.position;

        transform.position = player.position + direction.normalized * distanceFromPlayer;
    }
}
