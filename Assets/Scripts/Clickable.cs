using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

public class Clickable : MonoBehaviour, IPointerClickHandler 
{

    public bool isReversed = false;
    public bool isMatched = false;

    [SerializeField] public string cardImage = "";


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!isReversed)
        {
            // revrese card and update game state
            if (Managers.GameState.reversed_not_matched_cards.Count <2)
            {
                isReversed = !isReversed;
                Managers.GameState.reversed_cards += 1;
                Managers.GameState.reversed_not_matched_cards.Add(this);
                Debug.Log(name + " reversed: " + isReversed);
                Debug.Log("Managers state for reversed cards:" + Managers.GameState.reversed_cards);
            }

            // deal with cards if 2 are revresed
            if (Managers.GameState.reversed_not_matched_cards.Count == 2)
            {
                Clickable card_reveresed_1 = Managers.GameState.reversed_not_matched_cards[0];
                Clickable card_reveresed_2 = Managers.GameState.reversed_not_matched_cards[1];
                if (card_reveresed_1.cardImage == card_reveresed_2.cardImage)
                {
                    card_reveresed_1.isMatched = true;
                    card_reveresed_2.isMatched = true;
                    Managers.GameState.matched_cards += 2;
                    Managers.GameState.reversed_not_matched_cards.Clear();
                    Debug.Log("Managers state for reversed cards:" + Managers.GameState.reversed_cards);
                    Debug.Log("Managers state for reversed cards:" + Managers.GameState.matched_cards);
                }
                else {
                    // # wait 3 sec and revert to the previous state
                    DOTween.Sequence().AppendInterval(2.5f).OnComplete(
                        ()=>{
                            Managers.GameState.reversed_not_matched_cards.Clear();
                            Managers.GameState.reversed_cards -= 2;
                            card_reveresed_1.isReversed = false;
                            card_reveresed_2.isReversed = false;
                            Debug.Log("Managers state for reversed cards:" + Managers.GameState.reversed_cards);
                            Debug.Log("Managers state for reversed cards:" + Managers.GameState.matched_cards);
                        }
                    );
                }
            }
        }
    }
}
