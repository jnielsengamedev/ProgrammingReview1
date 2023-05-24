using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private GameManager _gameManager;
    internal bool CanKill = true;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        LookAt(_player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Time.deltaTime);
    }

    private void LookAt(Vector3 positionToLookAt)
    {
        var diff = positionToLookAt - transform.position;
        diff.Normalize();
        var rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotationZ + 90);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!CanKill) return;
        if (!other.collider.CompareTag("Player")) return;
        _gameManager.SubtractLife();
    }
}
