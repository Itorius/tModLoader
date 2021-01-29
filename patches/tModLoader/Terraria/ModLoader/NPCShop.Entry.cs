﻿using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public abstract partial class Entry
		{
			public readonly List<Condition> Conditions = new List<Condition>();

			public bool ConditionsMet => Conditions.All(condition => condition.Evaluate());

			public abstract IEnumerable<Item> GetItems(bool checkRequirements = true);

			public Entry AddCondition(NetworkText description, Func<bool> condition) => AddCondition(new SimpleCondition(description, condition));

			public Entry AddCondition(params Condition[] conditions) => AddCondition((IEnumerable<Condition>)conditions);

			public Entry AddCondition(IEnumerable<Condition> conditions)
			{
				Conditions.AddRange(conditions);

				return this;
			}
		}

		/// <summary>
		/// Returns an item, assuming all conditions are met
		/// </summary>
		public class EntryItem : Entry
		{
			private readonly Item item;

			protected EntryItem()
			{
			}

			public EntryItem(Item item)
			{
				this.item = item;
			}

			public EntryItem SetCurrency(int currencyID)
			{
				item.shopSpecialCurrency = currencyID;
				return this;
			}

			public EntryItem SetPrice(int price)
			{
				item.shopCustomPrice = price;
				return this;
			}

			public override IEnumerable<Item> GetItems(bool checkRequirements = true)
			{
				if (!checkRequirements || ConditionsMet)
					yield return item;
			}
		}

		/// <summary>
		/// Returns all entries that satisfy their conditions
		/// </summary>
		public class EntryList : Entry
		{
			protected readonly List<Entry> entries = new List<Entry>();

			public override IEnumerable<Item> GetItems(bool checkRequirements = true)
			{
				return entries.SelectMany(entry => entry.GetItems(checkRequirements));
			}

			public EntryItem AddEntry(int type)
			{
				Item item = new Item(type) { isAShopItem = true };
				EntryItem entry = new EntryItem(item);
				entries.Add(entry);
				return entry;
			}

			public EntryItem AddEntry<T>() where T : ModItem => AddEntry(ModContent.ItemType<T>());

			public T AddEntry<T>(T entry) where T : Entry
			{
				entries.Add(entry);
				return entry;
			}
		}

		/// <summary>
		/// Returns a random entry, assuming its conditions are met
		/// </summary>
		public class EntryListRandom : EntryList
		{
			public override IEnumerable<Item> GetItems(bool checkRequirements = true)
			{
				return entries[Main.rand.Next(entries.Count)].GetItems(checkRequirements);
			}
		}
	}
}