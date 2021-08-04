using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _player;

    public Transform CameraRig;
    public Vector3 Offset;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //Transform[] childGameObjects = _player.GetComponentsInChildren<Transform>();
        //foreach (Transform transform in childGameObjects)
        //{
        //    if (transform.gameObject.name == "CameraRig")
        //    {
        //        CameraRig = transform;
        //        break;
        //    }
        //}
    }


    void Update()
    {
        transform.position = _player.transform.position + Offset;
        transform.LookAt(CameraRig);
    }
}
