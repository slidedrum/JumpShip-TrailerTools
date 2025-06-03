using System.Collections;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(TrailerTools.Core), "TrailerTools", "1.0.0", "SlideDrum", null)]
[assembly: MelonGame("KeepsakeGames", "Jump Ship")]

namespace TrailerTools
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            LoggerInstance.Msg("Loaded scene.");
            MelonCoroutines.Start(FindAndEnable("PF_TrailerTools"));
        }

        public IEnumerator FindAndEnable(string objectName)
        {
            GameObject targetObject = null;
            while (targetObject == null)
            {
                GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
                targetObject = allObjects.FirstOrDefault(obj => obj.name == objectName);

                if (targetObject != null)
                {
                        targetObject.SetActive(true);
                }
                LoggerInstance.Msg($"'{objectName}' not found, checking again in 10 seconds");
                yield return new WaitForSeconds(10f);
            }
        }
    }
}