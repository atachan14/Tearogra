using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("FloorScene");
    }
}
