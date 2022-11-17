using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    [SerializeField]
    private Text ResultsText;
    [SerializeField]
    private Text text;
    [SerializeField]
    private AudioSource won;
    [SerializeField]
    private AudioSource loss;

    private void Start()
    {
    
        int Levels=PlayerPrefs.GetInt("Levels1")+PlayerPrefs.GetInt("Levels2");
        int balls=PlayerPrefs.GetInt("balls1")+PlayerPrefs.GetInt("balls2");
        ResultsText.text=PlayerPrefs.GetString("Results1")+"\n"+PlayerPrefs.GetString("Results2")+"\n"/*+Status(balls,Levels)*/;
        text.text=Status(balls,Levels);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }


    private string Status(int balls,int Levels)//болен или здоров
    {
        if(balls >= Levels*90/100)
        {
            won.Play();
           return "Тест пройден";
        }
        else
        {
            loss.Play();
            return "Тест не пройден";
        }

    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
