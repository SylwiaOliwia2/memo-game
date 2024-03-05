using UnityEngine;
using UnityEngine.UI;

public class you_won : MonoBehaviour
{
    [SerializeField] protected Transform playArea;
    [SerializeField] protected Canvas canvas;
    public void RunWon(){
        canvas.enabled = true;
        //playArea.gameObject.SetActive(false);
    }
}
