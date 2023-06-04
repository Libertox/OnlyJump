using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.UI
{
    public class LevelChooseAnimation : MonoBehaviour
    {
        private const string IS_OPEN = "IsOpen";
        private const string RIGHT_OPEN = "RightOpen";
        private const string RIGHT_CLOSE = "RightClose";
        private const string SWAP_ON_RIGHT = "SwapOnRight";
        private const string SWAP_ON_LEFT = "SwapOnLeft";

        private Animator animator;

        private void Awake() => animator = GetComponent<Animator>();

        public void RightOpenAnimation()
        {
            animator.SetBool(IS_OPEN, true);
            animator.SetBool(RIGHT_OPEN, true);
        }

        public void LeftOpenAnimation()
        {
            animator.SetBool(IS_OPEN, true);
            animator.SetBool(RIGHT_OPEN, false);
        }

        public void LeftCloseAnimation()
        {
            animator.SetBool(IS_OPEN, false);
            animator.SetBool(RIGHT_CLOSE, false);
        }

        public void RightCloseAnimation()
        {
            animator.SetBool(IS_OPEN, false);
            animator.SetBool(RIGHT_CLOSE, true);
        }
        public void SwapPlaceOnRightAnimation()
        {
            animator.SetBool(SWAP_ON_RIGHT, true);
            animator.SetBool(SWAP_ON_LEFT, false);
        }
        public void SwapPlaceOnLeftAnimation()
        {
            animator.SetBool(SWAP_ON_LEFT, true);
            animator.SetBool(SWAP_ON_RIGHT, false);
        }
    }
}
