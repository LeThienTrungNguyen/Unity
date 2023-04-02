using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level_OOP 
{
    public string level_name;
    public bool isCompleted;
    public int score;
    public enum Ranks
    {
        Zero,D,C,A,S
    };

    [SerializeField] public Ranks rank;


}
