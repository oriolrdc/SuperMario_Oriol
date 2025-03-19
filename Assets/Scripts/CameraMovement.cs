using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform playerTransform; //Variable que se puede usar en todos los sitios
    public Vector3 offset;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public float interpolationRatio = 0.5f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset; //Variable local que solo se puede usar en update

        float clampX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x); //Mathf.Clamp es una funcion para limitar algo entre dos valores
        float clampY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y); //Son float pq los vectores siempre podran ser numeros decimales
        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
        
        transform.position = lerpedPosition;
    }
}
