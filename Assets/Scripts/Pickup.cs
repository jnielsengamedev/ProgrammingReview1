using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Pickup : MonoBehaviour
{
    protected Collider2D Collider;
    protected SpriteRenderer SpriteRenderer;
    private GameManager _gameManager;

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected abstract void Activate(GameManager gameManager, Player player);

    protected void DestroyPickup()
    {
        Collider.enabled = false;
        SpriteRenderer.enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Activate(_gameManager, other.GetComponent<Player>());
    }
}