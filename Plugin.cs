using BepInEx;
using System;
using UnityEngine;
using Femur;
using GB.Networking;
using UnityEngine;
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

        void OnGameInitialized(object sender, EventArgs e)
        {
        }

        void Update()
        {
        }

        private bool nodie = false;
        private void OnGUI()
        {
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
                    }
                GUI.Label(new Rect(5f, 45f, 120f, 60f), "HP: " + HP, guiStyle);
                GUI.Label(new Rect(5f, 25f, 120f, 60f), "Stamina: " + Stam, guiStyle);
                GUI.Label(new Rect(5f, 5f, 120f, 60f), "Created By Starry", guiStyle);
            }
        }
    }
}
