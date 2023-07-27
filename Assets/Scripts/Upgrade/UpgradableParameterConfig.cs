using ScriptableObject;
using UnityEngine;

namespace Upgrade
{
    [CreateAssetMenu(menuName = "Data/Upgrade Config", fileName = "{Parameter Name} Config")]
    public class UpgradableParameterConfig : SerializableScriptableObject
    {
        [field: SerializeField] public float Factor { get; private set; }
        [field: SerializeField] public int MaxUpgradeLevel { get; private set; }
        [field: SerializeField] public int CurrentLevel { get; private set; }
        [field: SerializeField] public int Cost { get; private set; } = 1;
        
        [field: SerializeField] public string Name { get; private set; }

        public void Upgrade()
        {
            CurrentLevel = Mathf.Min(MaxUpgradeLevel, CurrentLevel + 1);
        }
    }
}