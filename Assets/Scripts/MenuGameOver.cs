using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


///
/// Controla las acciones disponibles en el menú de derrota (Game Over).
/// Permite reiniciar la partida, restaurar los datos del juego
/// y volver a cargar la escena principal.
///
public class MenuGameOver : MonoBehaviour
{

    ///
    /// Reinicia la partida actual.
    /// Restablece los datos almacenados en el GameManager,
    /// reproduce la música principal del juego y carga
    /// nuevamente la escena de juego.
    ///
    public void Reintentar()
    {
        // Reinicia los datos de la partida.
        GameManager.Instance.ReiniciarDatos();
        // Obtiene la referencia al administrador de música.
        MusicManager musicManager =
            Object.FindFirstObjectByType<MusicManager>();

        // Reproduce la música principal del juego.
        if (musicManager != null)
        {
            musicManager.PlayGameMusic();
        }

        // Carga nuevamente la escena principal.
        SceneManager.LoadScene("Game");
    }
}