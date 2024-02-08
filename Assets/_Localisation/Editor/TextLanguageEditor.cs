using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KreizTranslation
{
    [CustomEditor(typeof(TextLanguage))]
    public class TextLanguageEditor : Editor
    {
        TextLanguage myTarget;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            myTarget = (TextLanguage)target;
            if (GUILayout.Button("Translate to RU"))
            {
                myTarget.StartTranslationProcessToRU();
            }
            if (GUILayout.Button("Translate to ENG"))
            {
                myTarget.StartTranslationProcessToENG();
            }
            if (GUILayout.Button("Translate to ES"))
            {
                myTarget.StartTranslationProcessToES();
            }
            if (GUILayout.Button("Translate to DE"))
            {
                myTarget.StartTranslationProcessToDE();
            }
            if (GUILayout.Button("Translate to CN"))
            {
                myTarget.StartTranslationProcessToCN();
            }
            if (GUILayout.Button("Translate to TR"))
            {
                myTarget.StartTranslationProcessToTR();
            }
            if (GUILayout.Button("Translate to JP"))
            {
                myTarget.StartTranslationProcessToJP();
            }
            if (GUILayout.Button("Translate to ID"))
            {
                myTarget.StartTranslationProcessToID();
            }
        }
    }
}