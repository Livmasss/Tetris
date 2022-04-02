using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClear : MonoBehaviour
{
    private Transform[,] matrix;
    void Start()
    {
        
    }

    void Update()
    {
        this.matrix = TargetMovement.matrix;
        //Check for filling the line
        for (int height = 0; height < 20; height++){
            bool flag = true;

            for (int width = 0; width < 10; width++){
                if (matrix[width, height] == null){
                    flag = false;
                }
            }

            if (flag){
                ClearTheLine(height);
            }
        }
    }

    void ClearTheLine(int height){
        for (int width = 0; width < 10; width ++){
            Destroy(matrix[width, height].gameObject);
            matrix[width, height] = null;
        }

        //Falling not destroyed blocks
        foreach (Transform block in matrix){
            if (block != null){
                int intedX = Mathf.FloorToInt(block.transform.position.x);
                int intedY = Mathf.FloorToInt(block.transform.position.y);
                
                if (intedY != 0){
                    while (matrix[intedX, intedY - 1] == null){
                        matrix[intedX, intedY - 1] = matrix[intedX, intedY];
                        matrix[intedX, intedY - 1].position += new Vector3(0, -1, 0);
                        matrix[intedX, intedY] = null;
                    }
                }
            }
        }
    }
}
