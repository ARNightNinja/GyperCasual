#if UNITY_WEBGL
using InstantGamesBridge;
#endif

using UnityEngine;

namespace KreizTranslation
{
    public class LanguageManager : MonoBehaviour
    {
#if UNITY_WEBGL
        public const string DEFAULT_LANG = "RU";
#else
        public const string DEFAULT_LANG = "ENG";
#endif
        public static LanguageManager Instance;
        public delegate void OnChangeLang();
        public OnChangeLang onChangeLang;

        public TMPro.TMP_FontAsset _RU_Font;
        public TMPro.TMP_FontAsset _ENG_Font;
        public TMPro.TMP_FontAsset _CN_Font;
        public Font _RU_Legacy_Font;
        public Font _ENG_Legacy_Font;
        public Font _CN_Legacy_Font;
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                return;

            if (!PlayerPrefs.HasKey("Language"))
            {
#if UNITY_WEBGL
                if (Bridge.platform.language == "ru")
                {
                    ChangeLanguageToRU();
                    return;
                }
                else if (Bridge.platform.language == "en")
                {
                    ChangeLanguageToENG();
                    return;
                }
                else if (Bridge.platform.language == "zh")
                {
                    ChangeLanguageToCN();
                    return;
                }
                else if (Bridge.platform.language == "tr")
                {
                    ChangeLanguageToTR();
                    return;
                }
                else if (Bridge.platform.language == "ja")
                {
                    ChangeLanguageToJP();
                    return;
                }
                else if (Bridge.platform.language == "de")
                {
                    ChangeLanguageToDE();
                    return;
                }
                else if (Bridge.platform.language == "es")
                {
                    ChangeLanguageToES();
                    return;
                }
                else if (Bridge.platform.language == "id")
                {
                    ChangeLanguageToID();
                    return;
                }
#endif
                if (Application.systemLanguage == SystemLanguage.Russian)
                {
                    ChangeLanguageToRU();
                }
                else if (Application.systemLanguage == SystemLanguage.English)
                {
                    ChangeLanguageToENG();
                }
                else if (Application.systemLanguage == SystemLanguage.Spanish)
                {
                    ChangeLanguageToES();
                }
                else if (Application.systemLanguage == SystemLanguage.German)
                {
                    ChangeLanguageToDE();
                }
                else if (Application.systemLanguage == SystemLanguage.Turkish)
                {
                    ChangeLanguageToTR();
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    ChangeLanguageToJP();
                }
                else if (Application.systemLanguage == SystemLanguage.ChineseSimplified ||
                    Application.systemLanguage == SystemLanguage.ChineseTraditional ||
                    Application.systemLanguage == SystemLanguage.Chinese)
                {
                    ChangeLanguageToCN();
                }
                else if (Application.systemLanguage == SystemLanguage.Indonesian)
                {
                    ChangeLanguageToID();
                }
                else
                {
                    if(DEFAULT_LANG == "RU")
                    {
                        ChangeLanguageToRU();
                    }
                    else if (DEFAULT_LANG == "CN")
                    {
                        ChangeLanguageToCN();
                    }
                    else
                    {
                        ChangeLanguageToENG();
                    }
                }
            }
        }
        public void ChangeLanguageToRU()
        {
            PlayerPrefs.SetString("Language", "RU");

            RefreshAll();
        }
        public void ChangeLanguageToENG()
        {
            PlayerPrefs.SetString("Language", "ENG");

            RefreshAll();
        }
        public void ChangeLanguageToES()
        {
            PlayerPrefs.SetString("Language", "ES");

            RefreshAll();
        }
        public void ChangeLanguageToDE()
        {
            PlayerPrefs.SetString("Language", "DE");

            RefreshAll();
        }
        public void ChangeLanguageToCN()
        {
            PlayerPrefs.SetString("Language", "CN");

            RefreshAll();
        }
        public void ChangeLanguageToTR()
        {
            PlayerPrefs.SetString("Language", "TR");

            RefreshAll();
        }
        public void ChangeLanguageToJP()
        {
            PlayerPrefs.SetString("Language", "JP");

            RefreshAll();
        }
        public void ChangeLanguageToID()
        {
            PlayerPrefs.SetString("Language", "ID");;

            RefreshAll();
        }
        void RefreshAll()
        {
            TextLanguage[] texts = FindObjectsOfType<TextLanguage>();
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].RefreshText();
            }

            ImageLanguage[] imgs = FindObjectsOfType<ImageLanguage>();
            for (int i = 0; i < imgs.Length; i++)
            {
                imgs[i].RefreshImage();
            }

            LanguagePickPanel lpp = FindObjectOfType<LanguagePickPanel>();
            if (lpp != null) lpp.HidePanel();
            onChangeLang?.Invoke();
        }
        public static bool IsRussian()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "RU");
        }
        public static bool IsEnglish()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "ENG");
        }
        public static bool IsChinese()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "CN");
        }
        public static bool IsTurkish()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "TR");
        }
        public static bool IsJapanese()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "JP");
        }
        public static bool IsSpanish()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "ES");
        }
        public static bool IsGerman()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "DE");
        }
        public static bool IsIndonesian()
        {
            return (PlayerPrefs.GetString("Language", DEFAULT_LANG) == "ID");
        }
        public static string GetLanguage()
        {
            return PlayerPrefs.GetString("Language", DEFAULT_LANG);
        }
    }
}