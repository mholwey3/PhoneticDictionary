using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PhoneticDictionary : MonoBehaviour
{
	private const string _FILE_PATH = "./Assets/Data/PHONETIC_DICTIONARY_BASE_A.csv";

    /// <summary>
    /// Gets the dictionary item associated with the given word.
    /// </summary>
    /// <param name="sWordToFind"></param>
	public PhoneticDictionaryItem GetDictionaryItem(string sWordToFind)
	{
		StreamReader reader = new StreamReader(File.OpenRead(_FILE_PATH));
        PhoneticDictionaryItem item = null;
        string[] sLineComponents;
        int iParenLocation_Curr;
        string sMainWord_Curr;

        sWordToFind = sWordToFind.ToLower();

        while (!reader.EndOfStream)
		{
			sLineComponents = reader.ReadLine().Split(',');
            for(int i = 0; i < sLineComponents.Length; i++)
            {
                sLineComponents[i] = sLineComponents[i].Trim().ToLower();
            }
            sMainWord_Curr = null;
            iParenLocation_Curr = sLineComponents[0].IndexOf('(');
            sMainWord_Curr = iParenLocation_Curr > 0 ? sLineComponents[0].Substring(0, iParenLocation_Curr).Trim() : sLineComponents[0];

            if (sWordToFind.Equals(sMainWord_Curr))
            {
                if(item == null)
                {
                    item = new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], true);
                }
                else
                {
                    item.list_RelatedItems.Add(new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], false));
                }
            }
            else if (sLineComponents[0].Contains("/")) // Use Case Item
            {
                sLineComponents[0].Replace("/", item.sWord);
                sLineComponents[1].Replace("/", item.sDictionaryPronunciation);
                sLineComponents[2].Replace("/", item.sPhoneticSpelling);
                item.list_UseCases.Add(new PhoneticDictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], false));
            }
            else
            {
                if(item != null)
                {
                    break;
                }
            }
		}

        return item;
	}
    
    public class PhoneticDictionaryItem
    {
        public string sWord;
        public string sDictionaryPronunciation;
        public string sPhoneticSpelling;
        public List<PhoneticDictionaryItem> list_RelatedItems;
        public List<PhoneticDictionaryItem> list_UseCases;

        public PhoneticDictionaryItem(string sWord, string sDictionaryPronunciation, string sPhoneticSpelling, bool bIsMainItem)
        {
            this.sWord = sWord;
            this.sDictionaryPronunciation = sDictionaryPronunciation;
            this.sPhoneticSpelling = sPhoneticSpelling;

            if (bIsMainItem)
            {
                list_RelatedItems = new List<PhoneticDictionaryItem>();
                list_UseCases = new List<PhoneticDictionaryItem>();
            }
        }
    }
}
