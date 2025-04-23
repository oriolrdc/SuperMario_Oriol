using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawn Enemigos")] //modifica como se ve la varible en el inspector??

    [Tooltip("Prefabs de enemigos")] //se ve la descripcion si en el inspector dejas el raton en la variable
    [SerializeField] private GameObject[] _enemiesPrefab; //el serialize field te deja ver variables privadas en el inspector

    [Tooltip("Numero de enemigos que van a spawnear")] //se ve la descripcion si en el inspector dejas el raton en la variable
    [SerializeField] private int _enemiesToSpawn; //el serialize field te deja ver variables privadas en el inspector

    [Tooltip("punto de donde aparecen los enemigos")]
    [SerializeField] private Transform[] _spawnPoint;

    private int _enemyIndex;

    private BoxCollider2D _collider;


    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(_enemiesToSpawn <= 0)
        {
            CancelInvoke(); //Cancela todos los invokes que hay en el script y tal
        }
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            foreach(Transform spawn in _spawnPoint)
            {
                _enemyIndex = Random.Range(0, _enemiesPrefab.Length);
                Instantiate(_enemiesPrefab[_enemyIndex], spawn.position, spawn.rotation);

                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(1);
        }
        //esto pilla un int random entre 0 y 1 pq el 2 por alguna razon lo excluyen (debe ser peruano ns) con _enemylength se aregla
        
        //Instantiate(_enemiesPrefab[_enemyIndex], _spawnPoint.position, _spawnPoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")); //si el if detecta que mario a tocado el trigger llama la funcion spawnenemy durante todo el rato con el invoke repeating
        {
            _collider.enabled = false;
            StartCoroutine(SpawnEnemy());
            //InvokeRepeating("SpawnEnemy", 0, 2); //primer valor lo que tarda en ejecutarlo, segundo cada cuanto lo hace
        }
    }


}
