using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {
    public static ScoreScript Instance;
    private int score = 10;
    [SerializeField]
    Text txtScore;
    [SerializeField]
    GameObject gameoverField;
    [SerializeField]
    Controller cont;
    [SerializeField]
    SpawnApples apSp;
    [SerializeField]
    CameraControl camC;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        SetScore(0);
    }

    public void SetScore(int add)
    {
        score += add;
        txtScore.text = string.Format("Score : {0}", score);
        if (score <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameoverField.SetActive(true);
        cont.enabled = false;
        apSp.enabled = false;
        camC.enabled = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Finish()
    {
        Application.Quit();
    }
}
