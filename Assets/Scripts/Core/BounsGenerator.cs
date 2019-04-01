using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsGenerator : MonoBehaviour {
    public Collider2D greenSideCollider;
    public Collider2D redSideCollider;
    public Collider2D yellowSideCollider;

    [Header("Sum of chance should be 1")]
    public float generateGreenChance;
    public float generateRedChance;
    public float generateYellowChance;

    [SerializeField] private float bonusTime;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private int poolLength;

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
        GeneratePool();
        StartCoroutine(Generator());
	}

    void GeneratePool()
    {
        bonusPool = new List<Bonus>();
        for (int i = 0; i < poolLength; i++)
        {
            GameObject pref = Instantiate(bonusPrefab);
            Bonus bonusBase = new Bonus();
            bonusBase = pref.GetComponent<Bonus>();
            bonusBase.generator = this;
            bonusPool.Add(bonusBase);
            pref.SetActive(false);
        }
        Generate();
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
