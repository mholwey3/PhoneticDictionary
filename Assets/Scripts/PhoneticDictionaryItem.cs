public class PhoneticDictionaryItem
{
	private string _sWord;
	public string Word
	{
		get
		{
			return _sWord;
		}
	}

	private string _sDictionaryPronunciation;
	public string DictionaryPronuncitation
	{
		get
		{
			return _sDictionaryPronunciation;
		}
	}

	private string _sPhoneticSpelling;
	public string PhoneticSpelling
	{
		get
		{
			return _sPhoneticSpelling;
		}
	}

	public PhoneticDictionaryItem(string sWord, string sDictionaryPronunciation, string sPhoneticSpelling)
	{
		_sWord = sWord;
		_sDictionaryPronunciation = sDictionaryPronunciation;
		_sPhoneticSpelling = sPhoneticSpelling;
	}
}
