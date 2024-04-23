using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nytronix.Items
{
	public class Nytronix : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.Nytronix.hjson file.

		public int eventKills;

		public override void SetDefaults()
		{
			Item.CanHavePrefixes();
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override System.Nullable<System.Boolean> CanHitNPC(Player player, NPC target)
        {
			if (target.townNPC || !target.CountsAsACritter) {  return true; } else { return false; }
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
			tooltips.Add(new TooltipLine(Mod, Name, "You should NOT have obtained this \n" + eventKills + " Bosses before the event..."));
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, System.Int32 damageDone)
        {
			if (target.townNPC)
			{
				target.life += damageDone;
				target.AddBuff(BuffID.Regeneration, 120);
			}
			else
			{
				target.AddBuff(BuffID.Poisoned, 50);
			}

			if(target.life - damageDone <= 0 && target.boss)
			{
				eventKills++;
				if(eventKills > 9)
				{
					//call custom event
				}
			}
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddCondition(Condition.Hardmode);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			Recipe recipe1 = CreateRecipe();
            recipe1.AddCondition(Condition.Hardmode);
            recipe1.AddIngredient(ItemID.LeadBar, 5);
			recipe1.AddIngredient(ItemID.Wood, 5);
			recipe1.AddTile(TileID.Anvils);
			recipe1.Register();
		}
	}
}