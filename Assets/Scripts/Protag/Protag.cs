using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag:MonoBehaviour
{
    public float speed = 4f;
    private float moveX;
    private float moveY;
	private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AIStates();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, moveY).normalized * speed;
    }
    
    private string state = "Idle";
    private string substate = "";
    private float resetSubstate = 0f;
    void AIStates()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, 5f))
        {
            if (collider.tag == "Bullet")
                state = "Dodge";
        }
        switch (state)
        {
            case "Idle":
                if (resetSubstate == 0f) // substate countdown
                {
                    resetSubstate = Random.Range(1f,7f);
                    if (Random.Range(0,2) == 0) // move around
                        state = "Move";
                }
            break;
            case "Move":
                resetSubstate -= Time.deltaTime;
                if (resetSubstate == 0f) // substate countdown
                {
                    resetSubstate = Random.Range(1f,7f);
                    if (Random.Range(0,2) == 0) // idle around
                        state = "Idle";
                    else
                    {
                        substate = "";
                        if (Random.Range(0,2) == 0)
                            substate += "xmove" + (Random.Range(0,2) == 0 ? "pos" : "neg");
                        if (Random.Range(0,2) == 0)
                            substate += "ymove" + (Random.Range(0,2) == 0 ? "pos" : "neg");
                        if (substate == "")
                            substate = "xmove" + (Random.Range(0,2) == 0 ? "pos" : "neg");
                    }
                }

                if (substate.Contains("xmovepos"))
                    moveX = 1f;
                if (substate.Contains("xmoveneg"))
                    moveX = -1f;
                if (substate.Contains("ymovepos"))
                    moveY = 1f;
                if (substate.Contains("ymoveneg"))
                    moveY = -1f;
            break;
            case "Dodge":
                //print("AAAAAA");
            break;
        }
    }
}