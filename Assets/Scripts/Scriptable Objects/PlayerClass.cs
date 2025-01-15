using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Player/Player Class", fileName = "NewPlayerClass")]
public class PlayerClass : ScriptableObject
{
    public string className;
    [Tooltip("List of stat modifications for this class.")]
    public List<StatModifier> statModifiers = new List<StatModifier>();


}
