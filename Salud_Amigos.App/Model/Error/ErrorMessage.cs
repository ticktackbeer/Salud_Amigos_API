namespace Salud_Amigos.App.Model.Error;
public abstract record ErrorMessage()
{
    public abstract string Message { get; }

    public string Code => GetType().Name;
}