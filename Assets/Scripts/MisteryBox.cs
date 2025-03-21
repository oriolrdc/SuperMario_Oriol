using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    //Animaciones
    private Animator _animator;
    private bool _isOpen = false;
    //Audio
    private AudioSource _audioSource;
    public AudioClip misteryBoxSFX;
    public AudioClip misteryBoxSFXOpened;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivateBox()
    {
        if(!_isOpen)
        {
            
           _audioSource.clip = misteryBoxSFX;
            _animator.SetTrigger("OpenBox"); 
            _isOpen = true;
        }
        else
        {
            _audioSource.clip = misteryBoxSFXOpened;
        }
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
