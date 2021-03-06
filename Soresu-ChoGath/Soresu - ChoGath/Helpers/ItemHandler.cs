﻿using LeagueSharp;
using LeagueSharp.Common;

namespace Soresu___ChoGath.Helpers
{

    public class ItemHandler
    {
        public static Obj_AI_Hero player = ObjectManager.Player;
        public static Items.Item botrk = new Items.Item(3153, 450);
        public static Items.Item tiamat = new Items.Item(3077, 400);
        public static Items.Item hydra = new Items.Item(3074, 400);
        public static Items.Item randuins = new Items.Item(3143, 500);
        public static Items.Item odins = new Items.Item(3180, 520);
        public static Items.Item bilgewater = new Items.Item(3144, 450);
        public static Items.Item hexgun = new Items.Item(3146, 700);
        public static Items.Item Dfg = new Items.Item(3128, 750);
        public static Items.Item Bft = new Items.Item(3188, 750);
        public static Items.Item sheen = new Items.Item(3057, player.AttackRange);
        public static Items.Item gaunlet = new Items.Item(3025, player.AttackRange);
        public static Items.Item trinity = new Items.Item(3078, player.AttackRange);
        public static Items.Item lich = new Items.Item(3100, player.AttackRange);

        public static Items.Item Qss = new Items.Item(3140, 0);
        public static Items.Item Mercurial = new Items.Item(3139, 0);

        public static void UseItems(Obj_AI_Hero target)
        {
            if (player.Distance(target) < hydra.Range)
            {
                if (Items.HasItem(tiamat.Id) && Items.CanUseItem(tiamat.Id))
                {
                    Items.UseItem(tiamat.Id);
                }
                if (Items.HasItem(hydra.Id) && Items.CanUseItem(hydra.Id))
                {
                    Items.UseItem(hydra.Id);
                }
            }
            if (Items.HasItem(randuins.Id) && Items.CanUseItem(randuins.Id))
            {
                if (player.Distance(target) < randuins.Range && player.Distance(target) > player.AttackRange + 100)
                {
                    Items.UseItem(randuins.Id);
                }
            }
            if (Items.HasItem(odins.Id) && Items.CanUseItem(odins.Id))
            {
                if (player.Distance(target) < odins.Range &&
                    (player.CountEnemysInRange(odins.Range) > 1 ||
                     target.Health < Damage.GetItemDamage(player, target, Damage.DamageItems.OdingVeils)))
                {
                    Items.UseItem(odins.Id);
                }
            }
            if (Items.HasItem(bilgewater.Id) && Items.CanUseItem(bilgewater.Id))
            {
                bilgewater.Cast(target);
            }
            if (Items.HasItem(botrk.Id) && Items.CanUseItem(botrk.Id) && (player.Health < player.MaxHealth / 2 || Damage.GetItemDamage(player,target,Damage.DamageItems.Botrk)<target.Health))
            {
                botrk.Cast(target);
            }
            if (Items.HasItem(hexgun.Id) && Items.CanUseItem(hexgun.Id))
            {
                hexgun.Cast(target);
            }
            if (Items.HasItem(Dfg.Id) && Items.CanUseItem(Dfg.Id))
            {
                Dfg.Cast(target);
            }
            if (Items.HasItem(Bft.Id) && Items.CanUseItem(Bft.Id))
            {
                Bft.Cast(target);
            }
        }

        public static float GetItemsDamage(Obj_AI_Hero target)
        {
            double damage = 0;
            if (Items.HasItem(odins.Id) && Items.CanUseItem(odins.Id))
            {
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.OdingVeils);
            }
            if (Items.HasItem(hexgun.Id) && Items.CanUseItem(hexgun.Id))
            {
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.Hexgun);
            }
            if (Items.HasItem(lich.Id) && Items.CanUseItem(lich.Id))
            {
                damage += player.CalcDamage(target, Damage.DamageType.Magical, player.BaseAttackDamage * 0.75 + player.FlatMagicDamageMod*0.5);
            }
            if (Items.HasItem(Dfg.Id) && Items.CanUseItem(Dfg.Id))
            {
                damage = damage*1.2;
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.Dfg);
            }
            if (Items.HasItem(Bft.Id) && Items.CanUseItem(Bft.Id))
            {
                damage = damage * 1.2;
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.BlackFireTorch);
            }
            if (Items.HasItem(tiamat.Id) && Items.CanUseItem(tiamat.Id))
            {
                damage += Damage.GetItemDamage(player,target, Damage.DamageItems.Tiamat);
            }
            if (Items.HasItem(hydra.Id) && Items.CanUseItem(hydra.Id))
            {
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.Hydra);
            }
            if (Items.HasItem(bilgewater.Id) && Items.CanUseItem(bilgewater.Id))
            {
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.Bilgewater);
            }
            if (Items.HasItem(botrk.Id) && Items.CanUseItem(botrk.Id))
            {
                damage += Damage.GetItemDamage(player, target, Damage.DamageItems.Botrk);
            }
            if (Items.HasItem(sheen.Id) && (Items.CanUseItem(sheen.Id) || player.HasBuff("sheen", true)))
            {
                damage += player.CalcDamage(target, Damage.DamageType.Physical, player.BaseAttackDamage);
            }
            if (Items.HasItem(gaunlet.Id) && Items.CanUseItem(gaunlet.Id))
            {
                damage += player.CalcDamage(target, Damage.DamageType.Physical, player.BaseAttackDamage * 1.25);
            }
            if (Items.HasItem(trinity.Id) && Items.CanUseItem(trinity.Id))
            {
                damage += player.CalcDamage(target, Damage.DamageType.Physical, player.BaseAttackDamage * 2);
            }
            return (float)damage;
        }

    }
}