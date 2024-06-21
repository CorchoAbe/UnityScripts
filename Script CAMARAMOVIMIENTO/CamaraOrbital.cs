using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbital : MonoBehaviour
{
    public Transform follow; //Que punto queremos seguir
    public float distancia; //Distancia a la que estara del personaje
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = follow.position + new Vector3(0,0,-distancia);
    }
}
