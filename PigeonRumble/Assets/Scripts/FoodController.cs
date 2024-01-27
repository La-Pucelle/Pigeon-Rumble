using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController: MonoBehaviour
{
    void onTriggerEnter(Collider other)
    {
            Debug.Log("Se tocaron" + other);

    }
}


