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
    [SerializeField] private GameObject yellow5Bonus;
    [SerializeField] private GameObject yellow10Bonus;
    [Header("Green")]
    [SerializeField] private GameObject greenBonus;
    [Header("Red")]
    [SerializeField] private GameObject redBonus;

    private List<Bonus> bonusPool;

    private int currentIndex = 0;

    public void Generate()
    {
        currentIndex++;
        if (currentIndex >= poolLength)
            currentIndex = 0;
        bonusPool[currentIndex].initPos();
    }

    void Start () {
        _instance = this;
        GeneratePool();
        StartCoroutine(Generator());
	}

    void GeneratePool()
    {
        bonusPool = new List<Bonus>();
        for (int i = 0; i < poolLength; i++)
        {
            GameObject pref = Instantiate(GenerateType());
            Bonus bonusBase = new Bonus();
            bonusBase = pref.GetComponent<Bonus>();
            bonusPool.Add(bonusBase);
            pref.SetActive(false);
        }
        Generate();
    }

    GameObject GenerateType()
    {
        float chance = Random.Range(0f, 1f);
        if (chance < generateGreenChance)
        {
            return greenBonus;
        }
        else if (chance < generateGreenChance + generateYellowChance)
        {
            return GenerateYellow();
        }
        else
        {
            return redBonus;
        }
    }

    GameObject GenerateYellow()
    {
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < 0.5f)
        {
            Debug.Log(5);
            return yellow5Bonus;
        }
        else 
        {
            Debug.Log(10);
            return yellow10Bonus;
        }
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
