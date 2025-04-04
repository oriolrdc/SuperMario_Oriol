using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip coinSFX;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _gameManager.AddCoins();
            _audioSource.PlayOneShot(coinSFX);
            _spriteRenderer.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
