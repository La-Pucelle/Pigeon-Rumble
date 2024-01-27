using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_extra : MonoBehaviour
{
    public int time_left;
    private readonly int time_limit;
    private readonly int food;
    private readonly int foodGoal;
    private bool pause;
    private string current;
    [SerializeField] GameObject winover;
    [SerializeField] GameObject loseover;
    [SerializeField] GameObject pauseOver;
    [SerializeField] TMPro.TextMeshProUGUI counter;

    // Start is called before the first frame update
    void Start()
    {
        current = "game";
        Invoke(nameof(ReduceTime), 1f);
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
            }
            else 
            {
                current = "lose";
                loseover.SetActive(false);
            }
            pause = true;
           
        }
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            if(current != "game")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
            else
            {
                pause = !pause;
                pauseOver.SetActive(pause);
                Time.timeScale = pause? 0:1;
            }
        }
    }
}
