using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  // Velocidad de movimiento del personaje
    public float velocidadGiro = 720f;  // Velocidad de giro del personaje

    private Vector3 movimiento;  // Vector para almacenar la dirección del movimiento
    private Rigidbody rb;  // Referencia al componente Rigidbody del personaje

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtener el componente Rigidbody al inicio
    }

    void Update()
    {
        // Obtener entrada del jugador desde el teclado
        float moverHorizontal = Input.GetAxis("Horizontal");  // Entrada horizontal (A/D o flechas izquierda/derecha)
        float moverVertical = Input.GetAxis("Vertical");  // Entrada vertical (W/S o flechas arriba/abajo)

        // Calcular el vector de movimiento en los ejes X y Z
        movimiento = new Vector3(moverHorizontal, 0.0f, moverVertical);  // Normalizar el vector para asegurar que el personaje no se mueva más rápido en diagonal

        // Rotar el personaje en la dirección del movimiento
        if (movimiento.magnitude > 0.1f)  // Comprobar si el vector de movimiento no es cero
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento, Vector3.up);  // Calcular la rotación objetivo
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionObjetivo, velocidadGiro * Time.deltaTime);  // Rotar el personaje hacia la rotación objetivo
        }
    }

    void FixedUpdate()
    {
        // Mover el personaje aplicando el vector de movimiento
        rb.MovePosition(rb.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);  // Calcular la nueva posición y mover el Rigidbody
    }
}