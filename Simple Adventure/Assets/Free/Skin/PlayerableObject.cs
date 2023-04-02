using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerableObject", menuName = "PlayerableObject")]
public class PlayerableObject : ScriptableObject
{
    public List<PlayerSkin> players = new List<PlayerSkin>();

    [Min(1)]
    public int chosenIndex;

}
