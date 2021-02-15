﻿using System;
using System.Linq.Expressions;
using System.Web;
using WebSite.Models;

namespace WebSite.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FirstOrDefault(Expression<Func<User, bool>> predicate);
        User FirstOrDefault();
        byte[] GetPhoto(HttpPostedFileBase file);
    }
}
