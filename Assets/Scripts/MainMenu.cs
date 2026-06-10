using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainScene;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.StartTitleMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit the game");
    }
}
