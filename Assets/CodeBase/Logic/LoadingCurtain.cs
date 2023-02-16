using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            var waitSomeSeconds = new WaitForSeconds(0.03f);
            
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= 0.03f;
                yield return waitSomeSeconds;
            }
            
            gameObject.SetActive(false);
        }
    }
}