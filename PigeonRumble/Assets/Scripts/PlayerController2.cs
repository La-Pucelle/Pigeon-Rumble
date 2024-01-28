using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController2 : MonoBehaviour
{

    public float MoveSpeed = 0.8f;
    public float MoveMultipler = 1.6f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * MoveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        animator.SetFloat("Speed", Mathf.Abs(verticalInput));




        float horizontalSprintInput = Input.GetAxisRaw("Horizontal") * MoveMultipler * MoveSpeed;
        float verticalSprintInput = Input.GetAxisRaw("Vertical") * MoveMultipler * MoveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalSprintInput));
        animator.SetFloat("Speed", Mathf.Abs(verticalSprintInput));

        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetFloat("Speed", horizontalInput);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetFloat("Speed", -1 * horizontalInput);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, 0, -1 * MoveSpeed * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetFloat("Speed", -1 * verticalInput);
        }
        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetFloat("Speed", verticalInput);
        }

        //Teclas para sprintear

        if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(MoveMultipler * MoveSpeed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetFloat("Speed", horizontalSprintInput);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(-1 * MoveMultipler * MoveSpeed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetFloat("Speed", -1 * horizontalSprintInput);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey("s") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(0, 0, -1 * MoveMultipler * MoveSpeed * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetFloat("Speed", verticalInput);
        }
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.Translate(0, 0, MoveMultipler * MoveSpeed * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetFloat("Speed", -1 * verticalInput);
        }
    }
}
