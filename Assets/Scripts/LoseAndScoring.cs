using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseAndScoring : MonoBehaviour
{
    public static bool LoseChecking(){
        Transform[,] matrix = TargetMovement.matrix;

        for (int width = 0; width < 10; width ++){
            if (matrix[width, 19] != null){
                SceneManager.LoadScene("MainMenu");
                SceneManager.UnloadSceneAsync(1);
                return false;
            }
        }

        return true;
    }
}
