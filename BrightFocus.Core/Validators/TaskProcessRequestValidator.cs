namespace BrightFocus.Core.Validators
{
    public class TaskProcessRequestValidator : AbstractValidator<TaskProcessRequest>
    {
        public TaskProcessRequestValidator()
        {
            _ = RuleFor(x => x.StepOne)
                .NotEmpty().WithMessage("Bước 1 không được để trống.");

            _ = RuleFor(x => x.StepTwo)
                .NotEmpty().WithMessage("Bước 2 không được để trống.");

            _ = RuleFor(x => x.StepThree)
                .NotEmpty().WithMessage("Bước 3 không được để trống.");

            _ = RuleFor(x => x.StepFour)
                .NotEmpty().WithMessage("Bước 4 không được để trống.");

            _ = RuleFor(x => x.StepFive)
                .NotEmpty().WithMessage("Bước 5 không được để trống.");

            _ = RuleFor(x => x.StepSix)
                .NotEmpty().WithMessage("Bước 6 không được để trống.");

            _ = RuleFor(x => x.StepSeven)
                .NotEmpty().WithMessage("Bước 7 không được để trống.");

            _ = RuleFor(x => x.StepEight)
                .NotEmpty().WithMessage("Bước 8 không được để trống.");
        }
    }
}
