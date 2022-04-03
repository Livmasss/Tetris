using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private Button button;
    private Label label;
    private int score;
    private bool isFirst;
    void Start()
    {
    }

    private void OnEnable() {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        label = rootVisualElement.Q<Label>("Score");
        button = rootVisualElement.Q<Button>("Restart");

        button.RegisterCallback<ClickEvent>(ev => LoadGame());
        Debug.Log(1);
    }

    private void LoadGame(){
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0); 
    }
}