using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
[CreateAssetMenu(fileName ="FruitableObject",menuName = "FruitableObject")]
public class FruitableObject : ScriptableObject
{
    
    public List<FruitsSkinOOP> fruits = new List<FruitsSkinOOP>();

    [Min(1)]
    public int chosenIndex;
    
   
}
