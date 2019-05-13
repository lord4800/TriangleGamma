using UnityEngine;

public class GameScreen : MonoBehaviour {

    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject gameOver;

    void Start()
    {
        GameManager.Instance.onIntoWaitForGameTranzitionEvent += ToGameTranzition;
        GameManager.Instance.onIntoMainMenuTranzitionEvent += ToMainMenuTranzition;
        GameManager.Instance.onIntoGameOverTranzitionEvent += GameOverEvent;
    }

    private void ToGameTranzition()
    {
        counter.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    private void ToMainMenuTranzition()
    {
        counter.SetActive(false);
        mainMenuButton.SetActive(false);
        gameOver.SetActive(false);
    }

    private void GameOverEvent()
    {
        gameOver.SetActive(true);
        //Pop up animation
    }

    public void BackToMenuClick()
    {
        GameManager.Instance.GameState = GameManager.GamesState.Menu;
    }
}
