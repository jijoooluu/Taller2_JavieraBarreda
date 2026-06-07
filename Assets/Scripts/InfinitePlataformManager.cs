using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformManager : MonoBehaviour
{
    public Transform player;

    public List<Transform> plataformas;

    public float largoPlataforma = 10f;

    void Update()
    {
        Transform primera = plataformas[0];

        if (player.position.z >
            primera.position.z + largoPlataforma)
        {
            ReubicarPlataforma();
        }
    }

    void ReubicarPlataforma()
    {
        Transform primera = plataformas[0];

        Transform ultima =
            plataformas[plataformas.Count - 1];

        primera.position = new Vector3(
            primera.position.x,
            primera.position.y,
            ultima.position.z + largoPlataforma
        );

    PlatformSection section =
            primera.GetComponent<PlatformSection>();

    if (section != null)
    {
    section.GenerarContenido();
    }

        plataformas.RemoveAt(0);
        plataformas.Add(primera);
    }
}