using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IRightService
    {
        void CreateRight(Right right);
        IEnumerable<Right> GetAllRight();
        Right GetRightFromId(int rightId);
        void UpdateRight(Right right);
        void RemoveRight(int rightId);
    }
}
