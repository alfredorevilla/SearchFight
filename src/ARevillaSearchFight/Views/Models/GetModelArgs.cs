using System;

namespace ARevillaSearchFight.Views.Models
{
    public class GetModelArgs : EventArgs
    {
        internal GetModelArgs(object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            this.Model = model;
        }

        public object Model { get; }
    }
}