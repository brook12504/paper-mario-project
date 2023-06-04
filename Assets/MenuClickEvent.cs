using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//버튼 클릭 이벤트들

public class MenuClickEvent : MonoBehaviour
{
    string previousScene = "GameTitle";



    public void StartClickEvent() {
        SceneManager.LoadScene("SampleScene");
    }

    public void ScoreClickEvent() {
        SceneManager.LoadScene("ScoreView");
    }

    public void SettingClickEvent() {
        SavePreviousScene();
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BackToLobby() {
        SceneManager.LoadScene("GameTitle");
    }

    private void SavePreviousScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
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
