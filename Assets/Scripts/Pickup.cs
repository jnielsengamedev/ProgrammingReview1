using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Pickup : MonoBehaviour
{
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected abstract void Activate(GameManager gameManager, Player player);

    protected void DestroyPickup()
    {
        MakeInvisible();
        Destroy(gameObject);
    }

    protected void MakeInvisible()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Activate(_gameManager, other.GetComponent<Player>());
    }
}