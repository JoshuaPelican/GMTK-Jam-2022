using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Player,
    Enemy,
    Map,
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

    [SerializeField] Enemy[] enemiesInOrder;
    int currentEnemy = -1;

    [SerializeField] GameObject MapPanel;
    [SerializeField] Transform XContainer;

    [SerializeField] GameObject MenuPanel;

    [SerializeField] GameObject AttackButton;

    GameState currentGameState = GameState.Menu;

    [HideInInspector]
    public UnityEvent<GameState> OnGameState = new UnityEvent<GameState>();

    public void StartGame()
    {
        ChangeGameState(GameState.Map);
    }

    public void ChangeGameState(GameState state)
    {
        currentGameState = state;
        OnGameState?.Invoke(state);

        switch (currentGameState)
        {
            case GameState.Player:
                //Popup UI
                AttackButton.SetActive(true);
                break;
            case GameState.Enemy:
                //Let enemy attack
                break;
            case GameState.Map:
                //Pullup Map
                currentEnemy++;
                Invoke(nameof(OpenMap), 3f);
                Invoke(nameof(CloseMap), 6f);
                break;
            case GameState.Menu:
                //Pull up Menu
                MenuPanel.SetActive(true);
                break;
        }
    }

    void OpenMap()
    {
        MapPanel.SetActive(true);
        for (int i = 0; i < currentEnemy; i++)
        {
            XContainer.GetChild(0).gameObject.SetActive(true);
        }
    }

    void CloseMap()
    {
        MapPanel.SetActive(false);
        ChangeGameState(GameState.Player);
        SpawnEnemy(enemiesInOrder[currentEnemy]);
    }

    public void SpawnEnemy(Enemy enemy)
    {
        EnemyBase enemyBase = GameObject.FindWithTag("EnemyBase").GetComponent<EnemyBase>();
        enemyBase.Enemy = enemy;
        enemyBase.Initialize();

        FindObjectOfType<Player>().EquippedWeapon.NumberOfDice++;
    }
}
