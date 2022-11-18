using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score: {DataManager.Instance.BestUserName}: {DataManager.Instance.BestScore}";
    }

    public void StartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnNameChange(string name)
    {
        DataManager.Instance.UserName = name;
    }
}
