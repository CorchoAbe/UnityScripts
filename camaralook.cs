using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaralook : MonoBehaviour
{
    public float sensibilidadRaton = 80f;
    public Transform playerBody;

    float xRotation = 0;

    void Start()
    {
        // Si tienes alguna inicialización, puedes ponerla aquí
        // Asegúrate de que el cursor esté bloqueado en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Verifica que la cámara reciba la entrada del ratón
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadRaton * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadRaton * Time.deltaTime;

        // Aplicar rotación vertical
        xRotation -= mouseY;

        // Evitamos que traspase ciertos ángulos la cámara, o sea hasta los 90 grados
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplicar rotación a la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Aplicar rotación horizontal al cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);
    }
}