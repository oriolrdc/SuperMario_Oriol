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
    private GrowndSensor _growndSensor; //barrabaja delante significa que es privada :33

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _growndSensor = GetComponentInChildren<GrowndSensor>();
    }

    string miCama = "itsu me Mario Botha :33";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(miCama);
        //transform.position = new Vector3(-93, -3, 0); hace TP a mario :33
    }

    // Update is called once per frame
    void Update()
    {
        imputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && _growndSensor.isGrounded == true)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + imputHorizontal, transform.position.y), playerSpeed * Time.deltaTime); //para plataformas moviles

    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(imputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(imputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }
}
