using System.Collections.Generic;
using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class MovingPlatform : MonoBehaviour
    {
        [field: SerializeField]
        private Transform Platform { get; set; }
        
        [field: SerializeField]
        private Transform A { get; set; }

        [field: SerializeField]
        private Transform B { get; set; }
        
        [field: SerializeField]
        private float TravelTime { get; set; }
        
        private Transform From { get; set; }
        private Transform To { get; set; }
        private float TValue { get; set; }
        
        private List<Transform> TransformsInTrigger { get; set; }

        // Assumption #1: we always move on a straight line between A and B
        // Assumption #2: we move at a constant speed
        // Assumption #3: A and B are static

        private void Start()
        {
            From = A;
            To = B;
            TValue = 0.0f;

            Platform.position = From.position;
            TransformsInTrigger = new List<Transform>();
        }

        private void Update()
        {
            var previousPosition = Platform.position;
            
            // Calculate the t parameter for lerp function, by adding time since last frame multiplied by speed
            TValue = Mathf.Clamp(TValue + Time.deltaTime / TravelTime, 0.0f, 1.0f);

            // 0-1
            // 0 - From position
            // 1 - To position
            // 0.5 - halfway between From and To
            var newPosition = Vector3.Lerp(From.position, To.position, TValue);
            var deltaPosition = newPosition - previousPosition;
            Platform.position = newPosition;

            foreach (var trans in TransformsInTrigger)
            {
                trans.position += deltaPosition;
            }

            if (Mathf.Approximately(TValue, 1.0f))
            {
                // Bounce back
                TValue = 0.0f;
                (From, To) = (To, From); // tuple swap
            }
        }

        public void OnPlatformTriggerEnter(Transform obj)
        {
            if (!TransformsInTrigger.Contains(obj))
                TransformsInTrigger.Add(obj);
        }

        public void OnPlatformTriggerExit(Transform obj)
        {
            if (TransformsInTrigger.Contains(obj))
                TransformsInTrigger.Remove(obj);
        }
    }
}