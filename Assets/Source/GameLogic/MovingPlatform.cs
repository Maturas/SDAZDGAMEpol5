using System.Collections.Generic;
using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    public class MovingPlatform : MonoBehaviour
    {
        [field: SerializeField]
        private Rigidbody2D Platform { get; set; }
        
        [field: SerializeField]
        private Transform A { get; set; }

        [field: SerializeField]
        private Transform B { get; set; }
        
        [field: SerializeField]
        private float TravelTime { get; set; }
        
        private Transform From { get; set; }
        private Transform To { get; set; }
        private float TValue { get; set; }
        
        private List<Rigidbody2D> RigidbodiesInTrigger { get; set; }

        // Assumption #1: we always move on a straight line between A and B
        // Assumption #2: we move at a constant speed
        // Assumption #3: A and B are static

        private void Start()
        {
            From = A;
            To = B;
            TValue = 0.0f;

            Platform.position = From.position;
            RigidbodiesInTrigger = new List<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var previousPosition = Platform.position;
            
            // Calculate the t parameter for lerp function, by adding time since last frame multiplied by speed
            TValue = Mathf.Clamp(TValue + Time.fixedDeltaTime / TravelTime, 0.0f, 1.0f);

            // 0-1
            // 0 - From position
            // 1 - To position
            // 0.5 - halfway between From and To
            var newPosition = Vector2.Lerp(From.position, To.position, TValue);
            var deltaPosition = newPosition - previousPosition;
            Platform.MovePosition(newPosition);

            // TODO Improve, allow player to jump and move freely
            foreach (var rigid in RigidbodiesInTrigger)
            {
                rigid.MovePosition(rigid.position + deltaPosition);
            }

            if (Mathf.Approximately(TValue, 1.0f))
            {
                // Bounce back
                TValue = 0.0f;
                (From, To) = (To, From); // tuple swap
            }
        }

        public void OnPlatformTriggerEnter(Rigidbody2D obj)
        {
            if (!RigidbodiesInTrigger.Contains(obj))
                RigidbodiesInTrigger.Add(obj);
        }

        public void OnPlatformTriggerExit(Rigidbody2D obj)
        {
            if (RigidbodiesInTrigger.Contains(obj))
                RigidbodiesInTrigger.Remove(obj);
        }
    }
}