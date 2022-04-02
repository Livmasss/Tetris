using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float fallingSpeed;
    private short isFall = 1;
    private float timeMark;
    public Vector3 axisOfRotation;
    private static int hight = 20;
    private static int width = 10;
    public static Transform[,] matrix = new Transform[width, hight];

    void Start()
    {
        fallingSpeed = 1f;

    }

    void Update() 
    {
        float tickTime = 0.3f;
        if (isFall == 1) {
            //Movement
            if (Input.GetKey(KeyCode.DownArrow)){
                tickTime = 0.07f;
            }

            if (Time.time > timeMark + tickTime){
                this.transform.position += new Vector3(0, -1, 0) * fallingSpeed;
                timeMark = Time.time;
                if (!CheckTheBorders()){
                    this.transform.position += new Vector3(0, 1, 0) * fallingSpeed;
                    isFall = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                this.transform.position += new Vector3(-1, 0, 0);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(1, 0, 0);}
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                this.transform.position += new Vector3(1, 0, 0);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(-1, 0, 0);}

            //Rotation  
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                this.transform.transform.RotateAround(transform.TransformPoint(axisOfRotation), new Vector3(0, 0, 1), 90);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(1, 0, 0);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(-2, 0, 0);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(3, 0, 0);
                if (!CheckTheBorders())
                    this.transform.position += new Vector3(-4, 0, 0);
                if (!CheckTheBorders()){
                    this.transform.position  += new Vector3(2, 0, 0);
                    this.transform.RotateAround(transform.TransformPoint(axisOfRotation), new Vector3(0, 0, 1),-90);
                }
                
            }
        }
        else if ( isFall == 0) {
            isFall = 2;
            bool flag = true;

            foreach (Transform child in this.transform){
                int intedX = Mathf.FloorToInt(child.position.x);
                int intedY = Mathf.FloorToInt(child.position.y);
                TargetMovement.matrix[intedX, intedY] = child;
                
                //Lose
                if (intedY == 19){
                    flag = false;
                }
            }
            if (flag){
                FindObjectOfType<TetramineSpawn>().NewTetromino();
            }
        }
    }
    //Border check
    private bool CheckTheBorders(){
        foreach (Transform child in this.transform){
            int intedX = Mathf.FloorToInt(child.position.x);
            int intedY = Mathf.FloorToInt(child.position.y);
            if (intedX >= width || intedX < 0 || intedY < 0)
                return false;
                
            if (matrix[intedX, intedY] != null)
                return false; 
        }
        return true;
    }
}