using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager2 : GameManager
{
    int Levels=5;//Всего
    int level=5;//на каком сейчас
    private void Start()
    {
        timerIsRunning = true;
        
        for (int i = 1; i <= 24; i++)
        {
            Sprite sprite = Resources.Load<Sprite>("Images/" + i);
            sprites.Add(sprite);
        }
        TimeRemaining = PlayerPrefs.GetInt("Time",5);
        Levels +=PlayerPrefs.GetInt("Levels1");
        NextLevel(-2);        //-2 - первый ход, не учитывается
    }
    private void NextLevel(int nButton=-1)
    {
        string res;
        if (nButton != -2)//если это не первый ход
        {
            if (nButton == -1){
                res = "Нет ответа";
                wrongaudio.Play();
            }
            else
                if (nButton*3 == (guessPicture + 1) | nButton*3-1 == (guessPicture + 1) | nButton*3-2 == (guessPicture + 1))
            {
                res = "Верно";
                balls++;
                rightaudio.Play();
            }
            else
            {
                res = "Не верно";
                wrongaudio.Play();
            }
                
            Results.Add(level + ". " + res + ":" + $"{(TimeRemaining - timeRemaining):F2}");
        }
        level++;
        if (level > Levels)
        {
            PlayerPrefs.SetInt("Levels2",Levels-PlayerPrefs.GetInt("Levels1"));
            PlayerPrefs.SetInt("balls2",balls);
            PlayerPrefs.SetString("Results2", string.Join("\n", Results));
            SceneManager.LoadScene("Results");
        }
        else
        {
            NLevelText.text = level.ToString();
            timeRemaining = TimeRemaining;
            SetPictures(GetRandomImages(sprites));
        }
    }
   private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                NextLevel();
            }
        }
    }
}