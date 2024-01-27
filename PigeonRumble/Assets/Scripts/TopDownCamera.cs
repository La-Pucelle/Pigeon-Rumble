using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0, 3, -6); // Offset de la c�mara con respecto al jugador
    public float suavizado = 5.0f; // Valor de suavizado, ajusta seg�n sea necesario

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Calcula la posici�n objetivo de la c�mara
            Vector3 posicionObjetivo = jugador.position + offset;

            // Interpola suavemente la posici�n actual de la c�mara hacia la posici�n objetivo
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);
        }
    }
}
