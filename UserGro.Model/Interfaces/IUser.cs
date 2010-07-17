using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGro.Model.Interfaces
{
    public interface IUser
    {
        //this will be the ID
        string UserName { get; set; }
        string Name { get; set; }
        string Email { get; set; } //Encrypt this.

        IList<IUser> Friends { get; set; }
        IList<IGroup> Groups { get; set; }

        //Region stuff goes here.
    }
}
