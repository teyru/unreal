using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float speed;

        private void Update()
        {
            MovingControle();
        }

        private void MovingControle()
        {
            float HorizontalMove = Input.GetAxis("Horizontal");
            float VerticalMove = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(HorizontalMove, 0, VerticalMove);
            moveDirection.Normalize();

            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
}
