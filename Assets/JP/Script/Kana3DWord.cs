using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kana3DWord : MonoBehaviour {

    public float objSpeed;

	void Start () {}

	void Update () {
        transform.position += Vector3.back * Time.deltaTime * objSpeed;

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
    
}
