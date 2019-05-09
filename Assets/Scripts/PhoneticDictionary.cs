using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PhoneticDictionary : MonoBehaviour
{
	private const string _FILE_PATH = "./Assets/Data/PHONETIC_DICTIONARY_BASE_A.csv";
	private List<PhoneticDictionaryItem> _list_DictionaryItems;

	private void Awake()
	{
		LoadData();
	}

	private void LoadData()
	{
		StreamReader reader = new StreamReader(File.OpenRead(_FILE_PATH));
		_list_DictionaryItems = new List<PhoneticDictionaryItem>();
		while (!reader.EndOfStream)
		{
			string[] sLineComponents = reader.ReadLine().Split(',');
			PhoneticDictionaryItem item = new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]);
			_list_DictionaryItems.Add(item);
		}
	}
}
