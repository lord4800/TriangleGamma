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

    public void StartGame()
    {
        if (popCorot == null)
            popCorot = StartCoroutine(PopUpAnim());
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
    }

    public void SwapEvent()
    {
        triangle.SetActive(!triangle.activeInHierarchy);
    }
}
