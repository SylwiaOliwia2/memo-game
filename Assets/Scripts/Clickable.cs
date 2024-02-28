using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Clickable : MonoBehaviour, IPointerClickHandler 
{

    public bool isReversed = false;
    public bool isMatched = false;

    public string cardMatchID = "";

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(name + " BEFORE click! Reverse: " + isReversed);
        Debug.Log("Managers state for reversed cards:" + Managers.GameState.reversed_cards);
        // reverse if isReversed = false && liczba zreversowanych, non-matched cards <=2
        isReversed = !isReversed;
        //if (isReversed)
        Managers.GameState.reversed_cards += 1;
        // else
        //     Managers.GameState.reversed_cards -= 1;
        Debug.Log(name + " AFTER click! Reverse: " + isReversed);
        Debug.Log("Managers state for reversed cards:" + Managers.GameState.reversed_cards);

        // if non-matched cards = 2 i 
    }

}
