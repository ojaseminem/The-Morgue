using System;
using UnityEngine;

namespace Player
{
    public class PlayerHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Collider>().CompareTag("CutSceneTrigger"))
            {
                print("Hey, found it");
            }
        }
    }
}