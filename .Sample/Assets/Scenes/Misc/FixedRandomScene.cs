using System;
using BustaGames.Random;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FixedRandomScene : MonoBehaviour
{
    private FixedRandom _random;

    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button setSeed;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button generateRandom;
    
    private void Start()
    {
        _random = new FixedRandom(0);
        setSeed.onClick.AddListener(SetSeed);
        generateRandom.onClick.AddListener(GenerateRandom);
    }

    private void SetSeed()
    {
        var seedText = input.text;
        _random = new FixedRandom(seedText.GetHashCode());
    }

    private void GenerateRandom()
    {
        var value = _random.Value(100);
        text.text = value.ToString();
    }
}
