using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    
    static ScoreCounter _instance;

    public static ScoreCounter Instance { get { return _instance; } }
    public AnimationCurve changeScoreAnim;

    [SerializeField] private float animTime;

    private Text counterText;
    private int count = 0;

    private void Awake()
    {
        _instance = this;
        counterText = GetComponent<Text>();
    }

    public void InitGame()
    {
        count = 0;
        ShowScore();
    }

    public void AddCounter(int coins)
    {
        if (GameManager.Instance.GameState == GameManager.GamesState.Game)
        {
            count+=coins;
            ShowScore();
        }
    }

    void ShowScore()
    {
        counterText.text = count.ToString();
        StartCoroutine(ChangeAnim());
    }

    IEnumerator ChangeAnim()
    {
        for (float f = 0; f < animTime; f += Time.smoothDeltaTime)
        {
            yield return null;
            transform.localScale = Vector3.one * changeScoreAnim.Evaluate(f/animTime);
        }
        yield return null;
        transform.localScale = Vector3.one;
    }
}
