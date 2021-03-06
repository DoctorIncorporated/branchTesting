﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class CanvasScript : MonoBehaviour
{
	public List<Text> HighScores = new List<Text>();
	public GameObject panel;

	public void DisplayLeaderBoard(SocketIOEvent e)
	{
        panel.SetActive(true);

        //Debug.Log(e);
        List<JSONObject> records = e.data["AllRecords"].list;
        int i = 0;

        foreach (Text score in HighScores)
		{
            string a = records[i]["user"].ToString().Trim('"');
            string b = "";
            string c1 = records[i]["time"].ToString().Trim('"');
            string[] c = c1.Split('.');
            

            //Debug.Log('|' + c[0] + " : " + c[1] + '|');

            while(a.Length < 10)
            {
                a = a + ".";
            }
            while(c[0].Length < 4)
            {
                c[0] = "." + c[0];
            }
            while(c[1].Length < 4)
            {
                c[1] = c[1] + " ";
            }
            while((a.Length + b.Length + c.Length) <= 33)
            {
                b = b + ".";
            }
            //Debug.Log('|' + c[0] + " : " + c[1] + '|');
            score.text = a + b + c[0] + '.' + c[1];           

            //score.text = records[i]["user"].ToString().Trim('"') + "\t\t\t..........\t\t" + records[i]["time"]; 
            i++;
        }
	}
}
