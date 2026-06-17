using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public TextMeshProUGUI scoretext;
    public GameObject gameover;
    public GameObject Playbtn;
    public int score;

    private void Awake()
    {
        instance = this;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoretext.text = score.ToString();


        gameover.SetActive(false);
        Playbtn.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipe = FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        for (int i = 0; i < pipe.Length; i++)
        {
            Destroy(pipe[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver()
    {
        Pause();
        gameover.SetActive(true);
        Playbtn.SetActive(true);
    }

    public void IncreasingScore()
    {
        score++;
        scoretext.text = score.ToString();

    }
}
