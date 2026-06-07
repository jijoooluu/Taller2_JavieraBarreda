using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadAdelante = 10f;

    [Header("Carriles")]
    public float distanciaCarril = 4f;

    private int carrilActual = 1; // 0 izquierda, 1 centro, 2 derecha

    [Header("Salto")]
    public float fuerzaSalto = 8f;
    public float gravedad = -20f;

    private float velocidadVertical;

    private CharacterController controller;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireCooldown = 0.5f;

    private float nextFireTime;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CambiarCarril();
        Saltar();
        MoverJugador();
        Disparar();
    }

    void CambiarCarril()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            carrilActual--;
            carrilActual = Mathf.Clamp(carrilActual, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            carrilActual++;
            carrilActual = Mathf.Clamp(carrilActual, 0, 2);
        }
    }

    void Saltar()
    {
        if (controller.isGrounded)
        {
            velocidadVertical = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical = fuerzaSalto;
            }
        }

        velocidadVertical += gravedad * Time.deltaTime;
    }

    void MoverJugador()
    {
        float posicionXDeseada = (carrilActual - 1) * distanciaCarril;

        float diferenciaX = posicionXDeseada - transform.position.x;

        Vector3 movimiento = new Vector3(
            diferenciaX * 10f,
            velocidadVertical,
            velocidadAdelante
        );

        controller.Move(movimiento * Time.deltaTime);
    }

    void Disparar()
{
    if (Input.GetKeyDown(KeyCode.F)
        && Time.time >= nextFireTime)
    {
        Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        nextFireTime =
            Time.time + fireCooldown;
    }
}
}