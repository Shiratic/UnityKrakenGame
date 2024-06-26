﻿using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatDisplay[] statDisplays;
    [SerializeField] string[] statNames;

    private CharacterStat[] stats;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        UpdateStatNames();
    }

    public void SetStats(CharacterStat[] charStats)
    {
        stats = charStats;

        if (stats.Length != statDisplays.Length)
        {
            Debug.LogError("Number of stats does not match number of displays!");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            statDisplays[i].Stat = stats[i];
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < statDisplays.Length; i++)
        {
            statDisplays[i].ValueText.text = stats[i].Value.ToString();
        }
    }

    public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length && i < statDisplays.Length; i++)
        {
            statDisplays[i].NameText.text = statNames[i];
        }
    }
}
