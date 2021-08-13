using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        LookPlayer();
    }

    private void LookPlayer()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(bullet, barrel.position, barrel.rotation);
        }
    }
}