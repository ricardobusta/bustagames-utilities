using System;
using BustaGames.EssentialServices;
using UnityEditor;
using UnityEngine;

namespace BustaGames.SafeArea
{
    [Serializable]
    public class SafeAreaController : MonoBehaviour, IService
    {
#if UNITY_EDITOR
        public const string USE_TEST_SAFE_AREA = "SafeArea_UseTestArea";
        public const string TEST_SAFE_AREA_X = "SafeArea_TestSafeAreaX";
        public const string TEST_SAFE_AREA_Y = "SafeArea_TestSafeAreaY";
        public const string TEST_SAFE_AREA_W = "SafeArea_TestSafeAreaW";
        public const string TEST_SAFE_AREA_H = "SafeArea_TestSafeAreaH";

        [SerializeField] private bool UseTestSafeArea;
        [SerializeField] private Rect TestSafeArea;
#endif
        private Rect lastSafeArea;
        private Vector2 anchorMin;
        private Vector2 anchorMax;

        public event Action<Vector2, Vector2> UpdateEvent;

        private void Awake()
        {
            ServiceLocator.AddService(this);
#if UNITY_EDITOR
            AwakeEditor();
#endif
        }

#if UNITY_EDITOR
        private void AwakeEditor()
        {
            UseTestSafeArea = EditorPrefs.GetBool(USE_TEST_SAFE_AREA);
            if (UseTestSafeArea)
            {
                TestSafeArea = new Rect(EditorPrefs.GetFloat(TEST_SAFE_AREA_X, 0),
                    EditorPrefs.GetFloat(TEST_SAFE_AREA_Y, 0), EditorPrefs.GetFloat(TEST_SAFE_AREA_W, Screen.width),
                    EditorPrefs.GetFloat(TEST_SAFE_AREA_H, Screen.height));
            }
        }

        private void OnDrawGizmosSelected()
        {
            var center = lastSafeArea.center;
            var size = lastSafeArea.size;
            Gizmos.DrawCube(center, size);
        }
#endif

        public void GetCurrentSafeArea(out Vector2 anchorMin, out Vector2 anchorMax)
        {
            anchorMin = this.anchorMin;
            anchorMax = this.anchorMax;
        }

        private void CalculateSafeArea(Rect r)
        {
            // https://connect.unity.com/p/updating-your-gui-for-the-iphone-x-and-other-notched-devices
            anchorMin = r.position;
            anchorMax = r.position + r.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            UpdateEvent?.Invoke(anchorMin, anchorMax);
        }

        private void Update()
        {
            var safeArea = Screen.safeArea;
#if UNITY_EDITOR
            if (UseTestSafeArea) safeArea = TestSafeArea;
#endif
            if (lastSafeArea != safeArea)
            {
                lastSafeArea = safeArea;
                CalculateSafeArea(lastSafeArea);
            }
        }
    }
}