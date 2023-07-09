using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 1f;
    public float rotationSpeed = 200f;
    private Vector3 Offset;
    Vector3 direction;
    private void Start ()
    {
        player = GameObject.Find("Player").GetComponentInParent<Transform>();
        Offset = transform.position - player.position;
    }

    private void Update()
    {
        
        MouseCalc();
        SpriteSpin();
        
    }


    void MouseCalc()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        direction = mousePos - player.position;
        
        Vector3 targetPosition = player.position + Vector3.ClampMagnitude(direction, distanceFromPlayer) + Offset;

        transform.position = targetPosition;
    }

    void SpriteSpin()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

}
