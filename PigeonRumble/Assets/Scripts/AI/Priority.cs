using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PriorityAI : MonoBehaviour
{
    public Target target;
    public Transform Player;
    public Transform Food;
    string currentState = "idle"; // Initial state
    public float wating = 0.5f;
    void Start()
    { //hola
        // empieza la priorizacion
        StartCoroutine(Prioritize());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = "attacking";
        } 

        else if (other.CompareTag("Food"))
        {
            currentState = "eating";
        }

    }

    IEnumerator Prioritize()
    {
        while (true) // Comprobacion del estado del 
        {
            switch (currentState)
            {
                case "attacking":
                    Debug.Log("Priority: Attacking");
                    target.playerTransform = Player;
                    yield return new WaitForSeconds(wating);
                    currentState = "idle";
                    break;
                case "eating":
                    Debug.Log("Priority: Eating");
                    target.playerTransform = Food;
                    yield return new WaitForSeconds(wating);
                    currentState = "idle";
                    break;
                case "idle":
                default:
                    Debug.Log("Priority: Idle");
                    target.playerTransform = null;
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
