using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]public InputField inputField;
    [SerializeField]public Text highScoreText;

    // Update is called once per frame
    private void Awake()
    {
        highScoreText.text = "Highscore: " + GameManager.instance.highScoreName + " :" + GameManager.instance.highScore;
    }

    public void StartGame()
    {
        GameManager.instance.currentName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
        GameManager.instance.SaveHighScore();
    }
}
