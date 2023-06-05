
using StudyWPFProject.Infrastructure.Commands.Base;
using System;

namespace StudyWPFProject.Infrastructure.Commands;

internal class LambdaCommand : BaseCommand
{
    private readonly Action<object> _Execute;
    private readonly Func<object, bool> _CanExecute;

    public override bool CanExecute(object? parameter)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(object? parameter)
    {
        throw new System.NotImplementedException();
    }
    public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null!)
    {
        _Execute = Execute;
        _CanExecute = CanExecute;
    }
}
