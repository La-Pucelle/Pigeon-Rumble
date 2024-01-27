using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0, 3, -6); // Offset de la cámara con respecto al jugador
    public float suavizado = 5.0f; // Valor de suavizado, ajusta según sea necesario

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Calcula la posición objetivo de la cámara
            Vector3 posicionObjetivo = jugador.position + offset;

            // Interpola suavemente la posición actual de la cámara hacia la posición objetivo
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);
        }
    }
}
