using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangulGenerator : MonoBehaviour {

    [Header("Game Mode")]
    public bool isConsonant = false;
    public bool isVowel = false;
    [Header("HangulSpeed")]
    public float hangulSpeed = 1f;
    public float maxTime = 2f;
    private float curTime = 0f;
    [Header("Reference")]
    public Toggle ConsonantToggle;
    public Toggle VowelToggle;
    public GameObject CanvasObj;
    public Text hangulTextPrefab;
    public string[] hangulConsonant = { "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
    public AudioClip[] consonantSounds;
    public string[] hangulVowel = { "ㅏ", "ㅑ", "ㅓ", "ㅕ", "ㅗ", "ㅛ", "ㅜ", "ㅠ", "ㅡ", "ㅣ" };
    public AudioClip[] vowelSounds;

    void Start()
    {
        curTime = maxTime;
    }
	
	void Update ()
    {
        if (isConsonant)
        {
            DestroyConsonant();
        }
        else if (!isConsonant)
        {
            GameObject ConsonantGrp = transform.GetChild(0).gameObject;
            for (int i = 0; i < ConsonantGrp.transform.childCount; i++)
            {
                Destroy(ConsonantGrp.transform.GetChild(i).gameObject);
            }
        }

        if (isVowel)
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
            RandomHangul();
        }
	}

    #region RandomHangul
    void RandomHangul()
    {
        if (isConsonant)
        {
            Text tempWord = Instantiate(hangulTextPrefab, transform.localPosition, Quaternion.identity, transform.GetChild(0));
            tempWord.transform.position = transform.position + new Vector3(Random.Range(-960, 960), 544, 1);
            tempWord.GetComponent<HangulWord>().objSpeed = hangulSpeed;
            int tempNumber1 = Random.Range(0, hangulConsonant.Length);
            tempWord.text = hangulConsonant[tempNumber1];
            tempWord.name = tempWord.text;
            tempWord.GetComponent<AudioSource>().clip = consonantSounds[tempNumber1];
        }
        if (isVowel)
        {
            Text tempWord = Instantiate(hangulTextPrefab, transform.localPosition, Quaternion.identity, transform.GetChild(1));
            tempWord.transform.position = transform.position + new Vector3(Random.Range(-960, 960), 544, 1);
            int tempNumber2 = Random.Range(0, hangulVowel.Length);
            tempWord.GetComponent<HangulWord>().objSpeed = hangulSpeed;
            tempWord.text = hangulVowel[tempNumber2];
            tempWord.name = tempWord.text;
            tempWord.GetComponent<AudioSource>().clip = vowelSounds[tempNumber2];
        }
    }
    #endregion

    #region Toggles
    public void IsConsonantOn()
    {
        isConsonant = ConsonantToggle.isOn;
    }

    public void IsVowelOn()
    {
        isVowel = VowelToggle.isOn;
    }
    #endregion

    #region Consonant Input
    void DestroyConsonant()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ConsonantMethod("ㅂ");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ConsonantMethod("ㅈ");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ConsonantMethod("ㄷ");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ConsonantMethod("ㄱ");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            ConsonantMethod("ㅅ");
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            ConsonantMethod("ㅁ");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ConsonantMethod("ㄴ");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ConsonantMethod("ㅇ");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            ConsonantMethod("ㄹ");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ConsonantMethod("ㅎ");
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ConsonantMethod("ㅋ");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ConsonantMethod("ㅌ");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ConsonantMethod("ㅊ");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            ConsonantMethod("ㅍ");
        }
    }

    void ConsonantMethod(string ConsonantWord)
    {
        GameObject temp = GameObject.Find(ConsonantWord);
        if (temp == isActiveAndEnabled)
        {
            Destroy(temp.GetComponent<Text>());
            temp.name += "Deleted";
            temp.GetComponent<AudioSource>().Play();
            Destroy(temp, 2f);
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
