using Nop.Core;
using Nop.Core.Domain.Localization;
using System;
//using Nop.Core.Domain.Catalog;
namespace NopUI.Plugin.Widgets.Unit.Domain
{
    /// <summary>
    /// Represents a shipping by weight record
    /// </summary>
    public partial class UnitEntity : BaseEntity, ILocalizedEntity
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}