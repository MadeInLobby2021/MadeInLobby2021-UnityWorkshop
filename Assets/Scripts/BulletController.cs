using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyTime;

    private GameObject player;
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitSFX;

    // private float _timeTmp;
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        // transform.rotation = player.transform.rotation;
        // transform.position = player.transform.position;
        audioSource = FindObjectOfType<AudioSource>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(hitSFX);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Debug.Log(Time.time - _timeTmp);
        // _timeTmp = Time.time;
        // transform.Translate(Vector3.forward * speed);
    }
}