using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private float speed;
        [SerializeField] private Camera MainCamera;
        private Vector3 direction;

        private void Update()
        {

        Telekinesis();
        FollowingMouse();
        MovingControle();

        }
        private void FollowingMouse()
        {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            
            if (raycastHit.collider.gameObject.layer != 2)
            {
                       direction = new Vector3(
                       raycastHit.point.x - transform.position.x,
                       0f,
                       raycastHit.point.z - transform.position.z
                       );

                transform.forward = direction;
                
            }
        }
        }
        private void Telekinesis()
        {
        if (Input.GetMouseButton(2))
        {
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.green);
            if (Physics.Raycast(ray, out RaycastHit raycastHit) && Physics.CheckSphere(transform.position, 5))
            {
                if (raycastHit.collider.gameObject.tag == "Moveable")
                {
                    raycastHit.collider.gameObject.transform.position =
                        new Vector3(raycastHit.collider.gameObject.transform.position.x,
                                    raycastHit.collider.gameObject.transform.position.y + 4f,
                                    raycastHit.collider.gameObject.transform.position.z);


                }
            }
        }
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
