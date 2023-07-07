using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [field: SerializeField] public int Direction { get; private set; }

        public bool Pressed { get; private set; }

        private void OnValidate()
        {
            if (Direction is 0 or > 1 or < -1)
                throw new ArgumentOutOfRangeException($"Direction must be 1 or -1.");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }
    }
}