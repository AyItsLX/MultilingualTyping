using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Text gunKanaWord;

    public Color Teal;
    public Color Cyan;

    public bool redCoolDown = false;
    public float redTimer = 1f;

    public Kana3DGen kanaGen;
    public GameObject[] kanaPillars;
    [SerializeField] private GameObject KanaWordGroup;
    [SerializeField] private AudioSource correctAudio;

    void Start () {
        correctAudio = GetComponent<AudioSource>();

        if (kanaGen.turnOnA)
        {
            for (int i = 0; i < kanaGen.A.Length; i++)
            {
                kanaGen.listOfWords.Add(kanaGen.A[i]);
            }
        }
    }

    void Update() {
        if (redCoolDown)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
            redTimer -= Time.deltaTime;
            if (redTimer <= 0)
            {
                redTimer = 1f;
                redCoolDown = false;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
            if (Input.GetMouseButton(0) && hit.transform.gameObject.CompareTag("KanaWord"))
            {
                Text hitText = hit.transform.gameObject.GetComponentInChildren<Text>();
                if (gunKanaWord.text == hitText.text)
                {
                    correctAudio.Play();
                    redCoolDown = true;
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                    Destroy(hit.transform.gameObject);
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.CompareTag("UI"))
            {
                Toggle toggleText = hit.transform.gameObject.GetComponent<Toggle>();
                if (!toggleText.isOn)
                {
                    toggleText.isOn = true;
                    ConfirmArray(toggleText.name, true);
                }
                else if (toggleText.isOn)
                {
                    toggleText.isOn = false;
                    ConfirmArray(toggleText.name, false);
                }
            }
            else if (Input.GetMouseButton(1) && hit.transform.gameObject.CompareTag("PillarWord"))
            {
                Text hitText = hit.transform.gameObject.GetComponentInChildren<Text>();
                gunKanaWord.text = hitText.text;
                lineRenderer.startColor = Teal;
                lineRenderer.endColor = Teal;
            }

            if (hit.transform.gameObject.CompareTag("KanaWord") && !Input.GetMouseButton(1) && !Input.GetMouseButton(0))
            {
                lineRenderer.startColor = Cyan;
                lineRenderer.endColor = Cyan;
            }
            else
            {
                lineRenderer.startColor = Color.white;
                lineRenderer.endColor = Color.white;
            }
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }

        if (Input.GetMouseButton(0) && !redCoolDown)
        {
            lineRenderer.startColor = Cyan;
            lineRenderer.endColor = Cyan;
        }
        else if (Input.GetMouseButton(1) && !redCoolDown)
        {
            lineRenderer.startColor = Teal;
            lineRenderer.endColor = Teal;
        }
    }

    void ConfirmArray(string GameObjectName, bool addToList)
    {
        if (GameObjectName.Equals("A"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.A);
                kanaPillars[0].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.A);
                kanaPillars[0].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("KA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.KA);
                kanaPillars[1].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.KA);
                kanaPillars[1].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("SA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.SA);
                kanaPillars[2].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.SA);
                kanaPillars[2].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("TA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.TA);
                kanaPillars[3].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.TA);
                kanaPillars[3].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("NA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.NA);
                kanaPillars[4].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.NA);
                kanaPillars[4].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("HA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.HA);
                kanaPillars[5].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.HA);
                kanaPillars[5].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("MA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.MA);
                kanaPillars[6].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.MA);
                kanaPillars[6].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("YA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.YA);
                kanaPillars[7].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.YA);
                kanaPillars[7].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("RA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.RA);
                kanaPillars[8].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.RA);
                kanaPillars[8].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (GameObjectName.Equals("WA"))
        {
            if (addToList)
            {
                kanaGen.AddToList(kanaGen.WA);
                kanaPillars[9].SetActive(true);
            }
            else
            {
                kanaGen.RemoveFromList(kanaGen.WA);
                kanaPillars[9].SetActive(false);
                foreach (Transform child in KanaWordGroup.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
