using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneLine : Cutscene
{
    private Text textHolder;
    [SerializeField] private string input;
    [SerializeField] private float Delay;
    [SerializeField] private float DelayBetweenLines;

    private void Awake()
    {
        textHolder = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, Delay)); //, DelayBetweenLines));
    }
}
