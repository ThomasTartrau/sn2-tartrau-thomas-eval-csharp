﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DTO
{
    public interface ICercle_Service : IService<Cercle_DTO>
    {
        double CalculerAire(Cercle_DTO cercle_DTO);
    }
}
