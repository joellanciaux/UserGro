using System.Collections.Generic;

namespace UserGro.Model.Interfaces
{
    public interface IGroup
    {
        //There is the possiblity for groups to have the same name depending on region.
        string Id { get; set; }
        string Name { get; set; }

        IList<User> Users { get; set; }

    }
}