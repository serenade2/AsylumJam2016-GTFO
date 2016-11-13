using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstLevel = "MainTheHouse";

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // Load first level of the game
    public void LoadStartingLevel()
    {
        SceneManager.LoadScene(firstLevel);
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Shown Credits screen
    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
