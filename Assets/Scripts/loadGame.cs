using UnityEngine;
using UnityEngine.SceneManagement;


// wrzuć to od obuektu lub statyczna metoda 
public class loadGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
