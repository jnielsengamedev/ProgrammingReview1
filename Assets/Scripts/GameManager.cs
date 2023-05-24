using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerLives;
    [SerializeField] private int playerScore;
    [SerializeField] private TextMeshProUGUI playerLivesDisplay;
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;
    [SerializeField] private Player player;
    private bool _playerDead;

    private void Update()
    {
        playerLivesDisplay.text = $"Lives: {playerLives}";
        playerScoreDisplay.text = $"Score: {playerScore}";
    }

    public void SubtractLife()
    {
        if (_playerDead) return;
        _playerDead = true;
        playerLives -= 1;
        player.SubtractLife();
        _playerDead = false;
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }
}