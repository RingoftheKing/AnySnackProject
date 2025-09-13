using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public static void onClickLoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
