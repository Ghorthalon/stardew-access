using Microsoft.Xna.Framework.Audio;
using StardewValley;

namespace stardew_access
{
    internal class CustomSoundEffects
    {
        internal enum TYPE
        {
            Sound,
            Footstep
        }

        internal static void Initialize()
        {
            try
            {
                if (MainClass.ModHelper == null)
                    return;

                Dictionary<String, TYPE> soundEffects = new()
                {
                    { "drop_item", TYPE.Sound },
                    { "colliding", TYPE.Sound },
                    { "invalid-selection", TYPE.Sound },
                    { "youve_got_mail", TYPE.Sound },

                    { "bobber_progress", TYPE.Sound },

                    { "npc_top", TYPE.Footstep },
                    { "npc_right", TYPE.Footstep },
                    { "npc_left", TYPE.Footstep },
                    { "npc_bottom", TYPE.Footstep },

                    { "buildings_top", TYPE.Footstep },
                    { "buildings_right", TYPE.Footstep },
                    { "buildings_left", TYPE.Footstep },
                    { "buildings_bottom", TYPE.Footstep },

                    { "chests_top", TYPE.Footstep },
                    { "chests_right", TYPE.Footstep },
                    { "chests_left", TYPE.Footstep },
                    { "chests_bottom", TYPE.Footstep },

                    { "crops_top", TYPE.Footstep },
                    { "crops_right", TYPE.Footstep },
                    { "crops_left", TYPE.Footstep },
                    { "crops_bottom", TYPE.Footstep },

                    { "debris_top", TYPE.Footstep },
                    { "debris_right", TYPE.Footstep },
                    { "debris_left", TYPE.Footstep },
                    { "debris_bottom", TYPE.Footstep },

                    { "default_top", TYPE.Footstep },
                    { "default_right", TYPE.Footstep },
                    { "default_left", TYPE.Footstep },
                    { "default_bottom", TYPE.Footstep },

                    { "farmanimal_top", TYPE.Footstep },
                    { "farmanimal_right", TYPE.Footstep },
                    { "farmanimal_left", TYPE.Footstep },
                    { "farmanimal_bottom", TYPE.Footstep },

                    { "farmer_top", TYPE.Footstep },
                    { "farmer_right", TYPE.Footstep },
                    { "farmer_left", TYPE.Footstep },
                    { "farmer_bottom", TYPE.Footstep },

                    { "flooring_top", TYPE.Footstep },
                    { "flooring_right", TYPE.Footstep },
                    { "flooring_left", TYPE.Footstep },
                    { "flooring_bottom", TYPE.Footstep },

                    { "furniture_top", TYPE.Footstep },
                    { "furniture_right", TYPE.Footstep },
                    { "furniture_left", TYPE.Footstep },
                    { "furniture_bottom", TYPE.Footstep },

                    { "mineitems_top", TYPE.Footstep },
                    { "mineitems_right", TYPE.Footstep },
                    { "mineitems_left", TYPE.Footstep },
                    { "mineitems_bottom", TYPE.Footstep },

                    { "other_top", TYPE.Footstep },
                    { "other_right", TYPE.Footstep },
                    { "other_left", TYPE.Footstep },
                    { "other_bottom", TYPE.Footstep },

                    { "trees_top", TYPE.Footstep },
                    { "trees_right", TYPE.Footstep },
                    { "trees_left", TYPE.Footstep },
                    { "trees_bottom", TYPE.Footstep },

                    { "water_top", TYPE.Footstep },
                    { "water_right", TYPE.Footstep },
                    { "water_left", TYPE.Footstep },
                    { "water_bottom", TYPE.Footstep },

                    { "obj_top", TYPE.Footstep },
                    { "obj_right", TYPE.Footstep },
                    { "obj_left", TYPE.Footstep },
                    { "obj_bottom", TYPE.Footstep },

                    { "npc_mono_top", TYPE.Footstep },
                    { "npc_mono_right", TYPE.Footstep },
                    { "npc_mono_left", TYPE.Footstep },
                    { "npc_mono_bottom", TYPE.Footstep },

                    { "obj_mono_top", TYPE.Footstep },
                    { "obj_mono_right", TYPE.Footstep },
                    { "obj_mono_left", TYPE.Footstep },
                    { "obj_mono_bottom", TYPE.Footstep }
                };

                for (int i = 0; i < soundEffects.Count; i++)
                {
                    KeyValuePair<String, TYPE> soundEffect = soundEffects.ElementAt(i);

                    CueDefinition cueDefinition = new()
                    {
                        name = soundEffect.Key
                    };

                    if (soundEffect.Value == TYPE.Sound)
                    {
                        cueDefinition.instanceLimit = 1;
                        cueDefinition.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
                    }

                    SoundEffect effect;
                    string filePath = Path.Combine(MainClass.ModHelper.DirectoryPath, "assets", "sounds", $"{soundEffect.Key}.wav");
                    using (FileStream stream = new(filePath, FileMode.Open))
                    {
                        effect = SoundEffect.FromStream(stream);
                    }

                    if (soundEffect.Value == TYPE.Sound)
                        cueDefinition.SetSound(effect, Game1.audioEngine.GetCategoryIndex("Sound"), false);
                    else if (soundEffect.Value == TYPE.Footstep)
                        cueDefinition.SetSound(effect, Game1.audioEngine.GetCategoryIndex("Footsteps"), false);

                    Game1.soundBank.AddCue(cueDefinition);
                }
            }
            catch (Exception e)
            {
                Log.Error($"Unable to initialize custom sounds:\n{e.Message}\n{e.StackTrace}");
            }
        }
    }
}
