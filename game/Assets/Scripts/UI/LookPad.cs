using SDB.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SDB.UI
{
    /// <summary>Área (metade direita do ecrã) que arrasta a câmera.</summary>
    public sealed class LookPad : MonoBehaviour, IDragHandler
    {
        TouchInput _touch;

        void Awake()
        {
            if (ServiceLocator.TryGet<IMoveInput>(out var i)) _touch = i as TouchInput;
        }

        public void OnDrag(PointerEventData e) => _touch?.AddLook(e.delta);
    }
}
