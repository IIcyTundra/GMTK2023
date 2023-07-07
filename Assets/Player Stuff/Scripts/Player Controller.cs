using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Attacking,
    Stunned

}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats P_Reference;
    [SerializeField] private PlayerState P_S;
    private Rigidbody2D PlayerRb;
    private Vector2 Movement;

    float moveX;
    float moveY;

    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    private void Start() 
    {
        
    }

    private void Update()
    {
        GetInput();
        StateMachine();

        if(Input.GetKeyDown(KeyCode.E))
        {
            P_S = PlayerState.Stunned;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    #region Player Movement
    private void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Movement = new Vector2(moveX, moveY).normalized;
    }

    private void MovePlayer()
    {
        PlayerRb.velocity = Movement * P_Reference.PlayerSpeed;
    }
    #endregion


    #region State Machine
    private void StateMachine()
    {
        //Determine Player State
        if(moveX > 0.1f || moveY > 0.1f )
        {
            P_S = PlayerState.Walking;
        }
        else
        {
            P_S = PlayerState.Idle;
        }


        //Change State
        switch(P_S)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walking:
                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Stunned:
                P_Reference.PlayerSpeed *= 0.5f;
                break;
        }
    }

    #endregion
}