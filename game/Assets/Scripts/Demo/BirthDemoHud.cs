using System;
using SDB.Core;
using SDB.Player;
using SDB.Services;
using SDB.World;
using UnityEngine;

namespace SDB.Demo
{
    /// <summary>HUD de protótipo (IMGUI): login offline + escolha de país + nascimento aleatório.</summary>
    public sealed class BirthDemoHud : MonoBehaviour
    {
        [SerializeField] PlayerController player;
        PlayerSession _session;
        BirthOrigin _origin;
        string _status = "A iniciar...";
        bool _busy;

        public void SetPlayer(PlayerController p) => player = p;

        async void Start()
        {
            try
            {
                var r = await ServiceLocator.Get<IAuthService>().LoginAsync();
                if (!r.Ok) { _status = r.Error; return; }
                _session = r.Value;
                _origin = await ServiceLocator.Get<IBirthService>().GetOriginAsync(_session.playerId);
                Apply();
                _status = _origin == null ? "Escolhe o país onde queres nascer" : "Bem-vindo de volta";
            }
            catch (Exception e) { _status = e.Message; Debug.LogException(e); }
        }

        async void Choose(string code)
        {
            if (_busy || _session == null) return;
            _busy = true;
            var r = await ServiceLocator.Get<IBirthService>().AssignAsync(_session.playerId, code);
            if (r.Ok) { _origin = r.Value; Apply(); _status = "Nasceste em:"; } else _status = r.Error;
            _busy = false;
        }

        void Apply()
        {
            if (_origin != null && player != null) player.Teleport(new Vector3(_origin.spawnX, _origin.spawnY, _origin.spawnZ));
        }

        void OnGUI()
        {
            float s = Mathf.Max(1f, Screen.height / 540f);
            GUI.matrix = Matrix4x4.Scale(new Vector3(s, s, 1f));
            var label = new GUIStyle(GUI.skin.label) { fontSize = 18 };
            var btn = new GUIStyle(GUI.skin.button) { fontSize = 18 };

            GUILayout.BeginArea(new Rect(12, 12, 360, 220));
            GUILayout.Label("STATUS DA BANDA — protótipo", label);
            GUILayout.Label(_status, label);
            if (_session != null && _origin == null)
            {
                if (GUILayout.Button("Angola", btn, GUILayout.Height(40))) Choose("AO");
                if (GUILayout.Button("Moçambique", btn, GUILayout.Height(40))) Choose("MZ");
            }
            else if (_origin != null)
            {
                GUILayout.Label($"{_origin.neighborhoodName}, {_origin.cityName}\n{_origin.provinceName} ({_origin.countryCode})", label);
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                if (GUILayout.Button("[DEV] Repor origem", btn, GUILayout.Height(32)))
                {
                    PlayerPrefs.DeleteKey(OfflineBirthService.Key(_session.playerId));
                    _origin = null; _status = "Escolhe o país onde queres nascer";
                }
#endif
            }
            GUILayout.EndArea();
        }
    }
}
