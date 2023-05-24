using UnityEngine;

public class Points : Pickup
{
    [SerializeField] private int scoreAmount;
    
    protected override void Activate(GameManager gameManager, Player player)
    {
        gameManager.IncreaseScore(scoreAmount);
    }
}