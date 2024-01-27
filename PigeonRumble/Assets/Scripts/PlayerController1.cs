using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{

    public float MoveSpeed = 0.8f;
    public float MoveMultipler = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, 0, -1 * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }

        //Teclas para sprintear

        if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(MoveMultipler * MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(-1 * MoveMultipler * MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(0, 0, -1 * MoveMultipler * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(0, 0, MoveMultipler * MoveSpeed * Time.deltaTime);
        }
    }
}
