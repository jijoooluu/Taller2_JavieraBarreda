using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioSource audioSource;
    public AudioClip shootSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab,
                        firePoint.position,
                        firePoint.rotation);

            audioSource.PlayOneShot(shootSound);
        }
    }
}