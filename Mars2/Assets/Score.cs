using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public Transform player2;
    public Text scoreText;
    float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = timeStart.ToString("F1");
    }

    // public GameObject player;


    // Update is called once per frame
    void Update()
    {
        //scoreText.text = player2.position.z.ToString("0");  
        timeStart += Time.deltaTime;
        scoreText.text = timeStart.ToString("F1");
    }
}
