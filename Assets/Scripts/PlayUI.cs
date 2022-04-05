using UnityEngine.UIElements;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    public static Label score;
    void OnEnable()
    {
        var rootVisualElement = FindObjectOfType<UIDocument>().rootVisualElement;
        score = rootVisualElement.Q<Label>("Score");
    }

    void LateUpdate()
    {
        PlayUI.score.text = LoseAndScoring.score.ToString();
    }
}
