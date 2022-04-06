using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseAndScoring : MonoBehaviour
{

    public static int score;
    private float timeMark;

    public static bool LoseChecking(){
        Transform[,] matrix = TargetMovement.matrix;

        for (int width = 0; width < 10; width ++){
            if (matrix[width, 19] != null){
                SceneManager.LoadScene("MainMenu");
                return false;
            }
        }

        return true;
    }

    void Update() {
        if ( Time.time > timeMark + 1.5f){
            score -= 1;
            if (score < 0){
                score = 0;
            }
            timeMark = Time.time;
        }
    }
}
