using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
    //used on every menu
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Escape)) //if the player presses escape
        {
            Application.Quit(); //close the game
        }
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CatTestingScene2");
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
