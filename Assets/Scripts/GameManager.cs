using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int scores;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText(scores.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(scores.ToString());
    }
}
