using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class RadialAttack : MonoBehaviour
{
    
    [Header("Projectile Settings")]
    public GameObject ProjectilePrefab;
    public int numProjectiles = 10;
    public float waveRadius = 5f;
    public float waveSpeed = 5f;
    public float Cooldown = 15f;

    [Header("Priv Variables")]
    private Vector3 StartPoint;
    private const float radius = 1f;
    [SerializeField] bool _CanUse;

    [Header("UI")]
    [SerializeField] private Slider cooldownSlider;
    private SkillSliderController cooldownController;
    AudioSource SkillSfx;

    private void Awake()
    {
        cooldownController = cooldownSlider.GetComponent<SkillSliderController>();
    }
    private void Start()
    {
        _CanUse = true;
        SkillSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && _CanUse == true)
        {
            StartCoroutine(ShootWave());
        }
    }

    IEnumerator ShootWave()
    {
        _CanUse = false;
        
        float angleStep = 360f / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.right;

            CallPrefab();
            Rigidbody2D rb = ProjectilePrefab.GetComponent<Rigidbody2D>();
            rb.velocity = direction * waveSpeed;

            yield return new WaitForSeconds(0.1f);
        }
        cooldownController.StartCoroutine(cooldownController.StartCooldown());
        Invoke("SkillCooldown", Cooldown);
        
        
    }
    public bool Get_CanUse()
    {
        return _CanUse;
    }


    private void CallPrefab()
    {
        ProjectilePrefab = ObjectPooling.GiveObj(0);
        if (ProjectilePrefab != null)
        {
            ProjectilePrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
            ProjectilePrefab.SetActive(true);
        }
    }

    private void SkillCooldown()
    {
        Debug.Log("Skil3 Back!");
        _CanUse = true;
    }

}
