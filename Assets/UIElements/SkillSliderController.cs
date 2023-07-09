using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderController : MonoBehaviour
{
    [SerializeField] private Slider sl;
    private float cooldownTime;
    private float timeRemaining;
    private bool isCooldown;

    [SerializeField] private RadialAttack ra;
    // Start is called before the first frame update
    private void Awake()
    {
        sl = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
