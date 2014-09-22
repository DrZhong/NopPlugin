using FluentValidation;
using NopUI.Plugin.Widgets.Unit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopUI.Plugin.Widgets.Unit.Validators
{
    public class UnitModelValidator : AbstractValidator<UnitModel>
    {
        public UnitModelValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("不允许为空").Length(1,400).WithMessage("字段不允许为空");
        }
    }
}
