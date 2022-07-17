using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Player,
    Enemy,
    Map,
    Event,
    Menu
}

public class GameManager : MonoBehaviour
{
    #region Simple Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);
    }

    #endregion

    [SerializeField] GameObject MapPanel;

    GameState currentGameState;

    [HideInInspector]
    public UnityEvent<GameState> OnGameState = new UnityEvent<GameState>();

    public void ChangeGameState(GameState state)
    {
        currentGameState = state;
        OnGameState?.Invoke(state);

        switch (currentGameState)
        {
            case GameState.Player:
                //Popup UI
                break;
            case GameState.Enemy:
                //Let enemy attack
                break;
            case GameState.Map:
                //Pullup Map
                Invoke(nameof(OpenMap), 3f);
                break;
            case GameState.Event:
                //Pull up Event
                break;
            case GameState.Menu:
                //Pull up Menu
                break;
        }
    }

    void OpenMap()
    {
        MapPanel.SetActive(true);
    }
}
