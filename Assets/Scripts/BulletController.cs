using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    // private float _timeTmp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.rotation = player.transform.rotation;
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Debug.Log(Time.time - _timeTmp);
        // _timeTmp = Time.time;
        // transform.Translate(Vector3.forward * speed);
    }
}
