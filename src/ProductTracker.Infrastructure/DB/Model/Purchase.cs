// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	/// <summary>
	/// Информация о покупке в магазине
	/// </summary>
	[Table("purchase")]
	public class Purchase
	{
		/// <summary>
		/// Уникальный идентификатор
		/// </summary>
		[Column("id"         , IsPrimaryKey = true, IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long     Id         { get; set; } // bigint
		/// <summary>
		/// Дата покупки
		/// </summary>
		[Column("bought_date"                                                                                  )] public DateTime BoughtDate { get; set; } // timestamp (6) without time zone
		/// <summary>
		/// Идентификатор дома, для которого совершена покупка
		/// </summary>
		[Column("house_id"                                                                                     )] public long     HouseId    { get; set; } // bigint

		#region Associations
		/// <summary>
		/// house_purchase_id_fkey
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(HouseId), OtherKey = nameof(DataModel.House.Id))]
		public House House { get; set; } = null!;

		/// <summary>
		/// purchase_id_fkey backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(PurchaseXrefGood.PurchaseId))]
		public IEnumerable<PurchaseXrefGood> PurchaseXrefGoods { get; set; } = null!;
		#endregion
	}
}
