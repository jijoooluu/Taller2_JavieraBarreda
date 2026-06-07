using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int monedas;
    public int puntajeFinal;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
       
    }

    public void ReiniciarDatos()
    {
    monedas = 0;
    puntajeFinal = 0;
    }
    public void AgregarMoneda()
    {
    monedas++;

    Debug.Log("Monedas: " + monedas);
    }

    
}

