using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Create Player/Player Stats", order = 0)]
public class PlayerStats : ScriptableObject 
{
    //Variables
    [SerializeField] private float _playerHealth = 100;
    [SerializeField] private float _playerMana = 100;
    [SerializeField, Range(0.1f, 10f)] private float _playerSpeed;


    //Variable Getter/Setters

    [HideInInspector]
    public float PlayerHealth
    {
        get{return _playerHealth;}

        set{_playerHealth = value;}
    }

    [HideInInspector]
    public float PlayerMana
    {
        get{return _playerMana;}

        set{_playerMana = value;}
    }

    [HideInInspector]
    public float PlayerSpeed
    {
        get{return _playerSpeed;}

        set{_playerSpeed = value;}
    }
   

   
}
