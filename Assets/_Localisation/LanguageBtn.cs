using UnityEngine;

namespace KreizTranslation
{
    public class LanguageBtn : MonoBehaviour
    {
        [SerializeField] bool SetRU;
        [SerializeField] bool SetENG;
        [SerializeField] bool SetES;
        [SerializeField] bool SetDE;
        [SerializeField] bool SetCN;
        [SerializeField] bool SetTR;
        [SerializeField] bool SetJP;
        [SerializeField] bool SetID;
        public void OnClick_SetLanguage()
        {
            if (LanguageManager.Instance == null) return;

            if(SetRU)
            {
                LanguageManager.Instance.ChangeLanguageToRU();
            }
            else if (SetENG)
            {
                LanguageManager.Instance.ChangeLanguageToENG();
            }
            else if (SetES)
            {
                LanguageManager.Instance.ChangeLanguageToES();
            }
            else if (SetDE)
            {
                LanguageManager.Instance.ChangeLanguageToDE();
            }
            else if (SetCN)
            {
                LanguageManager.Instance.ChangeLanguageToCN();
            }
            else if (SetTR)
            {
                LanguageManager.Instance.ChangeLanguageToTR();
            }
            else if (SetJP)
            {
                LanguageManager.Instance.ChangeLanguageToJP();
            }
            else if (SetID)
            {
                LanguageManager.Instance.ChangeLanguageToID();
            }
        }
    }
}