using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject RightGun;
    [SerializeField] private GameObject LeftGun;
    [SerializeField] private int Velocity = 5;
    [SerializeField] private float gunCoolingTime;
    [SerializeField] private float health;
    private float lastFireTimeRight;
    private float lastFireTimeLeft;
    [SerializeField] private Animator animatorRight;
    [SerializeField] private Animator animatorLeft;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ResetFireAnimation();
        Move();
        Rotate();
        Fire();
    }

    private void ResetFireAnimation()
    {
        if (Time.time > lastFireTimeLeft + 0.1)
        {
            animatorLeft.SetBool("fire", false);
        }

        if (Time.time > lastFireTimeRight + 0.1)
            animatorRight.SetBool("fire", false);
    }

    private void Move()
    {
        _rigidbody.velocity =
            (Input.GetAxis("Vertical") * transform.forward) * Velocity;
        animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
    }

    private void Rotate()
    {
        Plane plane = new Plane(Vector3.up, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            transform.LookAt(hitPoint);
        }
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1") & Time.time > lastFireTimeLeft + gunCoolingTime)
        {
            lastFireTimeLeft = Time.time;
            Instantiate(Bullet, LeftGun.transform.position, LeftGun.transform.rotation);
            animatorLeft.SetBool("fire", true);
        }

        if (Input.GetButton("Fire2") & Time.time > lastFireTimeRight + gunCoolingTime)
        {
            lastFireTimeRight = Time.time;
            Instantiate(Bullet, RightGun.transform.position, RightGun.transform.rotation);
            animatorRight.SetBool("fire", true);
        }
    }
    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //player is dead
            Destroy(gameObject);
        }
    }
}