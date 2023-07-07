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

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        StateMachine();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    #region Player Movement
    private void GetInput()
    {
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
        if(moveX != 0 && moveY != 0)
        {
            P_S = PlayerState.Walking;
        }
        else
        {
            P_S = PlayerState.Idle;
        }
        switch(P_S)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walking:
                GetInput();
                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Stunned:
                //P_Reference.PlayerSpeed *= (Some Speed Debuff)
                break;
        }
    }

    #endregion
}