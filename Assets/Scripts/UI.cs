using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button button;
    private Label label;
    private int score;
    private bool isFirst;
    void Start()
    {
        isFirst = true;
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable() {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        label = rootVisualElement.Q<Label>("Score");
        button = rootVisualElement.Q<Button>("Restart");

        button.RegisterCallback<ClickEvent>(ev => LoadGame());
    }

    private void LoadGame(){
        if (isFirst){
            SceneManager.LoadScene(1);
            SceneManager.UnloadSceneAsync(0);
        }
        else{
            SceneManager.LoadScene(1);
        }
        FindObjectOfType<TetramineSpawn>().StartGame();
        uiDocument.enabled = false;
        isFirst = false;
    }
}