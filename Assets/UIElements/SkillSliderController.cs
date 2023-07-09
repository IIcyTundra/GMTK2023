using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderController : MonoBehaviour
{
    [SerializeField] private Slider sl;
    private float cooldownTime;
    private float timeRemaining;
    private bool readyForCooldown = true;

    [SerializeField] private GameObject player;
    private GameObject solarFlare;
    private RadialAttack ra;
    // Start is called before the first frame update
    private void Awake()
    {
        sl = gameObject.GetComponent<Slider>();
        solarFlare = player.transform.Find("Solar Flare").gameObject;
        ra = solarFlare.GetComponent<RadialAttack>();
    }

    void Start()
    {
        sl.maxValue = cooldownTime;
        sl.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartCooldown()
    {
        
        timeRemaining = cooldownTime;
        sl.value = timeRemaining;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            sl.value = Mathf.Lerp(cooldownTime, 1 - (timeRemaining / cooldownTime), 0);
            yield return null;
        }

        sl.value = 0;
       
    }
}
