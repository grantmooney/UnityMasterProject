﻿using UnityEngine;
using System;
using System.Collections;
using MiniJSON;

public class GameManager {
	private static GameManager s_instance;
	public static GameManager Instance {
		get {
			if(s_instance == null) {
				s_instance = new GameManager();
			}
			return s_instance;
		}
	}

	private const string SAVE_DATA_KEY = "S@v3_Da7A_K3Y";

	public GameManager() {
		Debug.Log ("Game Manager Created!");
	}

	public void Initialize() {
		Config.Load();
		LoadData();
	}

	private void LoadData() {
		string serializedData = PlayerPrefs.GetString (SAVE_DATA_KEY);
		if (serializedData != string.Empty) {
			Hashtable hashtable = (Hashtable)Json.Deserialize(SAVE_DATA_KEY);
			if(hashtable.ContainsKey(AudioManager.HashTableKey)) {
				AudioManager.Instance.ReadFromHashTable((Hashtable)hashtable[AudioManager.HashTableKey]);
			}
		}
	}

	public void SaveData() {
		Hashtable hashtable = new Hashtable();

		hashtable [AudioManager.HashTableKey] = AudioManager.Instance.WriteToHashTable ();

		PlayerPrefs.SetString (SAVE_DATA_KEY, Json.Serialize(hashtable));
		PlayerPrefs.Save();
	}
}
