using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Create Player/Player Stats", order = 0)]
public class PlayerStats : ScriptableObject 
{
    //Variables
    [SerializeField] private float _playerHealth {get; set;} = 100;
    [SerializeField] private float _playerMana {get; set;} = 100;
    [SerializeField, Range(0.1f, 10f)] private float _playerSpeed {get; set;}

   
}
