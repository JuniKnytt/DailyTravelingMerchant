using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
namespace DailyTravelingMerchant
{
	public class DailyTravelingMerchant : Mod
	{
        public DailyTravelingMerchant()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

        }

    }
    public class Modworld : ModWorld
    {

        public override void PostUpdate()
        {
            bool isThereMerchant = false;
            int iNPCcount = 0;

            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].type == NPCID.TravellingMerchant)
                {
                    isThereMerchant = true;
                    break;
                }
            }

            if (!isThereMerchant)
            {
                if (!Terraria.NPC.travelNPC && !Main.fastForwardTime && Main.dayTime && Main.time < 27000.0 && iNPCcount < 3)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].townNPC)
                        {
                            iNPCcount++;
                           // Main.NewText(iNPCcount);
                        }
                    }
                }




                if (!Terraria.NPC.travelNPC && !Main.fastForwardTime && Main.dayTime && Main.time < 27000.0 && iNPCcount >= 3)
                {
                    WorldGen.SpawnTravelNPC();
                   // Main.NewText("SPAWN " + iNPCcount);
                   // Main.NewText("SPAWN " + !Terraria.NPC.travelNPC);
                }
            }
        }

    }
}