using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PhoneticDictionary : MonoBehaviour
{
	private const string _FILE_PATH = "./Assets/Data/PHONETIC_DICTIONARY_BASE_A.csv";
	public List<PhoneticDictionaryItem> _list_MainDictionaryItems;

	private void Awake()
	{
		LoadData();
	}

	private void LoadData()
	{
		StreamReader reader = new StreamReader(File.OpenRead(_FILE_PATH));
		_list_MainDictionaryItems = new List<PhoneticDictionaryItem>();
        PhoneticDictionaryItem previousMainItem = null;
        string[] sLineComponents;
        int iParenLocation_Curr, iParenLocation_Prev;
        string sMainWord_Curr, sMainWord_Prev;

        while (!reader.EndOfStream)
		{
			sLineComponents = reader.ReadLine().Split(',');
            for(int i = 0; i < sLineComponents.Length; i++)
            {
                sLineComponents[i] = sLineComponents[i].Trim();
            }
            sMainWord_Curr = null;
            sMainWord_Prev = null;

            if (previousMainItem != null)
            {
                iParenLocation_Curr = sLineComponents[0].IndexOf('(');
                sMainWord_Curr = iParenLocation_Curr > 0 ? sLineComponents[0].Substring(0, iParenLocation_Curr).Trim() : sLineComponents[0];
                iParenLocation_Prev = previousMainItem.sWord.IndexOf('(');
                sMainWord_Prev = iParenLocation_Prev > 0 ? previousMainItem.sWord.Substring(0, iParenLocation_Prev).Trim() : previousMainItem.sWord;
            }

            if (sMainWord_Curr != null && sMainWord_Prev != null && sMainWord_Curr.Equals(sMainWord_Prev)) // Related Item
            {
                previousMainItem.list_RelatedItems.Add(new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]));
            }
            else if (sLineComponents[0].Contains("/")) // Use Case Item
            {
                sLineComponents[0].Replace("/", previousMainItem.sWord);
                sLineComponents[1].Replace("/", previousMainItem.sDictionaryPronunciation);
                sLineComponents[2].Replace("/", previousMainItem.sPhoneticSpelling);
                previousMainItem.list_UseCases.Add(new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]));
            }
            else // New Main Item
            {
                if(previousMainItem != null)
                {
                    _list_MainDictionaryItems.Add(previousMainItem);
                }
                previousMainItem = new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2]);
            }
		}
	}

    public void SearchForDictionaryItem(string sInput)
    {
        foreach(PhoneticDictionaryItem item in _list_MainDictionaryItems)
        {
            
        }
    }

    [System.Serializable]
    public class PhoneticDictionaryItem
    {
        public string sWord;
        public string sDictionaryPronunciation;
        public string sPhoneticSpelling;
        public List<PhoneticDictionaryItem> list_RelatedItems;
        public List<PhoneticDictionaryItem> list_UseCases;

        public PhoneticDictionaryItem(string sWord, string sDictionaryPronunciation, string sPhoneticSpelling)
        {
            this.sWord = sWord;
            this.sDictionaryPronunciation = sDictionaryPronunciation;
            this.sPhoneticSpelling = sPhoneticSpelling;

            list_RelatedItems = new List<PhoneticDictionaryItem>();
            list_UseCases = new List<PhoneticDictionaryItem>();
        }
    }
}
