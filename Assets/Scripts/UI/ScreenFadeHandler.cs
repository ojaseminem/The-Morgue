using UnityEngine;

namespace UI
{
    public class ScreenFadeHandler : MonoBehaviour
    {
        [HideInInspector] public bool eventTriggered = false;
        
        private void TriggerEvent() => eventTriggered = true;

        private void Done() => Destroy(gameObject);
    }
}
