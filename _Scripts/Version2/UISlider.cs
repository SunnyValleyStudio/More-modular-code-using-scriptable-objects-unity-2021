using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Version2
{
    public class UISlider : MonoBehaviour
    {
        [SerializeField]
        private Image sliderImage;

        public void SetValue(float currentValue)
        {
            sliderImage.fillAmount = Mathf.Clamp01(currentValue);
        }
    }
}