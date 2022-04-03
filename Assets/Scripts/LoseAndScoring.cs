using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoseAndScoring : MonoBehaviour
{
    public static bool LoseChecking(){
        Transform[,] matrix = TargetMovement.matrix;

        for (int width = 0; width < 10; width ++){
            if (matrix[width, 19] != null){
                FindObjectOfType<UIDocument>().enabled = true;
                return false;
            }
        }

        return true;
    }
}
