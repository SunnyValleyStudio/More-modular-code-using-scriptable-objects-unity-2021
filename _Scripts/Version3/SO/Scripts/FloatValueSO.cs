using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Version3
{
    [CreateAssetMenu(menuName ="Data/FloatData")]
    public class FloatValueSO : ScriptableObject
    {
        [SerializeField]
        private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChange?.Invoke(_value);
            }

        }
        public event Action<float> OnValueChange;

    }
}
