using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class Config {
    public static class Language {
        private static string s_language = "en-us";
        private static Dictionary<string, string> s_strings;
        
        public static void Set(string language = "en-us") {
            s_language = language;
            s_strings = new Dictionary<string, string>();

            TextAsset textAsset = Resources.Load<TextAsset>("xml/lang/" + language);
            if (textAsset == null) {
                Debug.LogError("Language not found!");
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(textAsset.text);

            foreach (XmlNode node in document.DocumentElement.ChildNodes) {
                s_strings.Add(node.Name, node.InnerText);
            }
        }

        public static string GetString(string id) {
            if (s_strings.ContainsKey(id)) {
                return s_strings[id].ToString();
            }
            return "Error";
        }
    }

    private static Dictionary<string, string> s_dictionary;

	public static void Load() {
        s_dictionary = new Dictionary<string, string>();
        TextAsset textAsset = Resources.Load("xml/config") as TextAsset;
        XmlDocument document = new XmlDocument();
        document.LoadXml(textAsset.text);

		foreach(XmlNode node in document.DocumentElement.ChildNodes) {
            s_dictionary.Add(node.Name, node.InnerText);
		}
        if (s_dictionary.ContainsKey("LANGUAGE")) {
            Language.Set(s_dictionary["LANGUAGE"].ToString());
        }
	}

	public static int GetInt(string id) {
        int tmp;
        if (int.TryParse(s_dictionary[id], out tmp)) { return tmp; }
        Debug.LogError("Could not parse string to integer.");
        return 0;
	}

	public static float GetFloat(string id) {
        float tmp;
        if (float.TryParse(s_dictionary[id], out tmp)) { return tmp; }
        Debug.LogError("Could not parse string to float.");
        return 0f;
	}

	public static bool GetBool(string id) {
        bool tmp;
        if (bool.TryParse(s_dictionary[id], out tmp)) { return tmp; }
        Debug.LogError("Could not parse string to boolean.");
        return false;
	}
}