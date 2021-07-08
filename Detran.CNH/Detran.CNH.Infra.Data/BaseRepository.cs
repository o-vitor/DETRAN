using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Infra.Data
{
    public class BaseRepository
    {
        public readonly DetranCNHDbContext Context;
        public BaseRepository(DetranCNHDbContext context)
        {
            this.Context = context;
        }
    }
}
