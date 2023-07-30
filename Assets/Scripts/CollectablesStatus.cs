using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CollectablesData")]
public class CollectablesStatus : ScriptableObject
{
    public bool Fragment1Collected = false;
    public bool Fragment2Collected = false;
    public bool Fragment3Collected = false;
}
