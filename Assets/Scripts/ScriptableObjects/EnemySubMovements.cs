using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemySubMovemnt", menuName = "EnemySubMovements")]
public class EnemySubMovements : ScriptableObject
{
    public float SubWidth, SubHeight, SubHorizontalMod = 1f, SubVerticalMod = 1f;
}
