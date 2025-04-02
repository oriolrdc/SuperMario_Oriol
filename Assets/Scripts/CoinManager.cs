using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip coinSFX;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            
            _audioSource.PlayOneShot(coinSFX);
            _spriteRenderer.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void Update()
    {
        
    }



}
