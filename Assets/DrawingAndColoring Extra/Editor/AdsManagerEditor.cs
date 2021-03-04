﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using IndieStudio.DrawingAndColoring.Utility;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.DCEditor
{
    [CustomEditor(typeof(AdsManagerDrawing))]
    public class AdsManagerEditor : Editor
    {
        public int selectedPackage;
        private static bool showInstructions = true;
        private static string[] Packages = null;
        private static string[] downloadURlS = new string[] {
            "https://github.com/googleads/googleads-mobile-unity/releases",
            "http://www.chartboo.st/sdk/unity",
            "https://assetstore.unity.com/packages/add-ons/services/unity-ads-66123"
        };
        private static string[] moreDetails = new string[] {
            "https://firebase.google.com/docs/admob/unity/start",
            "https://answers.chartboost.com/en-us/child_article/unity",
            "https://unity3d.com/services/ads/quick-start-guide"
        };

        private static string[] labels = new string[]{
            "GOOGLE MOBILE ADS",
            "CHARTBOOST",
            "UNITY ADS"
        };

        public override void OnInspectorGUI()
        {
            if (Application.isPlaying)
            {
                return;
            }

#if !(UNITY_ANDROID || UNITY_IPHONE)
				EditorGUILayout.Separator ();
				EditorGUILayout.HelpBox ("You need to switch to mobile platform (Android or IOS) to setup Ads", MessageType.Warning);
#else
            AdsManagerDrawing attrib = (AdsManagerDrawing)target;//get the target
            if (Packages == null)
            {
                selectedPackage = 0;
                System.Array packagesEnum = System.Enum.GetValues(typeof(AdPackageDrawing.Package));
                if (packagesEnum.Length == 0)
                {
                    return;
                }

                Packages = new string[packagesEnum.Length];
                for (int i = 0; i < packagesEnum.Length; i++)
                {
                    Packages[i] = packagesEnum.GetValue(i).ToString();
                }
            }

            EditorGUILayout.Separator();
            selectedPackage = GUILayout.Toolbar(selectedPackage, Packages);
            EditorGUILayout.Separator();

            for (int i = 0; i < attrib.adPackages.Count; i++)
            {
                if (selectedPackage != i)
                {
                    continue;
                }

                ShowInstruction(attrib.adPackages[i].package);

                EditorGUILayout.Separator();
                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = Colors.greenColor;
                if (GUILayout.Button("Download " + labels[selectedPackage], GUILayout.Width(200), GUILayout.Height(20)))
                {
                    Application.OpenURL(downloadURlS[i]);
                }
                GUI.backgroundColor = Colors.whiteColor;

                GUI.backgroundColor = Colors.cyanColor;
                if (GUILayout.Button("More Details About " + Packages[selectedPackage], GUILayout.Width(220), GUILayout.Height(20)))
                {
                    Application.OpenURL(moreDetails[i]);
                }
                GUI.backgroundColor = Colors.whiteColor;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Separator();
                attrib.adPackages[i].isEnabled = EditorGUILayout.Toggle("Enable " + Packages[selectedPackage] + " ADS", attrib.adPackages[i].isEnabled);
                EditorGUILayout.Separator();

                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Event");
                GUILayout.Space(40);
                GUILayout.Label("Ad Type");
                GUILayout.Space(20);
                GUILayout.Label("Ad Position");
                GUILayout.Label("Active");

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Separator();
                foreach (AdPackageDrawing.AdEvent adEvent in attrib.adPackages[i].adEvents)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.EnumPopup(adEvent.evt);
                    EditorGUI.BeginDisabledGroup(attrib.adPackages[i].package == AdPackageDrawing.Package.UNITY);
                    adEvent.type = (AdPackageDrawing.AdEvent.Type)EditorGUILayout.EnumPopup(adEvent.type);
                    if (adEvent.type == AdPackageDrawing.AdEvent.Type.BANNER && attrib.adPackages[i].package == AdPackageDrawing.Package.CHARTBOOST)
                    {
                        adEvent.type = AdPackageDrawing.AdEvent.Type.INTERSTITIAL;
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUI.BeginDisabledGroup(adEvent.type != AdPackageDrawing.AdEvent.Type.BANNER || attrib.adPackages[i].package == AdPackageDrawing.Package.CHARTBOOST || attrib.adPackages[i].package == AdPackageDrawing.Package.UNITY);
#if GOOGLE_MOBILE_ADS
						adEvent.adPostion = (GoogleMobileAds.Api.AdPosition)EditorGUILayout.EnumPopup (adEvent.adPostion);
#endif
                    EditorGUI.EndDisabledGroup();

                    adEvent.isEnabled = EditorGUILayout.Toggle(adEvent.isEnabled);
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.Separator();

            if (GUI.changed)
            {
                DirtyUtil.MarkSceneDirty();
            }
#endif
        }


        private void ShowInstruction(AdPackageDrawing.Package package)
        {
            EditorGUILayout.Separator();
            EditorGUILayout.HelpBox("Follow the instructions below on how to enable the " + Packages[selectedPackage] + " Advertisements", MessageType.Info);
            EditorGUILayout.Separator();
            showInstructions = EditorGUILayout.Foldout(showInstructions, "Instructions");
            EditorGUILayout.Separator();

            if (!showInstructions)
            {
                return;
            }

            EditorGUILayout.BeginHorizontal();
            ShowReadManual();
            ShowContactUS();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            if (package == AdPackageDrawing.Package.ADMOB)
            {
                ShowAdmobInstructions();
            }
            else if (package == AdPackageDrawing.Package.CHARTBOOST)
            {
                ShowChartBoostInstructions();
            }
            else if (package == AdPackageDrawing.Package.UNITY)
            {
                ShowUnityAdsInstructions();
            }
            ShowCommonInstructions();

            EditorGUILayout.Separator();
        }

        private void ShowReadManual()
        {
            GUI.backgroundColor = Colors.yellowColor;
            if (GUILayout.Button("Read the Manual", GUILayout.Width(120), GUILayout.Height(20)))
            {
                Application.OpenURL(Links.docPath);
            }
            GUI.backgroundColor = Colors.whiteColor;
        }

        private void ShowContactUS()
        {
            GUI.backgroundColor = Colors.greenColor;
            if (GUILayout.Button("Contact US", GUILayout.Width(100), GUILayout.Height(20)))
            {
                Application.OpenURL(Links.indieStudioContactUsURL);
            }
            GUI.backgroundColor = Colors.whiteColor;
        }

        private void ShowCommonInstructions()
        {
            EditorGUILayout.Separator();
            EditorGUILayout.HelpBox("* If you any questions , suggestions or problems you can contact us", MessageType.None);
            EditorGUILayout.Separator();
        }

        private void ShowAdmobInstructions()
        {
            EditorGUILayout.HelpBox("1. Download Admob package, and then import it to your project", MessageType.None);
            EditorGUILayout.HelpBox("2. Insert your App Id, Admob UnitID in the Ad Mob component below", MessageType.None);
            EditorGUILayout.HelpBox("3. Modify the attributes below as you wish", MessageType.None);
            EditorGUILayout.HelpBox("4. Click on Apply button that located on the top to save your changes", MessageType.None);
        }

        private void ShowChartBoostInstructions()
        {
            EditorGUILayout.HelpBox("1. Download ChartBoost package, and then import it to your project", MessageType.None);
            EditorGUILayout.HelpBox("2. Insert your ChartBoost AppID & App Signiture using ChartBoost->Edit Settings", MessageType.None);
            EditorGUILayout.HelpBox("3. Modify the attributes below as you wish", MessageType.None);
            EditorGUILayout.HelpBox("4. Click on Apply button that located on the top to save your changes", MessageType.None);
        }

        private void ShowUnityAdsInstructions()
        {
            EditorGUILayout.HelpBox("1. Download Unity Ads package from the Unity Asset Store, and then import it to your project", MessageType.None);
            EditorGUILayout.HelpBox("2. Insert your Unity Game IDs in the Unity Ad component below", MessageType.None);
            EditorGUILayout.HelpBox("3. Enable 'Test Mode' in the Unity Ad component  to test the Unity Ads", MessageType.None);
            EditorGUILayout.HelpBox("4. Modify the attributes below as you wish", MessageType.None);
            EditorGUILayout.HelpBox("5. Once you want to release or publish your app, set 'Test Mode' to false", MessageType.None);
            EditorGUILayout.HelpBox("6. Click on Apply button that located on the top to save your changes", MessageType.None);
        }
    }
}