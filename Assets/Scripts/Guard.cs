using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CIS452_Assignment3
{

    public class Guard : MonoBehaviour, IObserver
    {
        public bool see;

        public Transform playerPos;
        public int speed;

        public Player player;

        
        // Start is called before the first frame update
        public void Start()
        {
            if (this == null)
                Debug.Log("null test");
            //this.see = false;
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
