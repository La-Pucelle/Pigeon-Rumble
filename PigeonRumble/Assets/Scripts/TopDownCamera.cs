using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0, 3, -6); // Offset de la c�mara con respecto al jugador

    void Update()
    {
        if (jugador != null)
        {
            // Actualiza la posici�n de la c�mara para seguir al jugador con el offset
            transform.position = jugador.position + offset;
        }
    }
}
