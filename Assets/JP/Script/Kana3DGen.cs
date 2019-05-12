using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kana3DGen : MonoBehaviour {
    [Header("Kana Speed")]
    public bool turnOnA = true;
    public float kanaSpeed = 30f;
    public float maxTime = 2f;

    [Header("Kana")]
    public List<string> listOfWords = new List<string>();
    public string[] A = { "あ", "い", "う", "え", "お" };
    public string[] KA = { "か", "き", "く", "け", "こ" };
    public string[] SA = { "さ", "し", "す", "せ", "そ" };
    public string[] TA = { "た", "ち", "つ", "て", "と" };
    public string[] NA = { "な", "に", "ぬ", "ね", "の" };
    public string[] HA = { "は", "ひ", "ふ", "へ", "ほ" };
    public string[] MA = { "ま", "み", "む", "め", "も" };
    public string[] YA = { "や", "ゆ", "よ" };
    public string[] RA = { "ら", "り", "る", "れ", "ろ" };
    public string[] WA = { "わ", "を", "ん" };

    [Header("Ref")]
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject KanaWordGroup;
    [SerializeField] private GameObject Kana3D;
    private float curTime = 0f;
    private int previousKanaWord = 0;
    private int randomizeKana = 0;
    private int previousKana = 0;

    void Start() {
        curTime = maxTime;
    }
    
    void Update() {
        curTime += Time.deltaTime;

        if (curTime > maxTime) {
            curTime = 0;
            RandomKana();
        }
    }

    public void AddToList(string[] stringArray) {
        for (int i = 0; i < stringArray.Length; i++)
            listOfWords.Add(stringArray[i]);
    }

    public void RemoveFromList(string[] stringArray) {
        for (int i = 0; i < stringArray.Length; i++)
            if (listOfWords.Contains(stringArray[i]))
                listOfWords.Remove(stringArray[i]);
    }

    void RandomKana() {
        randomizeKana = Random.Range(0, 4);

        while (randomizeKana == previousKana)
        {
            randomizeKana = Random.Range(0, 4);
        }
        if (listOfWords.Count > 0)
        {
            GameObject wordObj = Instantiate(Kana3D, spawnPoint[randomizeKana].position, spawnPoint[randomizeKana].rotation, KanaWordGroup.transform);
            Text objText = wordObj.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
            wordObj.GetComponent<Kana3DWord>().objSpeed = kanaSpeed;
            int tempNumber1 = Random.Range(0, listOfWords.Count);
            while (tempNumber1 == previousKanaWord)
            {
                tempNumber1 = Random.Range(0, listOfWords.Count);
            }
            objText.text = listOfWords[tempNumber1];
            wordObj.name = objText.text;
            previousKanaWord = tempNumber1;
        }
        previousKana = randomizeKana;

    }
}
