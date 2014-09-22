using FluentValidation.Attributes;
using NopUI.Plugin.Widgets.Unit.Validators;
using Nop.Web.Framework;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopUI.Plugin.Widgets.Unit.Models
{
    [Validator(typeof(UnitModelValidator))]
    public partial class UnitModel : BaseNopEntityModel, ILocalizedModel<UnitModelLocalizedModel>
    {
        public UnitModel()
        {
            Locales = new List<UnitModelLocalizedModel>();
        }
        [NopResourceDisplayName("名称")]
        public string Name { get; set; }

        [NopResourceDisplayName("排序")]
        public int DisplayOrder { get; set; }

        public IList<UnitModelLocalizedModel> Locales
        {
            get;
            set;
        }
    }
    public class UnitModelLocalizedModel : ILocalizedModelLocal
    {

        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Description")]
        public string Description { get; set; }
    }
}
