using UnityEngine;

namespace Upgrade
{
    [CreateAssetMenu(menuName = "Data/Upgrade Config", fileName = "{Parameter Name} Config")]
    public class UpgradableParameterConfig : ScriptableObject
    {
        [field: SerializeField] public float Factor { get; private set; }
        [field: SerializeField] public int MaxUpgradeLevel { get; private set; }
    }
}