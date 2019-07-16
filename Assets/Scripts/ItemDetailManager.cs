using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDetailManager : MonoBehaviour
{
    public Text text_Word;
    public Text text_DictionaryPronunciation;
    public Text text_PhoneticSpelling;

    private PhoneticDictionary.PhoneticDictionaryItem _item;

    public void Awake()
    {
        _item = ViewManager.Arguments["item"] as PhoneticDictionary.PhoneticDictionaryItem;
    }

}
