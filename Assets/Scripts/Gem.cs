using CIS452_Assignment3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CIS452_Assignment3
{


    public class Gem : MonoBehaviour, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public bool gem;
        public GameObject exitSprite;
        public void NotifyObservers()
        {
            Debug.Log("Notify light observers");
            foreach (IObserver observer in observers)
            {
                observer.UpdateData(gem);
            }
            Destroy(this);
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);

            observer.UpdateData(gem);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            gem = false;
            exitSprite.SetActive(false);

        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                exitSprite.SetActive(true);

                LightActive();
            }
        }
        public void LightActive()
        {
            this.gem = true;
            NotifyObservers();
        }
    }
}
