using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Version2
{
    public class HealthTip : MonoBehaviour
    {
        [SerializeField] private GameObject healthTip;

        [SerializeField] private float threshold = 0.8f;

        public void ToggetTip(float val) 
            => healthTip.SetActive(val <= threshold);
        
    }
}
