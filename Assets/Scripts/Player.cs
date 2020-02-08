using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIS452_Assignment3
{
    public class Player : MonoBehaviour, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();


        public float speed;

        private bool see;
        private bool gem;

        private Rigidbody2D rb2d;
        private Vector2 moveSpeed;


        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.UpdateData(see);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            //Add observer to list of observers
            observers.Add(observer);

            observer.UpdateData(see);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
        public void SetAgro(bool seen)
        {
            if(gem == true)      
                this.see = true;
            else
                this.see = seen;
            NotifyObservers();
        }

        // Start is called before the first frame update
        void Start()
        {
            see = false;
            gem = false;
            rb2d = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveSpeed = move.normalized * speed;

        }
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift))
                rb2d.MovePosition(rb2d.position + moveSpeed * 2 * Time.fixedDeltaTime);
            else
                rb2d.MovePosition(rb2d.position + moveSpeed * Time.fixedDeltaTime);
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("trigger enter");
            /*if (col.gameObject.CompareTag("Sight"))
            {
                SetAgro(true);
            }*/
            if (col.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("DeathMenu");

                Debug.Log("Enemy Hit");
            }
            if (col.gameObject.CompareTag("Gem"))
            {
                gem = true;
                SetAgro(true);
                Destroy(col.gameObject);
            }
            if (col.gameObject.CompareTag("Exit"))
            {
                if (gem == true)
                    SceneManager.LoadScene("EndMenu");
            }
        }
        void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Sight"))
            {
                SetAgro(true);
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Sight"))
            {
                SetAgro(false);
            }
        }
    }

}
