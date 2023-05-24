using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Power : Pickup
{
    [SerializeField] private Sprite rabbitSprite;
    [SerializeField] private Sprite madRabbitSprite;
    private Sprite _previousSprite;

    protected override void Activate(GameManager gameManager, Player player)
    {
        if (player.IsPowered) return;
        player.IsPowered = true;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy").Select(e => e.GetComponent<Enemy>()).ToArray();
        foreach (var enemy in enemies)
        {
            enemy.CanKill = false;
        }

        SpriteRenderer.enabled = false;
        Collider.enabled = false;
        StartCoroutine(PoweredUpCoroutine(player, player.GetComponent<SpriteRenderer>(), enemies));
    }

    private IEnumerator PoweredUpCoroutine(Player player, SpriteRenderer renderer, IEnumerable<Enemy> enemies)
    {
        renderer.sprite = madRabbitSprite;
        yield return new WaitForSeconds(5);
        renderer.sprite = rabbitSprite;
        player.IsPowered = false;
        foreach (var enemy in enemies)
        {
            enemy.CanKill = true;
        }

        DestroyPickup();
    }
}