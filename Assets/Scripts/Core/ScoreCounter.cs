using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    private const float TIME_BEFORE_START = 1.5f;
    static ScoreCounter _instance;

    public static ScoreCounter instance { get { return _instance; } }
    public AnimationCurve changeScoreAnim;

    [SerializeField] private float animTime;

    private Text counterText;
    private int count = 0;
    private float timer;


    void Start ()
    {
        _instance = this;
        counterText = GetComponent<Text>();
        InitGame();
    }

    public void InitGame()
    {
        count = 0;
        ShowScore();
        timer = 0;
    }

    public void AddCounter()
    {
        if (timer > TIME_BEFORE_START && GameManager.instance.GameState == GameManager.GamesState.Game)
        {
            count++;
            ShowScore();
        }
    }

    public void NegCounter()
    {
        if (timer > TIME_BEFORE_START && GameManager.instance.GameState == GameManager.GamesState.Game)
        {
            count--;
            ShowScore();
        }
    }

    void ShowScore()
    {
        counterText.text = count.ToString();
        StartCoroutine(ChangeAnim());
    }

    void Update()
    {
        timer += Time.deltaTime;
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
