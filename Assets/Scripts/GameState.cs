using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected Transform memo_cards_field;
    [SerializeField] protected int Reversed_win_amount => memo_cards_field.childCount;
    [SerializeField] protected you_won youWonScript;
    
    public int matched_cards = 0;
    protected int _reversed_cards = 0;
    
    public int reversed_cards {
        get {return _reversed_cards; } 
        set {_reversed_cards = value;
            if (Reversed_win_amount == _reversed_cards){
                youWonScript.RunWon();
        } }
    }

    public List<Clickable> reversed_not_matched_cards = new List<Clickable>();

}