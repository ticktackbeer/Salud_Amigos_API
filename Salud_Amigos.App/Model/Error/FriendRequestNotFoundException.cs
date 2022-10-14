using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Model.Error;
public record FriendRequestNotFoundException() : ErrorMessage()
{
    public override string Message => "Friend Request not found";
}
