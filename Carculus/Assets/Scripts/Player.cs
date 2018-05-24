using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

[RequireComponent(typeof(Car))]
public class Player : MonoBehaviour {
    public GamePad.Index GamepadIndex;
    Car car; 

    private void Awake()
    {
        car = GetComponent<Car>();  
    }
    private void Start()
    {
    }

    private void Update()
    {
        car.steer(GamePad.GetAxis(GamePad.Axis.LeftStick, GamepadIndex, true).x);
        car.setThrottle(GamePad.GetAxis(GamePad.Axis.LeftStick, GamepadIndex, true).y);
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamepadIndex, true).y == 0 && GamepadIndex != 0)
            car.setThrottle(Input.GetAxis("Vertical_" + (int)GamepadIndex)); 
    }
}
