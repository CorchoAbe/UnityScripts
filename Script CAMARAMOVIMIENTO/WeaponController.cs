using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask hittableLayers;  // Capas que pueden ser golpeadas por el disparo
    public GameObject bulletHolePrefab;  // Prefab para el agujero de bala

    [Header("Shoot Parameters")]
    public float fireRange = 200f;  // Rango máximo del disparo

    private Camera mainCamera;  // Referencia a la cámara principal

    private void Start()
    {
        // Asigna la cámara principal al iniciar
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Maneja la entrada de disparo en cada frame
        HandleShoot();
    }

    private void HandleShoot()
    {
        // Verifica si se presiona el botón de disparo
        if (Input.GetButtonDown("Fire1"))
        {
            // Crea un rayo desde el centro de la pantalla
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            // Realiza el raycast y verifica si golpea algo dentro del rango especificado y en las capas definidas
            if (Physics.Raycast(ray, out hit, fireRange, hittableLayers))
            {
                // Verifica si el prefab del agujero de bala está asignado
                if (bulletHolePrefab != null)
                {
                    // Instancia el prefab del agujero de bala en el punto de impacto, ligeramente desplazado para evitar solapamientos
                    GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));

                    // Destruye el prefab del agujero de bala después de 4 segundos
                    Destroy(bulletHoleClone, 4f);
                }
                else
                {
                    // Muestra una advertencia si el prefab del agujero de bala no está asignado
                    Debug.LogWarning("Bullet hole prefab is not assigned.");
                }
            }
        }
    }
}
