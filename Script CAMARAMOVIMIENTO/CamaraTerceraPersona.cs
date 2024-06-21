using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTerceraPersona : MonoBehaviour
{
    public Transform objetivo;  // El objeto al que la cámara seguirá (el personaje)
    public Vector3 offset = new Vector3(0, 1.7f, -5);  // Desplazamiento de la cámara respecto al personaje (posición relativa)
    public float suavizado = 5f;  // Velocidad de suavizado de movimiento de la cámara

    void Update()
    {
        // Asegurar que la cámara siga al objetivo suavemente
        Vector3 posicionDeseada = objetivo.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);

        // Asegurar que la cámara mire hacia el objetivo
        transform.LookAt(objetivo);
    }
}