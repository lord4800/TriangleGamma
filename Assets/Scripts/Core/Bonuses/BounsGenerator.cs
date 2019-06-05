using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsGenerator : MonoBehaviour {

    static BounsGenerator _instance;

    public static BounsGenerator Instance { get { return _instance; } }

    public Collider2D greenSideCollider;
    public Collider2D redSideCollider;
    public Collider2D yellowSideCollider;

    [Header("Sum of chance should be 1")]
    public float generateEffectChance;
    public float generateYellowChance;

    [SerializeField] private float bonusTime;
    [SerializeField] private int poolLength;

    [Header("Bonuses")]
    [SerializeField] private GameObject yellowBonus;
    [SerializeField] private GameObject effectBonus;

    private List<Bonus> yellowPool = new List<Bonus>();
    private List<Bonus> effectPool = new List<Bonus>();

    private int currentIndex = 0;

    public void Generate()
    {
        if (GameManager.Instance.GameState != GameManager.GamesState.GameOver)
            GenerateBonus();
    }

    void Start () {
        _instance = this;
        GeneratePool(yellowPool,yellowBonus);
        GeneratePool(effectPool, effectBonus);
        StartCoroutine(Generator());
	}

    void GeneratePool(List<Bonus> bonusPool, GameObject prefab)
    {
        for (int i = 0; i < poolLength; i++)
        {
            GameObject pref = Instantiate(prefab);
            Bonus bonusBase = new Bonus();
            bonusBase = pref.GetComponent<Bonus>();
            bonusPool.Add(bonusBase);
            bonusBase.OnDeath += LifeManager.Instance.Death;
            pref.SetActive(false);
        }
    }

    void GenerateBonus()
    {
        float chance = Random.Range(0f, 1f);
        if (chance < generateEffectChance)
        {
            SetFreeBonus(effectPool);
        }
        else
        {
            SetFreeBonus(yellowPool);
        }
    }

    public void SetFreeBonus(List<Bonus> bonusPool)
    {
        currentIndex++;
        if (currentIndex >= poolLength)
            currentIndex = 0;
        bonusPool[currentIndex].initPos();
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(bonusTime);
            Generate();
        }
    }
}
