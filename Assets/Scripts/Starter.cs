using UnityEngine;
using UnityEngine.UIElements;

public class Starter : MonoBehaviour
{
    private UIDocument uiDoc;
    void Start()
    {
        FindObjectOfType<TetramineSpawn>().StartGame();
        uiDoc = FindObjectOfType<UIDocument>();
        uiDoc.enabled = false;
    }

    void Update()
    {
        
    }
}
