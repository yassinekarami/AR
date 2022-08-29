using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.QuizzScene
{
    public class TimerSlider : MonoBehaviour
    {
        Slider slider;
        float timer;

        public void Awake()
        {
            slider = GetComponent<Slider>();
            initTimer();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            slider.value = (int)timer % 60;
        }

        public void initTimer()
        {
            timer = 0;
        }

        public bool isMaxValue()
        {
            return slider.value.Equals(slider.maxValue);
        }
    } 
}