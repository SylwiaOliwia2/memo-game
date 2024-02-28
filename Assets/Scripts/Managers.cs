using UnityEngine;

public class Managers: FindInstanceSingleton<Managers>
{

    [SerializeField] protected GameState gameState;
    public static GameState GameState => Instance.gameState; // tu wołamy instancję singletona - ma do tego dostęp bo dziedziczymy po FindInstanceSingleton 

}

// TAK SIĘ TO WOŁA:
// Managers.GameState.reversed_cards += 1;