using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Sprite aliveSprite;
    [SerializeField] private Sprite deadSprite;

    private float _verticalInput;
    private float _horizontalInput;
    private GameManager _gameManager;
    private bool _canMove = true;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    internal bool IsPowered;

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        Movement();
    }

    private void Movement()
    {
        if (!_canMove) return;
        transform.Translate(Vector3.up * (moveSpeed * _verticalInput * Time.deltaTime));
        transform.Translate(Vector3.right * (moveSpeed * _horizontalInput * Time.deltaTime));
    }

    internal void SubtractLife()
    {
        _canMove = false;
        _rigidbody.isKinematic = true;
        StartCoroutine(SubtractLifeCoroutine());
    }

    private IEnumerator SubtractLifeCoroutine()
    {
        _spriteRenderer.sprite = deadSprite;
        yield return new WaitForSeconds(3);
        _spriteRenderer.sprite = aliveSprite;
        transform.position = GetRandomPosition();
        _canMove = true;
        _rigidbody.isKinematic = false;
    }

    private static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-8,8), Random.Range(-5,5), 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!IsPowered) return;
        if (!other.collider.CompareTag("Enemy")) return;
        Destroy(other.gameObject);
    }
}