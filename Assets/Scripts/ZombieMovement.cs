using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieMovement : MonoBehaviour
{
    private float speed;

    public AudioClip deathSound;

    private AudioSource audioSource;
    private bool isDead = false;

    void Start()
    {
        speed = Random.Range(3f, 6f);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(
            Vector3.back * speed * Time.deltaTime,
            Space.World
        );

        // Destruir zombie cuando sale del mapa
        if (transform.position.z < -20f && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.puntajeFinal =
                Mathf.FloorToInt(other.transform.position.z);

            Debug.Log("Puntaje: " + GameManager.Instance.puntajeFinal);
            Debug.Log("Monedas: " + GameManager.Instance.monedas);

            MusicManager musicManager = FindObjectOfType<MusicManager>();

            if (musicManager != null)
        {
             musicManager.PlayGameOverMusic();
        }

            SceneManager.LoadScene("GameOver");
        }
    }

    public void Die()
{
    if (isDead) return;

    isDead = true;

    speed = 0f;

    if (audioSource != null && deathSound != null)
    {
        AudioSource.PlayClipAtPoint(
            deathSound,
            transform.position
        );
    }

    Destroy(gameObject);
}
}