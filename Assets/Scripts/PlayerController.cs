using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private float speed;
        [SerializeField] private Camera MainCamera;
        private Vector3 direction;


        private bool teletelekinesisActivation = false;

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
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "Moveable" && Vector3.Distance(transform.position, raycastHit.collider.gameObject.transform.position) < 10 && raycastHit.rigidbody != null)
                {
                    if (!teletelekinesisActivation)
                    {
                        teletelekinesisActivation = true;
                        raycastHit.rigidbody.transform.position = new Vector3(raycastHit.rigidbody.transform.position.x, 1.7f, raycastHit.rigidbody.transform.position.z);
                        raycastHit.rigidbody.isKinematic = true;
                        raycastHit.rigidbody.transform.SetParent(gameObject.transform);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(2))
        {
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
                teletelekinesisActivation = false;
                if (gameObject.transform.GetChild(1).transform.parent != null)
                    gameObject.transform.GetChild(1).transform.parent = null;
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
