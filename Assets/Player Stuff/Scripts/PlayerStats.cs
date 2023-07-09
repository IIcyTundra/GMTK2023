using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Create Player/Player Stats", order = 0)]
public class PlayerStats : ScriptableObject 
{
    //Variables
    public float _playerHealth {get; set;} = 100;
    public float _playerMana {get; set;} = 100;
    public float _playerSpeed {get; set;} = 2;
    
  

   
}
