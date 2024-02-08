using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;

namespace KreizTranslation
{
    public class TextLanguage : MonoBehaviour
    {
        [SerializeField, TextArea] public string _textRU = "";
        [SerializeField, TextArea] public string _textENG = "";
        [SerializeField, TextArea] public string _textES = "";
        [SerializeField, TextArea] public string _textDE = "";
        [SerializeField, TextArea] public string _textCN = "";
        [SerializeField, TextArea] public string _textTR = "";
        [SerializeField, TextArea] public string _textJP = "";
        [SerializeField, TextArea] public string _textID = "";
        string curTextLang = "-";
        // Start is called before the first frame update
        void Start()
        {
            RefreshText();
        }
        private void OnEnable()
        {
            if(LanguageManager.Instance)
                RefreshText();
            //LanguageManager.Instance.onChangeLang += RefreshText;
        }
        private void OnDisable()
        {
            //LanguageManager.Instance.onChangeLang -= RefreshText;
        }
        public void RefreshText()
        {
            string langStr = LanguageManager.GetLanguage();
            if (langStr == curTextLang) return;

            //Debug.Log("RefreshText: new lang:" + langStr + " ", gameObject);
            if (langStr == "RU")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._RU_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._RU_Legacy_Font;
                }
                ChangeTextTo(_textRU);
            }
            else if (langStr == "ENG")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._ENG_Legacy_Font;
                }
                ChangeTextTo(_textENG);
            }
            else if (langStr == "ES")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._ENG_Legacy_Font;
                }
                ChangeTextTo(_textES);
            }
            else if (langStr == "DE")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._ENG_Legacy_Font;
                }
                ChangeTextTo(_textDE);
            }
            else if (langStr == "CN")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._CN_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._CN_Legacy_Font;
                }
                ChangeTextTo(_textCN);

               /* if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    //tmpCtext.font = LanguageManager.Instance._CN_Font;
                    if (_FONTProcessing != null)
                        StopCoroutine(_FONTProcessing);
                    _FONTProcessing = StartCoroutine(DelayedRefreshToUIFont(LanguageManager.Instance._CN_Legacy_Font, _textCN));
                    return;
                }
                ChangeTextTo(_textCN);*/
            }
            else if (langStr == "TR")
            {

                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._ENG_Legacy_Font;
                }
                ChangeTextTo(_textTR);
            }
            else if (langStr == "JP")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._CN_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._CN_Legacy_Font;
                }
                ChangeTextTo(_textJP);

                /*if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    if (_FONTProcessing != null)
                        StopCoroutine(_FONTProcessing);
                    _FONTProcessing = StartCoroutine(DelayedRefreshToUIFont(LanguageManager.Instance._CN_Legacy_Font, _textJP));
                    return;
                }
                ChangeTextTo(_textJP);*/
            }
            else if (langStr == "ID")
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                else if (TryGetComponent<Text>(out Text legacyCtext) && LanguageManager.Instance)
                {
                    legacyCtext.font = LanguageManager.Instance._ENG_Legacy_Font;
                }
                ChangeTextTo(_textID);
            }
            else
            {
                if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext) && LanguageManager.Instance)
                {
                    tmpCtext.font = LanguageManager.Instance._ENG_Font;
                }
                ChangeTextTo(_textENG);
            }
        }
        Coroutine _FONTProcessing;
        bool isInRefreshFONT = false;
        IEnumerator DelayedRefreshToUIFont(Font newFont, string newText)
        {
            if (isInRefreshFONT) yield break;
            yield return null;
            isInRefreshFONT = true;
            float maxSize = 50;
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                //tmpCtext.font = LanguageManager.Instance._CN_Font;
                maxSize = tmpCtext.fontSizeMax*1.25f;
                Destroy(tmpCtext);
                /*if (TryGetComponent<Doozy.Runtime.Reactor.Targets.TextMeshProColorTarget>(out Doozy.Runtime.Reactor.Targets.TextMeshProColorTarget tmpTarget))
                {
                    Destroy(tmpTarget);
                }*/
            }
            yield return null;
            Text legacyText = gameObject.AddComponent<Text>();
            legacyText.alignment = TextAnchor.MiddleCenter;
            legacyText.resizeTextForBestFit = true;
            legacyText.resizeTextMaxSize = (int)maxSize;
            legacyText.font = newFont;
            ChangeTextTo(newText);
            _FONTProcessing = null;
        }
        void ChangeTextTo(string _text)
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                tmpCtext.text = _text; 
            }
            if (TryGetComponent<Text>(out Text uiCtext))
            {
                uiCtext.text = _text;
            }
        }
        public void FirstSetup()
        {
            string mainText = GetDefaultText();
            _textENG = mainText;
            if (mainText.Length == 0)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    DestroyImmediate(this);
#else
            Destroy(this);
#endif
            }
            int digits = 0;
            int letters = 0;
            int specials = 0;
            for (int i = 0; i < mainText.Length; i++)
            {
                //string _checkSymbol = mainText[i].ToString();
                char _checkChar = mainText[i];
                if (Char.IsDigit(_checkChar))
                {
                    digits++;
                }
                else if (Char.IsLetter(_checkChar))
                {
                    letters++;
                }
                else
                {
                    specials++;
                }
            }
            if (letters == 0)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    DestroyImmediate(this);
#else
            Destroy(this);
#endif
            }
        }
        public string GetDefaultText()
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                if (tmpCtext.text.Length == 0)
                {
                    if (_textENG.Length!=0)
                        return _textENG;
                    if (_textCN.Length != 0)
                        return _textCN;
                    if (_textRU.Length != 0)
                        return _textRU;
                }
                return tmpCtext.text.Trim('\n');
            }
            if (TryGetComponent<Text>(out Text uiCtext))
            {
                if (uiCtext.text.Length == 0)
                {
                    if (_textENG.Length != 0)
                        return _textENG;
                    if (_textCN.Length != 0)
                        return _textCN;
                    if (_textRU.Length != 0)
                        return _textRU;
                }
                return uiCtext.text.Trim('\n');
            }

            return "";
        }
        public void SetTralsationENG(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textENG = newText;
        }
        public void SetTralsationES(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textES = newText;
        }
        public void SetTralsationDE(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textDE = newText;
        }
        public void SetTralsationID(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textID = newText;
        }
        public void SetTralsationRU(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textRU = newText;
        }
        public void SetTralsationCN(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textCN = newText;
        }
        public void SetTralsationTR(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textTR = newText;
        }
        public void SetTralsationJP(string newText)
        {
            if (newText.Length == 0) return;
            translated = true;
            _textJP = newText;
        }
        [SerializeField] bool translated = false;
        public bool IsTranslated()
        {
            if (_textRU.Length == 0) return false;
            if (_textENG.Length == 0) return false;
            if (_textCN.Length == 0) return false;
            int diff1 = Mathf.Abs(_textRU.Length - _textENG.Length);
            int diff2 = Mathf.Abs(_textRU.Length - _textCN.Length);
            if ((float)diff1 / (float)Mathf.Max(_textRU.Length, _textENG.Length) < 0.5f
                && (float)diff2 / (float)Mathf.Max(_textRU.Length, _textCN.Length) < 0.8f )
            {
                return true;
            }
            return translated;
        }
        public void UpdateFont(TMP_FontAsset font)
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                tmpCtext.font = font;
            }
        }
        public void DisplayRU()
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                tmpCtext.text = _textRU;
            }
            else if (TryGetComponent<Text>(out Text uiCtext))
            {
                uiCtext.text = _textRU;
            }
        }
        public void DisplayENG()
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                tmpCtext.text = _textENG;
            }
            else if (TryGetComponent<Text>(out Text uiCtext))
            {
                uiCtext.text = _textRU;
            }
        }
        public void DisplayCN()
        {
            if (TryGetComponent<TMP_Text>(out TMP_Text tmpCtext))
            {
                tmpCtext.text = _textCN;
            }
            else if (TryGetComponent<Text>(out Text uiCtext))
            {
                uiCtext.text = _textCN;
            }
        }
        public void StartTranslationProcessToENG()
        {
            string textToTranslate = _textRU;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "en"));
        }
        public void StartTranslationProcessToRU()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "ru"));
        }
        public void StartTranslationProcessToCN()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "zh-CN")); //zh-TW
        }
        public void StartTranslationProcessToTR()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "tr"));
        }
        public void StartTranslationProcessToJP()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "ja"));
        }
        public void StartTranslationProcessToES()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "es"));
        }
        public void StartTranslationProcessToDE()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "de"));
        }
        public void StartTranslationProcessToID()
        {
            string textToTranslate = _textENG;
            if (textToTranslate.Length == 0)
                textToTranslate = GetDefaultText();
            StartCoroutine(Translation(textToTranslate, "id"));
        }
        public IEnumerator Translation(string sourceText, string targetLang)
        {
            //sourceText = sourceText.Replace('!', '|');
            string sourceLang = "auto";
            // Construct the url using our variables and googles api.
            string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl="
                + sourceLang + "&tl=" + targetLang + "&dt=t&q=" + WWW.EscapeURL(sourceText);

            WWW www = new WWW(url);
            yield return www;
            if (www.isDone)
            {
                //Debug.Log("Got ans");
                if (string.IsNullOrEmpty(www.error))
                {
                    string translatedString = www.text;

                    Debug.Log("Text was::::" + sourceText + " \n Transalted::::" + translatedString);

                    translatedString = translatedString.Substring(4);

                    if (targetLang == "ru")
                        SetTralsationRU(FixString(translatedString));
                    else if (targetLang == "en")
                        SetTralsationENG(FixString(translatedString));
                    else if (targetLang == "zh-CN")
                        SetTralsationCN(FixString(translatedString));
                    else if (targetLang == "tr")
                        SetTralsationTR(FixString(translatedString));
                    else if (targetLang == "ja")
                        SetTralsationJP(FixString(translatedString));
                    else if (targetLang == "es")
                        SetTralsationES(FixString(translatedString));
                    else if (targetLang == "de")
                        SetTralsationDE(FixString(translatedString));
                    else if (targetLang == "id")
                        SetTralsationID(FixString(translatedString));
#if UNITY_EDITOR
                    EditorUtility.SetDirty(this);
#endif
                }
                else
                {
                    Debug.Log("ERROR:" + www.error);
                    Debug.LogError("ERROR:" + www.error);
                }
            }
        }
        string FixString(string strToFix)
        {
            if (!strToFix.Contains("\\n\",\""))
            {
                return FixStringFinal(strToFix);
            }
            else
            {
                string newFixedStr = "";
                string[] translaters = strToFix.Split("\\n\",\"");
                for (int i = 0; i < translaters.Length; i++)
                {
                    string[] data = translaters[i].Split(",[\"");

                    for (int k = 0; k < data.Length; k += 2)
                    {
                        newFixedStr = data[k];
                    }
                }
                strToFix = FixStringFinal(newFixedStr);
            }
            return strToFix;
        }
        string FixStringFinal(string strToFix)
        {
            if (!strToFix.Contains("\",\""))
            {
                return strToFix;
            }
            else
            {
                string[] translaters = strToFix.Split("\",\"");
                strToFix = translaters[0];
            }

            return strToFix;
        }

        const string SplitSimbolToFile = "|";
        public string GetAllLanguagesStringToFile()
        {
            string toReturn = _textRU.Trim('\n') + SplitSimbolToFile +
                _textENG.Trim('\n') + SplitSimbolToFile +
                _textCN.Trim('\n');
            return toReturn;
        }
    }
}