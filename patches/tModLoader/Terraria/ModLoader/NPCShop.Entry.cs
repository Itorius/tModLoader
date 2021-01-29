using System;
using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public partial class Entry
		{
			public readonly Item item;
			public readonly List<Condition> Conditions = new List<Condition>();

			public Entry(Item item)
			{
				this.item = item;
			}

			public Entry SetCurrency(int currencyID)
			{
				item.shopSpecialCurrency = currencyID;
				return this;
			}

			public Entry SetPrice(int price)
			{
				item.shopCustomPrice = price;
				return this;
			}

			public Entry AddCondition(NetworkText description, Predicate<Entry> condition) => AddCondition(new Condition(description, condition));

			public Entry AddCondition(params Condition[] conditions) => AddCondition((IEnumerable<Condition>)conditions);

			public Entry AddCondition(IEnumerable<Condition> conditions)
			{
				Conditions.AddRange(conditions);

				return this;
			}
		}
	}
}