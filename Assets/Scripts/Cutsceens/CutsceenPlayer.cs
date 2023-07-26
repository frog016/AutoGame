using UnityEngine;

namespace Cutsceens
{
    public class CutsceenPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CutsceenLoadArguments _cutsceenLoad;

        private void Awake()
        {
            PlayCutsceen();
        }

        private void PlayCutsceen()
        {
            var clip = _cutsceenLoad.GetActiveCutsceen();
            _animator.Play(clip.name);
        }
    }
}