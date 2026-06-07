using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinText;

    public Transform player;

    void Update()
    {
        scoreText.text =
            "Puntaje: " +
            Mathf.FloorToInt(player.position.z);

        coinText.text =
            "Monedas: " +
            GameManager.Instance.monedas;
    }
}