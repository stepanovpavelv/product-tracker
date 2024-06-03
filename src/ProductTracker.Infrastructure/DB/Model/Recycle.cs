// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	/// <summary>
	/// Утилизация
	/// </summary>
	[Table("recycle")]
	public class Recycle
	{
		/// <summary>
		/// Уникальный идентификатор
		/// </summary>
		[Column("id"                    , IsPrimaryKey = true, IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long     Id                  { get; set; } // bigint
		/// <summary>
		/// Ссылка на продукт из покупки
		/// </summary>
		[Column("purchase_xref_goods_id"                                                                                  )] public long     PurchaseXrefGoodsId { get; set; } // bigint
		/// <summary>
		/// Дата утилизации / употребления
		/// </summary>
		[Column("util_date"                                                                                               )] public DateTime UtilDate            { get; set; } // timestamp (6) without time zone

		#region Associations
		/// <summary>
		/// purchase_xref_goods_id_fkey
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(PurchaseXrefGoodsId), OtherKey = nameof(PurchaseXrefGood.Id))]
		public PurchaseXrefGood PurchaseXrefGoods { get; set; } = null!;
		#endregion
	}
}
