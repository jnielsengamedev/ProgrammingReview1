using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Freeze : Pickup
{
    private static bool _lock;
    protected override void Activate(GameManager gameManager, Player player)
    {
        if (_lock) return;
        _lock = true;
        MakeInvisible();
        var enemies = GameObject.FindGameObjectsWithTag("Enemy").Select(e => e.GetComponent<Enemy>()).ToArray();
        foreach (var enemy in enemies)
        {
            enemy.CanMove = false;
        }

        StartCoroutine(FreezeCoroutine(enemies));
    }

    private IEnumerator FreezeCoroutine(IEnumerable<Enemy> enemies)
    {
        yield return new WaitForSeconds(3);
        foreach (var enemy in enemies)
        {
            enemy.CanMove = true;
        }

        _lock = false;
        DestroyPickup();
    }
}