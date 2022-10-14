using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Model.Error;
public record UserAccountNotFoundException() : ErrorMessage()
{
    public override string Message => "UserAccount not found";
}
