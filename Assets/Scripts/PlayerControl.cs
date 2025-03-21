using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{

    public int direction = 1;
    private float imputHorizontal;
    public float playerSpeed = 4.5f;
    public float jumpForce = 10;
    private Rigidbody2D rigidBody;
    private GrowndSensor _growndSensor; // _ delante significa que es privada :33
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip jumpSFX;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _growndSensor = GetComponentInChildren<GrowndSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    
    }

    string numeros = ":33";
    
    void Start() // Start is called before the first frame update
    {
        Debug.Log(numeros);
        //transform.position = new Vector3(-93, -3, 0); hace TP a mario :33
    }

    
    void Update() // Update is called once per frame
    {
        imputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && _growndSensor.isGrounded == true)
        {
            Jump(); //Llama la funcion de salto
           
        }

        Movement(); //Llama la funcion que acabamos de crear para el movimiento
        
        _animator.SetBool("IsJumping", !_growndSensor.isGrounded);

        /*if(_growndSensor.isGrounded)
        {
            _animator.SetBool("IsJumping", true);            
        }
        else
        {            
            _animator.SetBool("IsJumping", false);
        }*/

        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + imputHorizontal, transform.position.y), playerSpeed * Time.deltaTime); //para plataformas moviles
    }

    void FixedUpdate() // se llama automaticamente todo el rato las veces por segundo que tenga unity
    {
        rigidBody.velocity = new Vector2(imputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(imputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }

    void Movement() //Funcion creada para poner todo lo relacionado con el movimiento (no se llama automaticamente)
    {
        if(imputHorizontal > 0)
         {
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsRunning", true);   //modifica el IsEunning que es el condicionante de que se active la animacion de correr
        }
        else if(imputHorizontal < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsRunning", true);
        }
        else        //else se ejecuta si ninguna de las de funciones del if o el esle if se cumple
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _audioSource.PlayOneShot(jumpSFX); //play one shot hace que se tire el sonido aunque algo se reproduzca tipo generalmente para ataques, disparos o daños
    }
}
