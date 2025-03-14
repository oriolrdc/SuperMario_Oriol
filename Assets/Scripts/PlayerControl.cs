using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    public float playerSpeed = 4.5f;
    public int direction = 1;

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
        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), playerSpeed * Time.deltaTime); //para plataformas moviles
    }
}
