using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowMovementChecker : MonoBehaviour
{
        private Boolean canMove = true;

        private void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.tag == "Obstakel")
                {
                        
                        canMove = false;
                }
        }

        private void OnCollisionExit(Collision other)
        {
                if (other.gameObject.tag == "Obstakel")
                {
                        canMove = true;
                }
        }

        private void OnCollisionStay(Collision other)
        {
                if (other.gameObject.tag == "Obstakel")
                {
                        canMove = false;
                }
        }

        public Boolean getCanMove()
        {
                return this.canMove;
        }
}
