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

    [SerializeField] private GameObject player;
    private GameObject solarFlare;
    private RadialAttack ra;
    // Start is called before the first frame update
    private void Awake()
    {
        sl = gameObject.GetComponent<Slider>();
        solarFlare = player.transform.Find("SkillHandler/Solar Flare").gameObject;
        ra = solarFlare.GetComponent<RadialAttack>();
    }

    void Start()
    {
        cooldownTime = ra.Cooldown;
        sl.maxValue = cooldownTime;
        sl.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartCooldown()
    {
        timeRemaining = cooldownTime;
        sl.value = timeRemaining;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            sl.value = Mathf.Lerp(cooldownTime, 0, 1 - (timeRemaining / cooldownTime));
            yield return null;
        }

        sl.value = 0;
       
    }
}
