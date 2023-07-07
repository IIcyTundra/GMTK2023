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

    [SerializedField] private float CurrentPlayerSpeed;
    [SerializedField] private float CurrentPlayerHealth;
    [SerializedField] private float CurrentPlayerMana;
    private Rigidbody2D PlayerRb;
    private Vector2 Movement;

    float moveX;
    float moveY;

    private void Awake()
    {
        CurrentPlayerSpeed = P_Reference._playerSpeed;
        CurrentPlayerHealth = P_Reference._playerHealth;
        CurrentPlayerMana =  P_Reference._playerMana;
        PlayerRb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        GetInput();
        StateMachine();

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
        PlayerRb.velocity = Movement * CurrentPlayerSpeed;
    }
    #endregion


    #region State Machine
    private void StateMachine()
    {
        //Determine Player State
        if(moveX != 0 || moveY != 0 )
        {
            P_S = PlayerState.Walking;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button Pressed");
            P_S = PlayerState.Stunned;
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
                StartCourotine(StunDuration(3f));
                break;
        }
    }

    #endregion



    IEnumerator StunDuration(float timer)
    {
        
        CurrentPlayerSpeed *= 0.2f;
        yield return new WaitforSeconds(timer);
        //P_Reference.PlayerSpeed 
        CurrentPlayerSpeed = P_Reference._playerSpeed;
    }
}