﻿using Materal.TTA.Common;
using Microsoft.EntityFrameworkCore;

namespace Materal.TTA.SqliteRepository
{
    public class SqliteEFUnitOfWorkImpl<T> : EFUnitOfWorkImpl<T> where T : DbContext
    {
        public SqliteEFUnitOfWorkImpl(T context) : base(context)
        {
        }
    }
}
