using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public static string Username;
    public TextMeshProUGUI bestScoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            return;
        }
    }

    void Start()
    {
        dynamic[] lastScore = SaveManager.LoadScore();
        bestScoreText.text = $"Best Score: {lastScore[0]}: {lastScore[1]}";
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SaveName(string name)
    {
        Username = name;
    }
}
