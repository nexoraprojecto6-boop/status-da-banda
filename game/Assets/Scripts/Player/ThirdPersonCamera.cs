using SDB.Core;
using UnityEngine;

namespace SDB.Player
{
    public sealed class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float distance = 5f, height = 1.6f, sensitivity = 0.15f;
        [SerializeField] float minPitch = -20f, maxPitch = 60f;

        float _yaw, _pitch = 15f;
        IMoveInput _input;

        public void SetTarget(Transform t) => target = t;

        void Start() => ServiceLocator.TryGet(out _input);

        void LateUpdate()
        {
            if (target == null) return;
            if (_input != null)
            {
                var look = _input.ConsumeLook();
                _yaw += look.x * sensitivity;
                _pitch = Mathf.Clamp(_pitch - look.y * sensitivity, minPitch, maxPitch);
            }
            var rot = Quaternion.Euler(_pitch, _yaw, 0f);
            var focus = target.position + Vector3.up * height;
            transform.SetPositionAndRotation(focus - rot * Vector3.forward * distance, rot);
        }
    }
}
