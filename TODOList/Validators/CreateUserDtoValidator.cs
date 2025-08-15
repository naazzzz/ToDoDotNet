using FluentValidation;
using TODOList.Configurations;
using TODOList.Http.DTO.User;

namespace TODOList.Validators;

public sealed class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator(ApplicationContext context)
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Имя пользователя обязательно.")
            .MinimumLength(3).WithMessage("Имя пользователя должно содержать минимум 3 символа.")
            .MaximumLength(50).WithMessage("Имя пользователя не должно превышать 50 символов.")
            .Must((createUserDto, cancellation) =>
            {
                return !context.Users.Any(u => u.UserName == createUserDto.Username);
            }).WithMessage("Пользователь с таким именем уже существует.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обязателен.")
            .MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
            .WithMessage("Пароль должен содержать как минимум одну заглавную букву, одну строчную букву и одну цифру.");
    }
}