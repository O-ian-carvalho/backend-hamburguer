﻿using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Models.Categorization;
using Hamurgueria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Status> GetStatusOrders(Guid statuseId)
        {
            return await Db.Status.AsNoTracking().Include(p => p.Orders).FirstOrDefaultAsync(p => p.Id == statuseId);
        }
    }
}
