using System;
using System.Linq;
using UnityEngine;

namespace Cutsceens
{
    [CreateAssetMenu(menuName = "Data/Cutsceen Load", fileName = "Cutsceen Load Arguments")]
    public class CutsceenLoadArguments : UnityEngine.ScriptableObject
    {
        [SerializeField] private CutsceenLoadArgs[] _cutsceens;

        [SerializeField] private CutsceenName _cutsceenName;
        [SerializeField] private CutsceenState _state;

        public void LoadCutsceenArgs(CutsceenName cutsceenName, CutsceenState state)
        {
            _cutsceenName = cutsceenName;
            _state = state;
        }

        public AnimationClip GetActiveCutsceen()
        {
            var cutsceen = _cutsceens.First(cutsceen => cutsceen.Name == _cutsceenName && cutsceen.State == _state);
            return cutsceen.PlayableClip;
        }

        [Serializable]
        public struct CutsceenLoadArgs
        {
            [field: SerializeField] public CutsceenName Name { get; private set; }
            [field: SerializeField] public CutsceenState State { get; private set; }
            [field: SerializeField] public AnimationClip PlayableClip { get; private set; }
        }

        public enum CutsceenState
        {
            Start,
            End
        }
    }
}