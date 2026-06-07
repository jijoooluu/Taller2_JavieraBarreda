using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinText;

    void Start()
    {
        scoreText.text =
            "Puntaje: " +
            GameManager.Instance.puntajeFinal;

        coinText.text =
            "Monedas: " +
            GameManager.Instance.monedas;
    }
}