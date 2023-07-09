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
        if (!PauseManager.instance.isPaused) {
            // shoot
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
