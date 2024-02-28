using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int matched_cards = 0;
    public int reversed_cards = 0;

    public List<Clickable> reversed_not_matched_cards = new List<Clickable>();

}