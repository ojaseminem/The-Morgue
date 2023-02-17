using UnityEngine;

namespace Misc
{
    public class CutSceneCameraHandler : MonoBehaviour
    {
        private static CutSceneCameraHandler _instance;
        private void Awake() => _instance = this;

        public static void ToggleAudioListener(bool turnOn) =>
            _instance.transform.GetComponent<AudioListener>().enabled = turnOn;

        public static void SetPriority(float currDepth) =>
            _instance.transform.GetComponent<Camera>().depth = currDepth;
    }
}