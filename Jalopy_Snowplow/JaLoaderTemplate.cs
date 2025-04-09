using JaLoader;
using System.Collections.Generic;
using UnityEngine;

namespace Jalopy_Snowplow
{
    /// <summary>
    /// The wiki is your best friend. Check it out here: https://github.com/theLeaxx/JaLoader/wiki
    /// You can also find a version of this template without any comments on the wiki.
    /// Highly recommended to check out the wiki before starting to code.
    /// Also suggest checking out the Order Of Execution page, to understand the order in which functions are called (https://github.com/theLeaxx/JaLoader/wiki/Order-of-Execution).
    /// </summary>
    public class Jalopy_Snowplow : Mod
    {
        /// <summary>
        /// The mod's ID. Try making it as unique as possible, to avoid conflicting IDs.
        /// </summary>
        public override string ModID => "Snowplow";

        /// <summary>
        /// The mod's name. This is shown in the mods list. Does not need to be unique.
        /// </summary>
        public override string ModName => "Snowplow";

        /// <summary>
        /// The mod's author (you). Also shown in the mods list.
        /// </summary>
        public override string ModAuthor => "Liebeg";

        /// <summary>
        /// The mod's description. This is also shown in the mods list, upon clicking on "More Info".
        /// </summary>
        public override string ModDescription => "Snowplow for your Car.";

        /// <summary>
        /// The mod's version. Also shown in the mods list. 
        /// If your mod is open-source on GitHub, make sure that you're using the same format as your release tags (for example, 1.0.0)
        /// For more information, check out the wiki page on versioning. (https://github.com/theLeaxx/JaLoader/wiki/Versioning-your-mod)
        /// </summary>
        public override string ModVersion => "1.1.0";

        /// <summary>
        /// If your mod is open-source on GitHub, you can link it here to allow for automatic update-checking in-game.
        /// It compares the current ModVersion with the tag of the latest release (ex. 1.0.0 compared with 1.0.1)
        /// For more information, check out the wiki page on versioning. (https://github.com/theLeaxx/JaLoader/wiki/Versioning-your-mod)
        /// </summary>
        public override string GitHubLink => "https://github.com/Liebeg/Jalopy_Snowplow";

        /// <summary>
        /// When to initialize the mod.
        /// InGame: When the game is loaded, stops functioning in the main menu.
        /// InMenu: When the main menu is loaded, continues to function in-game too.
        /// </summary>
        public override WhenToInit WhenToInit => WhenToInit.InGame;

        /// <summary>
        /// If you mod depends on a certain version of JaLoader, or another mod, you can specify it here. 
        /// The format is (ModID, ModAuthor, ModVersion), and for JaLoader it's ("JaLoader", "Leaxx", {version}).
        /// Versions are usually formatted in the (x.y.z) format (for example, 1.2.0), although certain mods may follow other formats.
        /// Enable Debug Mode in JaLoader settings to view ModIDs instead of ModNames in the mod list.
        /// If you don't have any dependencies, you can just return an empty list.
        /// For more information, check out the wiki page on dependencies. (https://github.com/theLeaxx/JaLoader/wiki/Using-dependencies)
        /// </summary>
        public override List<(string, string, string)> Dependencies => new List<(string, string, string)>()
        {
        };

        /// <summary>
        /// If your mod uses custom assets, you need to set this to true.
        /// In other words, if your mod uses the "LoadAsset>T>" function, you need to set this to true.
        /// For more information, check out the wiki page on custom assets. (https://github.com/theLeaxx/JaLoader/wiki/Using-custom-assets)
        /// </summary>
        public override bool UseAssets => true;
        private GameObject snowplow;
        private GameObject snowPlowCar;

        /// <summary>
        /// Declare all of your events here.
        /// Events are used to call functions when certain things happen in-game.
        /// They are held by the script "EventsManager". You can use "EventsManager.Instance.{event} += FunctionName()" to subscribe to them.
        /// For more information, check out the wiki page on events. (https://github.com/theLeaxx/JaLoader/wiki/Using-events)
        /// </summary>
        public override void EventsDeclaration()
        {
            base.EventsDeclaration();
        }

        /// <summary>
        /// Declare all of your settings here.
        /// Make sure to call "InstantiateSettings()" in here before declaring your settings.
        /// For more information, check out the wiki page on settings. (https://github.com/theLeaxx/JaLoader/wiki/Adding-settings-for-mods)
        /// </summary>
        public override void SettingsDeclaration()
        {
            base.SettingsDeclaration();
            InstantiateSettings();
            AddToggle("Snowplowup", "Raise up the plowing attachment", true);
        }

        /// <summary>
        /// Register all of your custom objects here.
        /// Custom objects are objects that are not part of the game's default objects, but act like them.
        /// Basically, if you want to add a new object to the game that can be picked up/placed/etc, you need to register it here.
        /// For more information, check out the wiki page on custom objects. (https://github.com/theLeaxx/JaLoader/wiki/Using-Custom-Objects)
        /// </summary>
        public override void CustomObjectsRegistration()
        {

            {
                base.CustomObjectsRegistration();

                snowplow = LoadAsset<GameObject>("snowplow", "snowplow", "", ".fbx");
                snowplow = Instantiate(snowplow, ModHelper.Instance.laika.transform.Find("TweenHolder/Frame"));
                //snowplow.transform.localPosition = new Vector3(0.372f, -5.799f, -2);
                snowplow.transform.localPosition = new Vector3(8.641f, -4.683f, -2);
                snowplow.transform.localScale = new Vector3(100, 100, 100);
                snowplow.transform.localEulerAngles = new Vector3(329.91f, 89.2928f, 0);


                // ModHelper.Instance.CreateIconForExtra(snowplow, new Vector3(), new Vector3(0.5f, 0.5f, 0.5f), new Vector3(180, 60, 200), "snowplow");
                ModHelper.Instance.CreateIconForExtra(snowplow, new Vector3(-1.160f, 1.113f, 4.99f), new Vector3(20.310f, -3.53f, -9.67f), new Vector3(59.810f, 60, 200), "snowplow");

                CustomObjectsManager.Instance.RegisterObject(ModHelper.Instance.CreateExtraObject(snowplow, BoxSizes.Big, "Snowplow", "A snowplower, to make your car push snow arround.", 80, 10, "snowplow", AttachExtraTo.Body), "snowplow");
                // snowPlowCar = ExtrasManager.Instance.GetHolder("snowplow"); -- this is removed!
            }
        }

        /// <summary>
        /// This is the default Unity OnEnable() function, called as soon as the mod is enabled, before Awake() & Start().
        /// </summary>
        public override void OnEnable()
        {
            base.OnEnable();
        }

        /// <summary>
        /// This is the default Unity Awake() function, called as soon as the mod is enabled, before Start().
        /// </summary>
        public override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// This is the default Unity Start() function, called when the mod is enabled.
        /// </summary>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// This is the default Unity Update() function, called every frame after the mod is enabled.
        /// </summary>
        //public override void Update()
        //{
        //    base.Update();
        //    bool Snowplowpos = GetToggleValue("Snowplowup");
        //    if (Snowplowpos == true)
        //    {
        //        snowPlowCar.transform.localPosition = new Vector3(8.75f, -4, -1.90f);
        //    }
        //    else if (Snowplowpos == false)
        //    {
        //        snowPlowCar.transform.localPosition = new Vector3(8.75f, -2.5f, -1.90f);
        //    }
        //}

        public override void Update()
        {
            base.Update();

            if (snowPlowCar == null)
            {
                var ID = ExtrasManager.Instance.GetExtraIDByRegistryName("snowplow");
                snowPlowCar = ExtrasManager.Instance.GetHolder(ID).transform.GetChild(0).gameObject;
            }
            bool Snowplowpos = GetToggleValue("Snowplowup");
            if (Snowplowpos == true)
            {
                //  snowPlowCar.transform.localPosition = new Vector3(, , ); // figure out later
                //  snowPlowCar.transform.localEulerAngles = new Vector3(..., ..., ...); // figre out later
            }
            else
            {
               // snowPlowCar.transform.localPosition = new Vector3(3.77f, 0.22f, -0.03f);
                //  snowPlowCar.transform.localEulerAngles = Vector3.zero;
            }
        }
        /// <summary>
        /// This is the default Unity OnDisable() function, called when the mod is disabled.
        /// </summary>
        public override void OnDisable()
        {
            base.OnDisable();
        }
    }
}
