using Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Employees
{
    public class EmployeeValidators:AbstractValidator<VM_CreateEmployee>
    {
        public EmployeeValidators()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsiminizi Giriniz!!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisminizi Giriniz!!");
            RuleFor(x => x.Position).NotEmpty().WithMessage("Pozisyonunuzu Giriniz!!");
        }
    }
}
