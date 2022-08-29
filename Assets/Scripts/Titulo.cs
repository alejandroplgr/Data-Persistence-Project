using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Titulo : MonoBehaviour
{

    public string playerName;
    public Button buttonStart;
    public string playerNameScore;
    public int score;
    public TextMeshProUGUI ScoreText;



    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadDatas();

        score = MainManager.Instance.maxScore;

        playerNameScore = MainManager.Instance.playerNameMaxScore;

        if (score == 0)
        {
            playerNameScore = "none";
            score = 0;
        }

        ScoreText.text = "Best Score: " + playerNameScore + " : " + score;




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void InputPlayerName(string Name)
    {
        playerName = Name;
        MainManager.Instance.playerNameActual = playerName;
    }

    public void ActiveButton()
    {
        buttonStart.gameObject.SetActive(true);
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
