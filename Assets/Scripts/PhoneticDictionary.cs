using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PhoneticDictionary : MonoBehaviour
{
	private const string _FILE_PATH = "./Assets/Data/PHONETIC_DICTIONARY_BASE_A.csv";
	private List<PhoneticDictionaryItem> _list_MainDictionaryItems;

	private void Awake()
	{
		LoadData();
	}

	private void LoadData()
	{
		StreamReader reader = new StreamReader(File.OpenRead(_FILE_PATH));
		_list_MainDictionaryItems = new List<PhoneticDictionaryItem>();
        List<PhoneticDictionaryItem> list_RelatedItems = new List<PhoneticDictionaryItem>();
        PhoneticDictionaryItem currentMainItem = null;
		while (!reader.EndOfStream)
		{
			string[] sLineComponents = reader.ReadLine().Split(',');
            if (sLineComponents[0].Contains("/")) // Related Item
            {
                sLineComponents[0].Replace("/", currentMainItem.sWord);
                sLineComponents[1].Replace("/", currentMainItem.sDictionaryPronunciation);
                sLineComponents[2].Replace("/", currentMainItem.sPhoneticSpelling);
                currentMainItem.list_RelatedItems.Add(new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]));
            }
            else // Main Item
            {
                if(currentMainItem != null)
                {
                    _list_MainDictionaryItems.Add(currentMainItem);
                }
                currentMainItem = new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]);
            }
		}
	}

    public void SearchForDictionaryItem(string sInput)
    {
        foreach(PhoneticDictionaryItem item in _list_MainDictionaryItems)
        {
            
        }
    }

    private class PhoneticDictionaryItem
    {
        public string sWord;
        public string sDictionaryPronunciation;
        public string sPhoneticSpelling;
        public List<PhoneticDictionaryItem> list_RelatedItems;

        public PhoneticDictionaryItem(string sWord, string sDictionaryPronunciation, string sPhoneticSpelling)
        {
            this.sWord = sWord;
            this.sDictionaryPronunciation = sDictionaryPronunciation;
            this.sPhoneticSpelling = sPhoneticSpelling;

            list_RelatedItems = new List<PhoneticDictionaryItem>();
        }
    }
}
