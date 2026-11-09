using SDB.Core;
using UnityEngine;

namespace SDB.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] float walkSpeed = 3f, runSpeed = 6f, turnSpeed = 12f, gravity = -20f;
        [SerializeField] Transform cameraTransform;

        CharacterController _cc;
        IMoveInput _input;
        float _vy;

        void Awake()
        {
            _cc = GetComponent<CharacterController>();
            ServiceLocator.TryGet(out _input);
        }

        void Update()
        {
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;

            Vector2 m = _input != null ? _input.Move : Vector2.zero;
#if ENABLE_LEGACY_INPUT_MANAGER
            m += new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            m = Vector2.ClampMagnitude(m, 1f);
#endif
            Vector3 fwd = cameraTransform != null
                ? Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized
                : Vector3.forward;
            Vector3 right = Vector3.Cross(Vector3.up, fwd);
            Vector3 dir = fwd * m.y + right * m.x;
            float speed = m.magnitude > 0.85f ? runSpeed : walkSpeed;

            if (_cc.isGrounded && _vy < 0f) _vy = -2f;
            _vy += gravity * Time.deltaTime;

            _cc.Move((dir * speed + Vector3.up * _vy) * Time.deltaTime);

            if (dir.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        }

        public void Teleport(Vector3 position)
        {
            if (_cc == null) _cc = GetComponent<CharacterController>();
            _cc.enabled = false;
            transform.position = position;
            _cc.enabled = true;
            _vy = 0f;
        }
    }
}
