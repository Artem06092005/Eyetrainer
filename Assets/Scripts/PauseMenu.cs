using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gamePause=false;
    [SerializeField]
    private GameObject pauseGameMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))//при нажатии на esc
        {
            if (gamePause)                  //если пауза , то возобновить
            {
                Resume();
            }
            else                            //паставить на паузу
            {
                Pause();
            }
        }
    }
    private void Resume(){
        pauseGameMenu.SetActive(false);
        Time.timeScale=1f;
        gamePause=false;
    }
    private void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale=0f;
        gamePause=true;
    }
    private void LoadMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
}
