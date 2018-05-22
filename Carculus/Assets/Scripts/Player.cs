using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

[RequireComponent(typeof(Car))]
public class Player : MonoBehaviour {
    public int index;
    Car car; 
    GamePad.Index GPindex;

    private void Awake()
    {
        car = GetComponent<Car>();  
    }
    private void Start()
    {
        switch(index)
        {
            case 0:
                GPindex = GamePad.Index.One;
                break;
            case 1:
                GPindex = GamePad.Index.Two;
                break;
            case 2:
                GPindex = GamePad.Index.Three;
                break;
            case 3:
                GPindex = GamePad.Index.Four;
                break;
        }        
    }

    private void Update()
    {
        car.
    }
}
