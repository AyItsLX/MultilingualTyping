using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanaGenerator : MonoBehaviour {

    public bool[] hiraganaOption;

    [Header("Game Mode")]
    public bool isHiragana = false;
    public bool isKatakana = false;
    [Header("Kana Speed")]
    public float kanaSpeed = 30f;
    public float maxTime = 0.75f;
    private float curTime = 0f;
    [Header("Reference")]
    public Transform canvasTransform;
    public Toggle hiraganaToggle;
    public Toggle katakanaToggle;
    public Text kanaTextPrefab;
    public string[] A = { "あ", "い", "う", "え", "お"};
    public string[] KA = { "か", "き", "く", "け", "こ" };
    public string[] SA = { "さ", "し", "す", "せ", "そ" };
    public string[] TA = { "た", "ち", "つ", "て", "と" };
    public string[] NA = { "な", "に", "ぬ", "ね", "の" };
    public string[] HA = { "は", "ひ", "ふ", "へ", "ほ" };
    public string[] MA = { "ま", "み", "む", "め", "も" };
    public string[] YA = { "や", "ゆ", "よ" };
    public string[] RA = { "ら", "り", "る", "れ", "ろ" };
    public string[] WA = { "わ", "を", "ん" };


    //public AudioClip[] consonantSounds;
    //public AudioClip[] vowelSounds;

    void Start()
    {
        curTime = maxTime;
    }

    void Update()
    {
        if (isHiragana)
        {
            DestroyConsonant();
        }
        else if (!isHiragana)
        {
            GameObject ConsonantGrp = transform.GetChild(0).gameObject;
            for (int i = 0; i < ConsonantGrp.transform.childCount; i++)
            {
                Destroy(ConsonantGrp.transform.GetChild(i).gameObject);
            }
        }

        if (isKatakana)
        {
            DestroyVowel();
        }
        else
        {
            GameObject VowelGrp = transform.GetChild(1).gameObject;
            for (int i = 0; i < VowelGrp.transform.childCount; i++)
            {
                Destroy(VowelGrp.transform.GetChild(i).gameObject);
            }
        }

        curTime += Time.deltaTime;

        if (curTime > maxTime)
        {
            curTime = 0;
            RandomKana();
        }
    }

    #region RandomKana
    void RandomKana()
    {
        if (isHiragana)
        {
            if (hiraganaOption[0]) {
                Text tempWord = Instantiate(kanaTextPrefab, transform.localPosition, Quaternion.identity, transform.GetChild(0));
                tempWord.transform.position = transform.position + new Vector3(Random.Range(-900, 900), 544, 1);
                tempWord.GetComponent<KanaWord>().objSpeed = kanaSpeed;
                int tempNumber1 = Random.Range(0, A.Length);
                tempWord.text = A[tempNumber1];
                tempWord.name = tempWord.text;
            }
            if (hiraganaOption[1]) {
                Text tempWord = Instantiate(kanaTextPrefab, transform.localPosition, Quaternion.identity, transform.GetChild(0));
                tempWord.transform.position = transform.position + new Vector3(Random.Range(-900, 900), 544, 1);
                tempWord.GetComponent<KanaWord>().objSpeed = kanaSpeed;
                int tempNumber1 = Random.Range(0, KA.Length);
                tempWord.text = KA[tempNumber1];
                tempWord.name = tempWord.text;
            }


            //tempWord.GetComponent<AudioSource>().clip = consonantSounds[tempNumber1];
        }
        if (isKatakana)
        {
            //Text tempWord = Instantiate(hangulTextPrefab, transform.localPosition, Quaternion.identity, transform.GetChild(1));
            //tempWord.transform.position = transform.position + new Vector3(Random.Range(-960, 960), 544, 1);
            //int tempNumber2 = Random.Range(0, hangulVowel.Length);
            //tempWord.GetComponent<HangulWord>().objSpeed = kanaSpeed;
            //tempWord.text = hangulVowel[tempNumber2];
            //tempWord.name = tempWord.text;
            //tempWord.GetComponent<AudioSource>().clip = vowelSounds[tempNumber2];
        }
    }
    #endregion

    #region Toggles
    public void IsHiraganaOn()
    {
        isHiragana = hiraganaToggle.isOn;
    }

    public void IsKatakanaOn()
    {
        isKatakana = katakanaToggle.isOn;
    }
    #endregion

    #region Consonant Input
    void DestroyConsonant()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HiraganaMethod("あ");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            HiraganaMethod("い");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            HiraganaMethod("う");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            HiraganaMethod("え");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            HiraganaMethod("お");
        }
    }

    void HiraganaMethod(string HiraganaWord)
    {
        GameObject temp = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        if (temp == isActiveAndEnabled)
        {
            if (temp.name == HiraganaWord) 
            {
                Destroy(temp.GetComponent<Text>());
                temp.name += "Deleted";
                //temp.GetComponent<AudioSource>().Play();
                //Destroy(temp, 2f);
                Destroy(temp);
            }
        }
    }
    #endregion

    #region Vowel Input
    void DestroyVowel()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            VowelMethod("ㅏ");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            VowelMethod("ㅑ");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            VowelMethod("ㅓ");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            VowelMethod("ㅕ");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            VowelMethod("ㅗ");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            VowelMethod("ㅛ");
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            VowelMethod("ㅜ");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            VowelMethod("ㅠ");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            VowelMethod("ㅡ");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            VowelMethod("ㅣ");
        }
    }

    void VowelMethod(string VowelWord)
    {
        GameObject temp = GameObject.Find(VowelWord);
        if (temp == isActiveAndEnabled)
        {
            Destroy(temp.GetComponent<Text>());
            temp.name += "Deleted";
            temp.GetComponent<AudioSource>().Play();
            Destroy(temp, 2f);
        }
    }
    #endregion
}
