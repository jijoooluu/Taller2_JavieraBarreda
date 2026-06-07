using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSection : MonoBehaviour
{
    [Header("Puntos de aparición")]
    public Transform spawnLeft;
    public Transform spawnCenter;
    public Transform spawnRight;

    [Header("Prefabs")]
    public GameObject zombiePrefab;
    public GameObject coinPrefab;
    public GameObject[] carPrefabs;

    private GameObject objetoActual;

    public void GenerarContenido()
    {
        if (objetoActual != null)
        {
            Destroy(objetoActual);
        }

        Transform[] carriles =
        {
            spawnLeft,
            spawnCenter,
            spawnRight
        };

        Transform puntoSpawn =
            carriles[Random.Range(0, carriles.Length)];

        int tipo = Random.Range(0, 3);

        if (tipo == 0)
        {
            objetoActual = Instantiate(
                coinPrefab,
                puntoSpawn.position,
                Quaternion.identity,
                transform
            );
        }
        else if (tipo == 1)
        {
            objetoActual = Instantiate(
                zombiePrefab,
                puntoSpawn.position,
                Quaternion.identity,
                transform
            );
        }
        else
        {
            objetoActual = Instantiate(
                carPrefabs[Random.Range(0, carPrefabs.Length)],
                puntoSpawn.position,
                Quaternion.identity,
                transform
            );
        }
    }
}