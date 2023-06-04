using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    public class RecordModeObject : MonoBehaviour
    {
        [SerializeField] private int maxSpeed;
        [SerializeField] private int minSpeed;
        [SerializeField] private float leftBound;
        [SerializeField] private float speedMultiplexer;

        private int speed;
        
        private void Start() => speed = Random.Range(minSpeed, maxSpeed);

        private void FixedUpdate()
        {
            MoveLeft();
            CrossBorder();
        }

        private void MoveLeft()
        {
            if (LevelManager.Instance.IsPlayState())
                transform.Translate(Vector3.left * (speed * speedMultiplexer * Time.deltaTime));
        }


        private void CrossBorder()
        {
            if (transform.position.x < leftBound)
                gameObject.SetActive(false);
        }

        public void SetSpeedMultiplexer(float speedMultiplexer) => this.speedMultiplexer = speedMultiplexer;
    }
}
