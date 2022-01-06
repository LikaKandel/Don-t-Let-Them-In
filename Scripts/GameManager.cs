using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameoverPanel;
    public static bool GameEnded;
    private void Start()
    {
        GameEnded = false;
    }
    private void Update()
    {
        if (GameEnded) return;
        if (PlayerStats.Fishes <= 0 ) EndGame();
    }

    void EndGame()
    {
        GameEnded = true;
        gameoverPanel.SetActive(true);
    }
}
