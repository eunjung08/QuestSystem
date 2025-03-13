using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class Player : MonoBehaviour
    {
        CharacterController characterController;
        Animator animator;
        public float moveSpeed = 10f;
        bool isWalk;
        
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Walk();
            Rotation();
        }

        void Walk()
        {
            if (Input.GetKey(KeyCode.W))
            {
                characterController.Move(this.transform.forward * Time.deltaTime * moveSpeed);
                isWalk = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                characterController.Move(-this.transform.forward * Time.deltaTime * moveSpeed);
                isWalk = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                characterController.Move(this.transform.right * Time.deltaTime * moveSpeed);
                isWalk = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                characterController.Move(-this.transform.right * Time.deltaTime * moveSpeed);
                isWalk = true;
            }
        }
        void Rotation()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, Vector3.zero);

            float rayLength;
            if (plane.Raycast(ray, out rayLength))
            {
                Vector3 mousePoint = ray.GetPoint(rayLength);

                this.transform.LookAt(new Vector3(mousePoint.x, this.transform.position.y, mousePoint.z));
            }
        }
    }
}
