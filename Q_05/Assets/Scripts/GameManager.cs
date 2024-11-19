using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        if (this.gameObject != null)
        SingletonInit();
        Score = 0.1f;

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
