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

    public void Start()
    {
        SetItemValuesOnRelevantFields();
    }

    private void SetItemValuesOnRelevantFields()
    {
        text_Word.text = _item.sWord;
        text_DictionaryPronunciation.text = _item.sDictionaryPronunciation;
        text_PhoneticSpelling.text = _item.sPhoneticSpelling;
    }

    public void LoadSearchView()
    {
        ViewManager.LoadView(ViewManager.VIEW_SEARCH);
    }

}
