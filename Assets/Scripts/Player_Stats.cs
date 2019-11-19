using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

	public static int Money;
	public int StartMoney=400;
	public static int Lives;
	public int StartLives = 20;
	public static int round;
	void Start()
	{
		Money = StartMoney;
		Lives = StartLives;
		round = 0;
	}


}
