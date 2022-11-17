
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    private void playGame() {
        SceneManager.LoadScene("Game Scene");
    }
 
    private void options() {
        SceneManager.LoadScene("Option");
    }
 
    private void exitGame() {
    Application.Quit();
    }
}