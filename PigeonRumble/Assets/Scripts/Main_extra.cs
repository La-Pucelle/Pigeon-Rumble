using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Main_extra : MonoBehaviour
{
    public int time_left;
    private float alpha;
    private readonly int time_limit;
    public float food;
    public float foodGoal;
    private bool pause;
    private string current;
    bool fadeout;
    Color colortit;
    Color colorini;
    [SerializeField] AudioClip bgm;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;
    [SerializeField] AudioClip btn;
    [SerializeField] AudioSource sfx;
    [SerializeField] GameObject winover;
    [SerializeField] UnityEngine.UI.Image titulo;
    [SerializeField] UnityEngine.UI.Image botonIni;
    [SerializeField] GameObject loseover;
    [SerializeField] GameObject pauseOver;
    [SerializeField] TMPro.TextMeshProUGUI counter;

    // Start is called before the first frame update
    void Start()
    {
        current = "game";
        Invoke(nameof(ReduceTime), 1f);
        Time.timeScale = 0;
        colortit = titulo.color;
        colorini = botonIni.color;
        alpha = 1f;
    }

    // Update is called once per frame
    void ReduceTime()
    {
        time_left -= 1;
        string seconds = time_left % 60 < 10 ? "0" + (time_left % 60).ToString() : (time_left % 60).ToString();
        counter.text = (Mathf.Floor(time_left/60)).ToString() + ":" + seconds.ToString();
        if(time_left != 0)
        {
            Invoke(nameof(ReduceTime), 1f);
        }
        else 
        {
            if(food >= foodGoal)
            {
                current = "win";
                winover.SetActive(true);
                GetComponent<AudioSource>().clip = win;
                GetComponent<AudioSource>().Play();
            }
            else 
            {
                current = "lose";
                loseover.SetActive(true);
                GetComponent<AudioSource>().clip = lose;
                GetComponent<AudioSource>().Play();
            }
            pause = true;
           
        }
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {

            if (titulo.color.a == 1)
            {
                fadeout = true;
                Time.timeScale = 1;
                GetComponent<AudioSource>().clip = bgm;
                GetComponent<AudioSource>().Play();
            }
            else if (current != "game")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
            else if (pause)
            {
                pause = false;
                pauseOver.SetActive(false);
                GetComponent<AudioSource>().UnPause();
                Time.timeScale = 0;

            }
            else
            {
                pause = true;
                pauseOver.SetActive(true);
                GetComponent<AudioSource>().Pause();
                Time.timeScale = 1;
            }
        }
        if (fadeout)
        {
            alpha -= 0.005f;
            titulo.color = new Color(colortit.r, colortit.g, colortit.b, alpha);
            botonIni.color = new Color(colorini.r, colorini.g, colorini.b, alpha);
            fadeout = alpha == 0 ? false : true;
        }
    }
    public void Empezar()
    {
        fadeout = true;
        Time.timeScale = 1;
        GetComponent<AudioSource>().clip = bgm;
        GetComponent<AudioSource>().Play();
        sfx.GetComponent<AudioSource>().clip = btn;
        sfx.GetComponent<AudioSource>().Play();
    }
    public void Reanudar()
    {
        pause = false;
        pauseOver.SetActive(false);
        Time.timeScale = 1;
        GetComponent<AudioSource>().UnPause();
    }
}
