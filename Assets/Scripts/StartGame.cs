using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LoadGameScene();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
