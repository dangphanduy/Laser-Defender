using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float BasefiringRate = 0.2f;

    [Header("Eneymy")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector]public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true; // AI will always fire
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                            transform.position, 
                                            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.linearVelocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            float timeToNextprojectile = Random.Range(BasefiringRate - firingRateVariance, 
                                                BasefiringRate + firingRateVariance);
            timeToNextprojectile = Mathf.Clamp(timeToNextprojectile, minimumFiringRate, float.MaxValue);
            audioPlayer.playShootingClip();
            yield return new WaitForSeconds(timeToNextprojectile);
        }
    }
}
