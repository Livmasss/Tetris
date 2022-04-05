using UnityEngine;

public class LineClear : MonoBehaviour
{
    private Transform[,] matrix;
    int clearedLineCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        this.matrix = TargetMovement.matrix;
        clearedLineCount = 0;

        //Check for filling the line
        for (int height = 0; height < 20; height++){
            bool flag = true;

            for (int width = 0; width < 10; width++){
                if (matrix[width, height] == null){
                    flag = false;
                }
            }

            if (flag){
                clearedLineCount += 1;
                ClearTheLine(height);
            }
        }
        if (clearedLineCount > 1){
            LoseAndScoring.score += clearedLineCount * 25;
            Debug.Log(clearedLineCount);
        }
    }

    void ClearTheLine(int height){
        for (int width = 0; width < 10; width ++){
            Destroy(matrix[width, height].gameObject);
            matrix[width, height] = null;
        }
        LoseAndScoring.score += 50;

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
