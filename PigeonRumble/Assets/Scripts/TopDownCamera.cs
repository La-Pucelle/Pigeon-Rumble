using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0, 3, -6); // Offset de la cámara con respecto al jugador

    void Update()
    {
        if (jugador != null)
        {
            // Actualiza la posición de la cámara para seguir al jugador con el offset
            transform.position = jugador.position + offset;
        }
    }
}
