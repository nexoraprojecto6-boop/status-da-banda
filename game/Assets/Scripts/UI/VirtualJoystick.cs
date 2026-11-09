using SDB.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SDB.UI
{
    public sealed class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] RectTransform handle;
        [SerializeField] float radius = 110f;
        TouchInput _touch;
        RectTransform _rect;

        public void SetHandle(RectTransform h, float r) { handle = h; radius = r; }

        void Awake()
        {
            _rect = (RectTransform)transform;
            if (ServiceLocator.TryGet<IMoveInput>(out var i)) _touch = i as TouchInput;
        }

        public void OnPointerDown(PointerEventData e) => OnDrag(e);

        public void OnDrag(PointerEventData e)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, e.position, e.pressEventCamera, out var local)) return;
            var v = Vector2.ClampMagnitude(local / radius, 1f);
            if (handle != null) handle.anchoredPosition = v * radius;
            if (_touch != null) _touch.Move = v;
        }

        public void OnPointerUp(PointerEventData e)
        {
            if (handle != null) handle.anchoredPosition = Vector2.zero;
            if (_touch != null) _touch.Move = Vector2.zero;
        }
    }
}
