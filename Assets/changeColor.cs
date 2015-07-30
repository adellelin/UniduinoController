using UnityEngine;
using System.Collections;
using Uniduino;

public class changeColor : MonoBehaviour {

	public Arduino arduino;
	public int pinA = 0;
	public int pin = 2;
	public int pinValue;
	public int pinValueA;
	public float spinSpeed = 0.2f;

	public GameObject cube;

	// Use this for initialization
	void Start () {
		arduino = Arduino.global;
		//arduino = GameObject.Find("Cube").GetComponent<Arduino>();

		arduino.Setup (ConfigurePins);

		cube = GameObject.Find ("Cube");
		//arduino = cube.AddComponent<Arduino>();
		//arduino = cube.GetComponent<Arduino>();

	}

	void ConfigurePins (){
		arduino.pinMode (pinA, PinMode.ANALOG);
		arduino.pinMode (pin, PinMode.INPUT);

		arduino.reportAnalog (pinA, 1);
		arduino.reportDigital ((byte)(pin / 8), 1);
	}
		
	// Update is called once per frame
	void Update () {
		pinValueA = arduino.analogRead (pinA);
		pinValue = arduino.digitalRead (pin);
		cube.transform.rotation = Quaternion.Euler (0, pinValueA * spinSpeed, 0);
		if (pinValue == 1) {
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		} else {
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
