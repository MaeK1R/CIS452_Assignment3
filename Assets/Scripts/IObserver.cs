/*
 * Matt Kirchoff
 * IObserver.cs
 * Assignment 3
 * Observer interface
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CIS452_Assignment3
{
    public interface IObserver
    {
        void UpdateData(bool seen);

    }
}
