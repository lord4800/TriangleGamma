using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsGenerator : MonoBehaviour {

    static BounsGenerator _instance;

    public static BounsGenerator instance { get { return _instance; } }

    public Collider2D greenSideCollider;
    public Collider2D redSideCollider;
    public Collider2D yellowSideCollider;

    [Header("Sum of chance should be 1")]
    public float generateGreenChance;
    public float generateRedChance;
    public float generateYellowChance;

    [SerializeField] private float bonusTime;
    [SerializeField] private int poolLength;

    [Header("Yellow")]
    [SerializeField] private GameObject yellowBonus;
    [Header("Green")]
    [SerializeField] private GameObject greenBonus;
    [Header("Red")]
    [SerializeField] private GameObject redBonus;

    private List<Bonus> yellowBonusPool = new List<Bonus>();
    private List<Bonus> greenBonusPool = new List<Bonus>();
    private List<Bonus> redBonusPool = new List<Bonus>();

    private int currentIndex = 0;

    public void Generate()
    {
        GenerateBonus();
    }

    void Start () {
        _instance = this;
        GeneratePool(yellowBonusPool,yellowBonus);
        GeneratePool(greenBonusPool, greenBonus);
        GeneratePool(redBonusPool, redBonus);
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
            pref.SetActive(false);
        }
    }

    void GenerateBonus()
    {
        float chance = Random.Range(0f, 1f);
        if (chance < generateGreenChance)
        {
            SetFreeBonus(greenBonusPool);
        }
        else if (chance < generateGreenChance + generateYellowChance)
        {
            SetFreeBonus(yellowBonusPool);
        }
        else
        {
            SetFreeBonus(redBonusPool);
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
