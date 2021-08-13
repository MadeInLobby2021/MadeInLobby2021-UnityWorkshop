using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private float velocity;
    [SerializeField] private float maxDegree;
    private AudioSource audioSource;
    private GameObject player;

    [SerializeField] private float destroyTime;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        player = GameObject.FindWithTag("Player");
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position , player.transform.position , 0.6f);
        var direction = (player.transform.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().velocity = transform.forward * velocity;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            lookRotation, maxDegree );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(hitSFX);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            //todo damage player
            audioSource.PlayOneShot(damageSFX);
            Destroy(gameObject);
        }
    }
}