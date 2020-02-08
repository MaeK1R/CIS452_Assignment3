/*
 * Matt Kirchoff
 * Guard.cs
 * Assignment 3
 * Observer to player class. when player is seen, object moves toward player. random speed variable set upon start
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CIS452_Assignment3
{

    public class Guard : MonoBehaviour, IObserver
    {
        public bool see;

        public Transform playerPos;
        public float speed;

        public Player player;

        
        // Start is called before the first frame update
        public void Start()
        {
            speed = Random.Range(0.25f, 1f);
            player.RegisterObserver(this);
        }
        public void UpdateData(bool seen)
        {
            see = seen;
        }

        // Update is called once per frame
        public void Update()
        {
            if (see == true)
            {
                playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            }
        }
    }
}
