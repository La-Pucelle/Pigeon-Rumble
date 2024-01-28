using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se tocaron" + other);
        StartCoroutine(DestroyObject(other.gameObject));
    }
    IEnumerator DestroyObject(GameObject esto)
    {
        yield return new WaitForSeconds(1.0f);
        //Destroy(esto);
    }
}


