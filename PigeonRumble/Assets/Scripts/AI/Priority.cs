using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Priority : MonoBehaviour
{
    GameObject playerObject;
    GameObject foodObject;
    public Target target;
    public Transform Player;
    public Transform Food;
    string currentState ; // Initial state
    public float wating = 20.0f;
    void Start()
    { //hola
        // empieza la priorizacion

        currentState = "idle";
        playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
        Debug.Log(playerObject);
        foodObject = GameObject.FindGameObjectsWithTag("Food")[0];
        Player = playerObject.GetComponent<Transform>();
        Food = foodObject.GetComponent<Transform>();
        target = GetComponent<Target>();
        StartCoroutine(Prioritize());
    }

    private void Update()
    {
        
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
                    yield return new WaitForSeconds(wating);
                    target.playerTransform = null;
                    break;
            }
        }
    }
}