using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Movimiento
    public int direction = 1;
    public float enemySpeed = 5;
    private Rigidbody2D _rigidBody;
    public BoxCollider2D boxCollider;
    //Animacion
    private Animator _animator;
    private AudioSource _audioSource;
    //Audio
    public AudioClip audioClip;
    

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(enemySpeed * direction, _rigidBody.velocity.y);
    }

    public void Death()
    {
        direction = 0;
        _rigidBody.GravityScale = 0;
        _animator.SetTrigger("IsDead");
        boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

        direction *= -1;
    }
}
