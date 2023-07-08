using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHP : MonoBehaviour
{
    [Header("Testing - Editor and Runtime Only")]
    [SerializeField] private PlayerStats ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.G))
        {
            ps._playerHealth += 5;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ps._playerHealth -= 5;
        }
#endif
    }
}
