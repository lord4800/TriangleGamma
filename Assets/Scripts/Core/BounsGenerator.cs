using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsGenerator : MonoBehaviour {
    [SerializeField]
    float bonusTime;
    [SerializeField]
    List<GameObject> posBonusPref = new List<GameObject>();
    [SerializeField]
    List<GameObject> goldBonusPref = new List<GameObject>();
    [SerializeField]
    List<GameObject> badBonusPref = new List<GameObject>();
    [SerializeField]
    GameObject bonusPrefab;
    [SerializeField]
    int poolLength;
    List<PosBonus> bonusPool;

    public Collider2D greenSideCollider;
    public Collider2D redSideCollider;
    public Collider2D yellowSideCollider;

    [Header("Sum of chance should be 1")]
    public float generateGreenChance;
    public float generateRedChance;
    public float generateYellowChance;

    Coroutine GenerateCorot;

    int currentIndex = 0;

	void Start () {
        GeneratePool();
        StartCoroutine(Generator());
	}

    void GeneratePool()
    {
        bonusPool = new List<PosBonus>();
        for (int i = 0; i < poolLength; i++)
        {
            GameObject pref = Instantiate(bonusPrefab);
            PosBonus _bonus = new PosBonus();
            _bonus = pref.GetComponent<PosBonus>();
            _bonus.generator = this;
            bonusPool.Add(_bonus);
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

    public void Generate()
    {
        currentIndex++;
        if (currentIndex >= poolLength)
            currentIndex = 0;
        bonusPool[currentIndex].initPos();
    }

    /*
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Generate();
            //StartCoroutine(Generator());
        }
	}*/
}
