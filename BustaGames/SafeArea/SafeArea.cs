using BustaGames.EssentialServices;
using UnityEngine;

namespace BustaGames.SafeArea {
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour {
        private RectTransform _panel;
        private SafeAreaController _controller;

        private void Start()
        {
            if (!ServiceLocator.TryGetService(out _controller)) {
                Debug.LogWarning("Missing Event Detector. Safe area will not work.");
                return;
            }

            _panel = GetComponent<RectTransform>();
            _controller.UpdateEvent += UpdatePanel;
            _controller.GetCurrentSafeArea(out var anchorMin, out var anchorMax);
            UpdatePanel(anchorMin, anchorMax);
        }

        private void OnDestroy() {
            if (_controller != null) _controller.UpdateEvent -= UpdatePanel;
        }

        private void UpdatePanel(Vector2 anchorMin, Vector2 anchorMax) {
            Debug.Log($"Updating Safe Area {anchorMin} {anchorMax}");
            _panel.anchorMin = anchorMin;
            _panel.anchorMax = anchorMax;
        }
    }
}