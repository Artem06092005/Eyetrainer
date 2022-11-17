using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    protected AudioSource rightaudio;
    [SerializeField]
    protected AudioSource wrongaudio;
    [SerializeField]
    protected Text TimeText;
    [SerializeField]
    protected Text NLevelText;
    
    protected List<Sprite> sprites = new List<Sprite>();
    protected List<string> Results = new List<string>();

    protected float TimeRemaining;//первоначальное время
    protected float timeRemaining ;//текущее время

    protected bool timerIsRunning = false;


    protected int guessPicture;
    protected int balls = 0;

    private int level=0;//на каком сейчас
    private int Levels;//Всего

    private void Start()
    {
        timerIsRunning = true;
        
        for (int i = 1; i <= 24; i++)
        {
            Sprite sprite = Resources.Load<Sprite>("Images/" + i);
            sprites.Add(sprite);
        }
        TimeRemaining = PlayerPrefs.GetInt("Time",5);
        Levels = PlayerPrefs.GetInt("Levels", 5);
        NextLevel(-2);        //-2 - первый ход, не учитывается
    }
    private void NextLevel(int nButton=-1)
    {
        string res;
        if (nButton != -2)//если это не первый ход
        {
            if (nButton == -1)
            {
                res = "Нет ответа";
                wrongaudio.Play();
            }
            else
                if (nButton == guessPicture + 1)
            {
                rightaudio.Play();
                res = "Верно";
                balls++;
            }
            else
            {
                wrongaudio.Play();
                res = "Не верно";
            }
            Results.Add(level + ". " + res + ":" + $"{(TimeRemaining - timeRemaining):F2}");
        }
        level++;
        if (level > Levels)
        {
            PlayerPrefs.SetInt("Levels1",Levels);
            PlayerPrefs.SetInt("balls1",balls);
            PlayerPrefs.SetString("Results1", string.Join("\n", Results));
            SceneManager.LoadScene("Game Scene 2");
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
    protected void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //0 спрайт помещаем в центр
    protected List<Sprite> GetRandomImages(List<Sprite> spritesList, int count = 24)
    {
        int n;
        List<Sprite> randomSprites = new List<Sprite>();
        for (int i = 0; i < count; i++)
        {
            n = Random.Range(0, spritesList.Count);
            randomSprites.Add(spritesList[n]);
            spritesList.RemoveAt(n);//Удаляем, чтобы не было повторов
        }
        foreach (var sprite in randomSprites)
            spritesList.Add(sprite);//возвращаем удаленные спрайты назад
        return randomSprites;
    }

    protected void SetPictures(List<Sprite> sprites)
    {
        GameObject image;
        for (int i = 0; i <= 23; i++)
        {
            image = GameObject.Find("Image" + (i + 1));
            
            image.GetComponent<Image>().sprite = sprites[i];
        }
        //Переставляем первый спрайт в случайную позицию
        guessPicture = Random.Range(0, sprites.Count);
        image = GameObject.Find("Image0");
        image.GetComponent<Image>().sprite = sprites[guessPicture];
    }
}