using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject startMenu;
    public GameObject hallway;
    
    public void StartGame()
    {
       startMenu.SetActive(false);
       gameObject.SetActive(false);
       hallway.SetActive(true);
    }

    public void OpenControls()
    {
        startMenu.SetActive(!startMenu.activeSelf);
        controlMenu.SetActive(!controlMenu.activeSelf);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
