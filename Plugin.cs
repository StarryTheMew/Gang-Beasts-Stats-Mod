using BepInEx;
using System;
using UnityEngine;
using Femur;
using GB.Networking;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

namespace GangBeast_TestMod
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GUIStyle guiStyle = new GUIStyle();
        public GUIStyle guiStyleInvis = new GUIStyle();
        bool Done = true;
        float HP;
        float Stam;
        float MaxHP;
        float MaxStam;
        float TextScaleVal = 0.75f;

        void OnGameInitialized(object sender, EventArgs e)
        {
        }

        void Update()
        {
            if (Done)
            {
                StatusHandeler[] array = (StatusHandeler[])StatusHandeler.FindObjectsOfType(typeof(StatusHandeler));
                foreach (StatusHandeler Stats in array)
                {
                    NameBarHandler[] array2 = (NameBarHandler[])NameBarHandler.FindObjectsOfType(typeof(NameBarHandler));
                    foreach (NameBarHandler StatusBar in array2)
                    {
                        StatusBar.CachedNameText.text = "HP: " + StatusBar.gameObject.GetComponentInParent<StatusHandeler>().health + "/" + StatusBar.gameObject.GetComponentInParent<StatusHandeler>().maxHealth + "\n" + "Stamina: " + StatusBar.gameObject.GetComponentInParent<StatusHandeler>().stamina + "/" + StatusBar.gameObject.GetComponentInParent<StatusHandeler>().maxStamina;
                        StatusBar.ShowName = true;
                        if (StatusBar.ShowName == false)
                        {
                            StatusBar.ShowName = true;
                        }
                        if (StatusBar.CachedNameText.text.Contains("HP: 0"))
                        {
                            StatusBar.CachedNameText.text = "-DEAD-";
                        }
                        StatusBar.transform.localScale = new Vector3(TextScaleVal,TextScaleVal,TextScaleVal);
                    }
                }
            }
        }

        private void OnGUI()
        {
            Vector3 TextOffset = new Vector3(0, TextScaleVal, 0);
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            guiStyleInvis.fontSize = 0;
            guiStyleInvis.normal.textColor = Color.clear;
            
            if (Done)
            {
                StatusHandeler[] array = (StatusHandeler[])StatusHandeler.FindObjectsOfType(typeof(StatusHandeler));
                foreach (StatusHandeler Stats in array)
                    if (Stats.isLocalPlayer)
                    {
                        HP = Stats.health;
                        Stam = Stats.stamina;
                        MaxHP = Stats.maxStamina;
                        MaxStam = Stats.maxHealth;
                    }
                GUI.Label(new Rect(5f, 45f, 120f, 60f), "HP: " + HP + "/" + MaxHP, guiStyle);
                GUI.Label(new Rect(5f, 25f, 120f, 60f), "Stamina: " + Stam + "/" + MaxStam, guiStyle);
                GUI.Label(new Rect(5f, 5f, 120f, 60f), "Created By Starry", guiStyle);
                GUI.Label(new Rect(5f, 65f, 120f, 60f), "Text Scale: " + TextScaleVal, guiStyle);
                this.TextScaleVal = GUI.HorizontalSlider(new Rect(5f, 85f, 100f, 20f), this.TextScaleVal, 0.3f, 1.3f);
            }
        }
    }
}
