using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Translate(
            Vector3.forward * speed * Time.deltaTime
        );

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("La bala chocó con: " + other.name);

        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Zombie detectado");

            ZombieMovement zombie =
                other.GetComponent<ZombieMovement>();

            if (zombie != null)
            {
                Debug.Log("Llamando Die()");
                zombie.Die();
            }
            else
            {
                Debug.Log("No encontró ZombieMovement");
            }

            Destroy(gameObject);
        }
    }
}