using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    #region StartPlay
    [SerializeField]
    private AnimationCurve clip;
    [SerializeField]
    private float animTime = 0.3f;
    [SerializeField]
    private float swapTimeCode = 0.2f;
    #endregion

    [SerializeField]
    private GameObject triangle;
    [SerializeField]
    private Transform playButton;
    [SerializeField]
    private CanvasGroup canvG;

    Coroutine popCorot = null;
    // Use this for initialization
    void Start()
    {

    }

    public void StartGame()
    {
        Debug.Log("click");
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
            canvG.alpha = 1 - f / animTime;
            yield return null;
        }
        playButton.gameObject.SetActive(false);
        playButton.localScale = Vector3.one;
        canvG.alpha = 0;
        popCorot = null;
        canvG.gameObject.SetActive (false);
    }
    public void SwapEvent()
    {
        triangle.SetActive(true);
    }
}
