using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClickEvent : MonoBehaviour
{
    public void SettingClickEvent() {
        SceneManager.LoadScene("Setting");
    }

    public void ScoreClickEvent() {
        SceneManager.LoadScene("ScoreView");
    }

    public void BackToLobby() {
        SceneManager.LoadScene("GameTitle");
    }

    public void StartClickEvent() {
        SceneManager.LoadScene("GameStage");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
