using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    //movimiento
    private Rigidbody2D _rigidBody;
    public int direction = 1;
    public float mushroomSpeed = 2;
    public BoxCollider2D boxCollider;
    //audio
    private AudioSource _audioSource;
    public AudioClip deathMushroomSFX;
    //retraso
    public float delay = 2;
    //sprites
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(mushroomSpeed * direction, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 7)
        {
            direction *= -1;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MushroomTaken());
        }
    }

    public IEnumerator MushroomTaken()
    {
        _audioSource.PlayOneShot(deathMushroomSFX);
        _spriteRenderer.enabled = false;
        direction = 0;
        boxCollider.enabled = false;
        _rigidBody.gravityScale = 0;

        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
    
}
