using SDB.Demo;
using SDB.Player;
using SDB.UI;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SDB.Editor
{
    public static class PrototypeSceneBuilder
    {
        const string ScenePath = "Assets/Scenes/Prototype.unity";

        [MenuItem("STATUS DA BANDA/Criar cena protótipo")]
        public static void Build()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = new Vector3(20, 1, 20);

            var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.transform.position = new Vector3(0, 1, 0);
            Object.DestroyImmediate(player.GetComponent<CapsuleCollider>());
            player.AddComponent<CharacterController>();
            var pc = player.AddComponent<PlayerController>();

            var cam = Camera.main;
            cam.gameObject.AddComponent<ThirdPersonCamera>().SetTarget(player.transform);

            new GameObject("BirthDemoHud").AddComponent<BirthDemoHud>().SetPlayer(pc);

            var es = new GameObject("EventSystem");
            es.AddComponent<EventSystem>();
            var inputModule = System.Type.GetType("UnityEngine.InputSystem.UI.InputSystemUIInputModule, Unity.InputSystem");
            es.AddComponent(inputModule ?? typeof(StandaloneInputModule));

            var canvasGo = new GameObject("Canvas");
            var canvas = canvasGo.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = canvasGo.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.matchWidthOrHeight = 0.5f;
            canvasGo.AddComponent<GraphicRaycaster>();

            // Joystick (canto inferior esquerdo)
            var stick = Img("MoveStick", canvasGo.transform, new Color(1, 1, 1, 0.15f), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0.5f, 0.5f));
            stick.sizeDelta = new Vector2(300, 300);
            stick.anchoredPosition = new Vector2(220, 220);
            var handle = Img("Handle", stick, new Color(1, 1, 1, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
            handle.sizeDelta = new Vector2(120, 120);
            handle.GetComponent<Image>().raycastTarget = false;
            stick.gameObject.AddComponent<VirtualJoystick>().SetHandle(handle, 110f);

            // Área de olhar (metade direita)
            var look = Img("LookPad", canvasGo.transform, new Color(1, 1, 1, 0.01f), new Vector2(0.5f, 0), new Vector2(1, 1), new Vector2(0.5f, 0.5f));
            look.offsetMin = look.offsetMax = Vector2.zero;
            look.gameObject.AddComponent<LookPad>();

            EditorSceneManager.SaveScene(scene, ScenePath);
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
            Debug.Log("[SDB] Cena protótipo criada em " + ScenePath);
        }

        static RectTransform Img(string name, Transform parent, Color c, Vector2 aMin, Vector2 aMax, Vector2 pivot)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            go.GetComponent<Image>().color = c;
            var rt = (RectTransform)go.transform;
            rt.anchorMin = aMin; rt.anchorMax = aMax; rt.pivot = pivot;
            return rt;
        }
    }
}
