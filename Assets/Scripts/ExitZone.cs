using System;
using UnityEngine;


namespace TestTask
{
    public class ExitZone : MonoBehaviour
    {
        public static event Action OnExitZoneEntered;


        private void OnTriggerEnter(Collider other)
        {
            OnExitZoneEntered?.Invoke();
        }
    }
}

