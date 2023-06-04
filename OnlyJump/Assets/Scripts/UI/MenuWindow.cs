using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.UI
{
    public class MenuWindow : MonoBehaviour
    {
        private const string Is_Open = "isOpen";

        private Animator windowAnimator;

        public virtual void Start() => windowAnimator = GetComponent<Animator>();
       
        public virtual void OpenWindow() { }
        public virtual void CloseWindow() { }

        public void AppearWindow() => windowAnimator.SetBool(Is_Open, true);
        public void UnAppearWindow() => windowAnimator.SetBool(Is_Open, false);
    }
}
