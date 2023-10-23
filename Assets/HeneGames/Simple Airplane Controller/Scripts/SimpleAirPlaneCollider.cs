using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeneGames.Airplane
{
    public class SimpleAirPlaneCollider : MonoBehaviour
    {
        public bool collideSometing;

        [HideInInspector]
        public SimpleAirPlaneController controller;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
            }
            else
            {
                //Collide someting bad
                if (other.gameObject.GetComponent<SimpleAirPlaneCollider>() == null && other.gameObject.GetComponent<LandingArea>() == null)
                {
                    collideSometing = true;
                }
            }
            
        }
    }
}