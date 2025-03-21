using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    //Animaciones
    private Animator _animator;
    //Audio
    private AudioSource _audioSource;
    public AudioClip _MisteryBoxSFX;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivateBox()
    {
        _audioSource.clip = _MisteryBoxSFX;
        _animator.SetTrigger("OpenBox");
        _audioSource.Play();
    } 

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")) //lo de despues de game object es lo mismo que poner .tag == "Player" :33
        {
            ActivateBox();
        }
    }
}
