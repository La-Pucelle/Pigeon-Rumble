using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TopDownCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // El objeto que seguir� la c�mara
    public float height = 10f; // Altura de la c�mara
    public float distance = 10f; // Distancia de la c�mara
    public float rotationSpeed = 5f; // Velocidad de rotaci�n de la c�mara

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la rotaci�n basada en la entrada del usuario
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

            // Calcula la posici�n de la c�mara basada en la posici�n del objetivo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Interpola suavemente la posici�n actual de la c�mara hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);

            // Asegura que la c�mara siempre mire hacia el objetivo
            transform.LookAt(target.position);
        }
    }
}
