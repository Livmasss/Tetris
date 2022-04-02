using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetramineSpawn : MonoBehaviour
{

    public GameObject []Tetromines = new GameObject[7];

    void Start()
    {
        NewTetromino();
    }

    void Update()
    {
        
    }

    public void NewTetromino(){
        Instantiate(Tetromines[Random.Range(0, 7)], transform.position, transform.rotation);
    }
}
