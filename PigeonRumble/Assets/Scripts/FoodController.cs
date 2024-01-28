using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class FoodController : MonoBehaviour
{
    //public ScoreManager scoreManager;
    public GameObject barra;
    public Main_extra main_Extra;
    [SerializeField] AudioClip bite;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip damage;


    public Animator animator;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Food"))
        {
            sfx.clip = bite;
            sfx.Play();
            animator.SetBool("Ate", true);
            StartCoroutine(DestroyObject(other.gameObject));
        }
        else if (other.CompareTag("Enemy"))
        {
            sfx.clip = damage;
            sfx.Play();
        }
    }

    IEnumerator DestroyObject(GameObject esto)
    {
        yield return new WaitForSeconds(0.2f);

        Destroy(esto);
        main_Extra.food += 5;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Ate", false);
    }

    private void Update()
    {
        barra.GetComponent<Image>().fillAmount = Mathf.Lerp(barra.GetComponent<Image>().fillAmount, main_Extra.food / main_Extra.foodGoal, 0.05f);
    }


}