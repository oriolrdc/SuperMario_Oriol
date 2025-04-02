using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banderin : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip banderinSFX;
    private SoundManager _soundManager;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _soundManager.Win();
            _audioSource.PlayOneShot(banderinSFX);
            _boxCollider.enabled = false;
        }
    }
}
