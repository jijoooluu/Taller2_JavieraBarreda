using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private bool recogida = false;

    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (recogida) return;

        if (other.CompareTag("Player"))
        {
            recogida = true;

            GameManager.Instance.AgregarMoneda();

            Debug.Log("Moneda recogida: " + gameObject.name);

            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    coinSound,
                    transform.position,
                    2f
                );
            }

            Destroy(gameObject);
        }
    }
}