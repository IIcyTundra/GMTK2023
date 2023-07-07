using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private PlayerController StateAccess;
    
    void Awake()
    {
        StateAccess = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shooting()
    {
        
    }
}
