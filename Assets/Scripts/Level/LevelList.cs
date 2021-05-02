using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList_#", menuName = "Levels/Create Level List", order = 1)]
public class LevelList : ScriptableObject
{
    [Tooltip("List of all playable levels.")]
    public List<Level> levels;
}
