using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CIS452_Assignment3
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}
