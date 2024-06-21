using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFREE : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f; // Velocidad que se desea tener

    // Vamos a crear la gravedad para el salto del personaje
    public float gravity = -9.8f;
    public float jumpHeight = 3f; // Cuánto queremos saltar

    public Transform groundCheck; // Para comprobar si estamos en el suelo o no
    public float groundDistance = 0.3f; // Saber a qué distancia tenemos el suelo
    public LayerMask groundMask; // Para comprobar si estamos en el suelo o no

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        // Si tienes alguna inicialización, puedes ponerla aquí
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Regresará false o true dependiendo si está tocando el suelo o no con esta función

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Afectamos la gravedad poner una f al final el programa detectará que es un float
        }

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z; // Vemos cómo nos queremos mover a través de la entrada de datos del teclado

        controller.Move(move * speed * Time.deltaTime);

        // Unity tiene un input para detectar cuando se está presionando la tecla espacio y estamos en el suelo, para saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Fórmula física para saber la altura con la que se saltará
        }

        velocity.y += gravity * Time.deltaTime; // Aquí para que la gravedad todo el rato no esté atrayendo

        controller.Move(velocity * Time.deltaTime);
    }
}
