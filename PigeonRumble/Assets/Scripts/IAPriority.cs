using System.Collections;
using UnityEngine;

public class PriorityAI : MonoBehaviour
{
    private string currentState = "idle"; // Initial state
    public wating = 4.5f
    void Start()
    { //hola
        // empieza la priorizacion
        StartCoroutine(Prioritize());
    }

    IEnumerator Prioritize()
    {
        while (true) // Comprobacion del estado del 
        {
            // De manera dinamica una vez que recibimos el estado los asignamos y comenzamos la logica
            switch (currentState)
            {
                case "attacking":
                    Debug.Log("Priority: Attacking");
                    yield return new WaitForSeconds(wating); 
                    break;
                case "eating":
                    Debug.Log("Priority: Eating");
                    yield return new WaitForSeconds(wating);
                    break;
                case "idle":
                default:
                    Debug.Log("Priority: Idle");
                    yield return new WaitForSeconds(wating); 
                    break;
            }
        }
    }

    public void ChangeState(string newState)
    {
        currentState = newState;
    }
}
