﻿//------------------------------------------------------------
// <copyright file="SysRoleRepository.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>周夏龙</author>
// <date>2016/2/25 10:46:11</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

namespace Wikitec.Repository.Repositories.SystemConfig
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wikitec.Domain.SystemConfig;
    using Wikitec.Domain.SystemConfig.IRepository;
    using Wikitec.Infrastructure.Data.IQueryable;

    /// <summary>
    /// 角色数据储存器
    /// </summary>
    public class SysRoleRepository : RepositoryBaseForOrg<SysRole>, ISysRoleRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public SysRoleRepository(DataContext context)
            : base(context)
        {
        }
    }
}