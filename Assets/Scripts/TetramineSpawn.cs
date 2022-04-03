using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetramineSpawn : MonoBehaviour
{

    public GameObject [] tetrominos = new GameObject[7];
    public GameObject[] sprites = new GameObject[7];
    private int nextShape;

    public void StartGame()
    {
        nextShape = Random.Range(0, 7);
        sprites[nextShape].transform.SetPositionAndRotation(new Vector3(-6.5f, 26.5f, -0.5f), this.transform.rotation);
        NewTetromino();
    }

    void Update()
    {
        
    }

    public void NewTetromino(){
        Instantiate(tetrominos[nextShape], transform.position, transform.rotation);
        sprites[nextShape].transform.SetPositionAndRotation(new Vector3(-600.5f, 26.5f, -0.5f), this.transform.rotation);
        nextShape = Random.Range(0, 7);
        sprites[nextShape].transform.SetPositionAndRotation(new Vector3(-5.5f, 15.5f, -0.5f), this.transform.rotation);
    }
}