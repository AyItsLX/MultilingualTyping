using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangulWord : MonoBehaviour {

    [HideInInspector]
    public float objSpeed;

    public GameManager gameManager;

	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

	void Update ()
    {
        if (!gameManager.isPaused)
        {
            transform.position += Vector3.down * Time.deltaTime * objSpeed;
        }
    }
}
