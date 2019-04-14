using UnityEngine;

public class GameScreen : MonoBehaviour {

    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject mainMenuButton;

    void Start()
    {
        GameManager.instance.onIntoGameTranzitionEvent += ToGameTranzition;
        GameManager.instance.onIntoMainMenuTranzitionEvent += ToMainMenuTranzition;
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
    }

    public void BackToMenuClick()
    {
        GameManager.instance.GameState = GameManager.GamesState.Menu;
    }
}
