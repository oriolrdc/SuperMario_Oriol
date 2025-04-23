using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    // Variables = Cajitas
    public int numerosEnteros = 5; //Variable numeros enteros
    //private float numeroDecimal = 7.5f; //Variable numeros decimales
    //bool boleana = true; //Variable verdadero o falso
    //string cadenaTexto = "Hola desimaru"; //Variable que escribe

    private int[] numeros = {75, 1, 3}; //para diferenciar un array de una variable normal se pone los [] y nos permite guardar varias "cajitas" o elementos

    public int[] numeros2; //si lo haces publico puedes verlo en el inspector y asi asignar los valores ahi asi como el tamaño

    private int[ , ] numeros3 = {{7, 8, 98},{9, 22, 45}}; //al poner una coma en medio hace un array de 2 dimensiones o mas (poco probable a ser usado, un saludo) [cada uno de estos {} es una dimension]

    List<int> listaDeNumeros = new List<int> {3, 5, 8, 9, 88, 12}; //lista de datos que puede ser modificada como la lista de la compra o algo asi

    void Start()
    {
        foreach(int numero in listaDeNumeros)
        {
            Debug.Log(numero);
        }

        listaDeNumeros.Add(22); //añade lo que le digas a la lista
        listaDeNumeros.Remove(5); //elimina de la lista lo que le digas empezando por delante (izquierda)
        listaDeNumeros.RemoveAt(0); //elimina un elemento de la lista lo que este en la posicion que digas
        //listaDeNumeros.RemoveAt(listaDeNumeros.Count - 1); //le reta 1 al tamaño total de la lista
        listaDeNumeros.Sort(); //ordena la lista de mas pequeño a mas grande
        listaDeNumeros.Reverse(); //revierte el orden de la lista

        foreach(int numero in listaDeNumeros)
        {
            Debug.Log(numero);
        }

        //listaDeNumeros.Clear(); //limpia la lista y borra todos los datos que hay

        //Debug.Log(numeros[0]); //asi hacemos un print de la "cajita" o elemento numero 0 es decir el primero
        //Debug.Log(numeros3[1, 2]); //asi accedes a los numeros de las 2 dimensiones (primero dices la columna y luego dices el numero[se empieza por el 0 a contar importante])
        //Calculos();

        //por cada elemento en el array se hace algo, se repite el mismo numero de veces que casillas en el array
        /*foreach(int numero in numeros) // int numero in numero comprueba todos los numeros en el array numeros y hace algo por cada uno de ellos con la variable temporal "numero" que ira cambiando
        {
            Debug.Log(numero); //print del numero y tal sabes neno?
        }*/

        //      1        2     3
        /*for(int i = 0; i < numeros.Length; i++) //lo primero es variable de control, lo segundo es la condicion necesaria para que se siga repitiendo, y el ultimo suma 1 a i
        {
            Debug.Log(numeros[i]);
        }*/

        /*int i = 0;
        while(i < numeros.Length) //bucle while se usa para cosas concretas y este ejemplo hace lo mismo que el for asi que sin mas
        {
            Debug.Log(numeros[i]);
            i++;
        }*/

        /*int i = 75;
        do  //el bucle do while se ejecuta si o si minimo una vez, pq la condicion esta al final asi que el orden no lo permite
        {
            Debug.Log("asdasd")
        }
        while (i < numeros.Length);*/
    }

    void Update()
    {

    }

    /*void Calculos()
    {
        Debug.Log(numerosEnteros);
        
        numerosEnteros = 17;
        Debug.Log(numerosEnteros);

        numerosEnteros = 7 + 5;
        Debug.Log(numerosEnteros);

        numerosEnteros++;
        Debug.Log(numerosEnteros);

        numerosEnteros += 2;
        Debug.Log(numerosEnteros);
    }*/
}
