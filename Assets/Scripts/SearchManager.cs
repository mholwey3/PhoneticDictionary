﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{
    public InputField inputField_Search;

    private Hashtable _arguments;
    private PhoneticDictionary _phoneticDictionary;
    private PhoneticDictionary.PhoneticDictionaryItem _item;

    public void Awake()
    {
        _arguments = new Hashtable();
        _phoneticDictionary = new PhoneticDictionary();
    }

	public void Start()
    {
        inputField_Search.onEndEdit.AddListener(SubmitSearch);
    }

    private void SubmitSearch(string sWord)
    {
        _item = _phoneticDictionary.GetDictionaryItem(sWord);

        _arguments.Clear();
        _arguments.Add("item", _item);

        ViewManager.LoadScene(ViewManager.VIEW_ITEM_DISPLAY, _arguments);
    }
}
