using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject Bullet;
    public int Velocity = 5;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        Fire();
    }

    private void Move()
    {
        _rigidbody.velocity =
            (Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.forward).normalized *
            Velocity;
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
        if (Input.GetButton("Fire1"))
        {
            Instantiate(Bullet);
        }
    }
}