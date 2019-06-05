using System.Collections;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    #region StartPlay
    [SerializeField] private AnimationCurve clip;
    [SerializeField] private float animTime = 0.3f;
    [SerializeField] private float swapTimeCode = 0.2f;
    #endregion

    [SerializeField] private GameObject triangle;
    [SerializeField] private Transform playButton;
    [SerializeField] private CanvasGroup buttonsCanvasGroup;

    Coroutine popCorot = null;

    public void CloseMainMenu()
    {
        if (popCorot == null)
            popCorot = StartCoroutine(PopUpAnim());
    }

    private void Start()
    {
        GameManager.Instance.onIntoMainMenuTranzitionEvent += OpenMainMenu;
    }

    private void OpenMainMenu()
    {
        gameObject.SetActive(true);
        if (popCorot == null)
            popCorot = StartCoroutine(PopDownAnim());
    }

    IEnumerator PopUpAnim()
    {
        bool sendMes = false;
        for (float f = 0; f < animTime; f += Time.smoothDeltaTime)
        {
            playButton.localScale = Vector3.one * clip.Evaluate(f / animTime);
            if (!sendMes && f > swapTimeCode)
            {
                sendMes = true;
                SwapEvent();
            }
            buttonsCanvasGroup.alpha = 1 - f / animTime;
            yield return null;
        }
        playButton.gameObject.SetActive(false);
        playButton.localScale = Vector3.one;
        buttonsCanvasGroup.alpha = 0;
        popCorot = null;
        buttonsCanvasGroup.gameObject.SetActive (false);
        GameManager.Instance.GameState = GameManager.GamesState.WaitForEffect;
        ScoreCounter.Instance.InitGame();
    }

    IEnumerator PopDownAnim()
    {
        bool sendMes = false;
        buttonsCanvasGroup.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        for (float f = 0; f < animTime; f += Time.smoothDeltaTime)
        {
            playButton.localScale = Vector3.one * (1 - clip.Evaluate(f / animTime));
            if (!sendMes && f > swapTimeCode)
            {
                sendMes = true;
                SwapEvent();
            }
            buttonsCanvasGroup.alpha = f / animTime;
            yield return null;
        }
        playButton.localScale = Vector3.one;
        buttonsCanvasGroup.alpha = 1;
        popCorot = null;
    }

    public void SwapEvent()
    {
        triangle.SetActive(!triangle.activeInHierarchy);
    }
}
