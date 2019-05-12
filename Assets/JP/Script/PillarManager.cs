using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarManager : MonoBehaviour {

    public Toggle[] kanaToggles;
    public GameObject[] kanaGroups;

    bool resetOnce = true;

	void Update () {
        if (!kanaToggles[0].isOn && resetOnce)
        {
            resetOnce = false;
            foreach (Transform child in kanaGroups[0].transform)
            {
                Destroy(child.gameObject);
            }
        }

	}
}
