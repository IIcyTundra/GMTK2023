using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionFrameController : MonoBehaviour
{
    private enum WeaponState
    {
        FireBall,
        HarpySwarm,
        SolarFlare
    }
    //private RectTransform rt;
    //private Vector3 skill1Pos = new Vector3(41.69402f, -385.6097f, 0f);
    //private Vector3 skill2Pos = new Vector3(369.4147f, -385.6097f, 0f);
    //private Vector3 skill3Pos = new Vector3(697.1354f, -385.6097f, 0f);
    [SerializeField] private GameObject skillHandler;

    [SerializeField] private GameObject[] selectionFrames;
    private WeaponState state;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();

        switch (state)
        {
            case WeaponState.FireBall:
                selectionFrames[0].SetActive(true);
                selectionFrames[1].SetActive(false);
                selectionFrames[2].SetActive(false);
                break;
            case WeaponState.HarpySwarm:
                selectionFrames[0].SetActive(false);
                selectionFrames[1].SetActive(true);
                selectionFrames[2].SetActive(false);
                break;
            case WeaponState.SolarFlare:
                selectionFrames[0].SetActive(false);
                selectionFrames[1].SetActive(false);
                selectionFrames[2].SetActive(true);
                break;
        }
    }

    private void StateMachine()
    {
        if (skillHandler.transform.Find("FireBall").gameObject.activeSelf)
        {
            state = WeaponState.FireBall;
        }
        if (skillHandler.transform.Find("Harpy Swarm").gameObject.activeSelf)
        {
            state = WeaponState.HarpySwarm;
        }
        if (skillHandler.transform.Find("Solar Flare").gameObject.activeSelf)
        {
            state = WeaponState.SolarFlare;
        }
    }
}
