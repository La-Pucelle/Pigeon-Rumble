using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choques : MonoBehaviour
{
    bool stunned = false;
    int foodcount = 0;
    void Stun()
    {
        stunned = false;
    }
 
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy") && !stunned)
        {
            stunned = true;
            foodcount -= 10;
            Invoke(nameof(Stun), 3f);
        }
    }
}
