using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class typewriterUI : MonoBehaviour
{
	[SerializeField]TMP_Text _tmpProText;
	public string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;
	Coroutine typing;

    private void Start()
    {
		Write();
    }

    // Use this for initialization
    public void Write()
	{
		if (typing != null)
        {
            StopCoroutine(typing);
            typing = null;
        }
		_tmpProText.text = "";
		typing = StartCoroutine("TypeWriterTMP");
	}



	IEnumerator OLDTypeWriterTMP()
    {
		
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
			}
			_tmpProText.text += c;
			_tmpProText.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
	}

    IEnumerator TypeWriterTMP()
    {
        bool specialChar=false;
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
        char[] write = writer.ToCharArray();
        yield return new WaitForSeconds(delayBeforeStart);
        for(int i =0; i <= write.Length-1; i++)
        {
            //if (_tmpProText.text.Length > 0)
            //{
            //    _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            //}
            if (specialChar) { specialChar = false; continue; }
            if (write[i].ToString()==@"\")
            {
                switch (write[i].ToString() + write[i + 1].ToString()) 
                {
                    case @"\n":
                        _tmpProText.text += "\n";
                        break;
                    case @"\\":
                        _tmpProText.text += "\\";
                        break;
                    case @"\r":
                        _tmpProText.text += "\r";
                        break;
                    case @"\t":
                        _tmpProText.text += "\t";
                        break;
                    case "\"":
                        _tmpProText.text += "\"";
                        break;
                    case @"\'":
                        _tmpProText.text += "\'";
                        break;
                }
                specialChar = true;
                continue;
            }
            _tmpProText.text += write[i];
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
}
