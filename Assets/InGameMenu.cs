using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] string gameScene = "game";
    [SerializeField] string menuScene = "menu";

    public void TryAgain()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
