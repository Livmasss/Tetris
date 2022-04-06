using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public static Label score;
    private Button mainMenu;
    void OnEnable()
    {
        var rootVisualElement = FindObjectOfType<UIDocument>().rootVisualElement;
        score = rootVisualElement.Q<Label>("Score");
        mainMenu = rootVisualElement.Q<Button>("MainMenuButton");

        mainMenu.RegisterCallback<ClickEvent>(ev => ToMainMenu());
    }

    void LateUpdate()
    {
        PlayUI.score.text = LoseAndScoring.score.ToString();
    }

    void ToMainMenu(){
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
