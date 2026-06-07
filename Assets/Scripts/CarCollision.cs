using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.puntajeFinal =
                Mathf.FloorToInt(other.transform.position.z);


            MusicManager musicManager = FindObjectOfType<MusicManager>();

            if (musicManager != null)
        {
            musicManager.PlayGameOverMusic();
        }

            SceneManager.LoadScene("GameOver");
        }
    }
}
