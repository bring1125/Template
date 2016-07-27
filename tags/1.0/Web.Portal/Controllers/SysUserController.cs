﻿//------------------------------------------------------------
// <copyright file="SysUserController.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>周夏龙</author>
// <date>02/26/2016 15:09:29</date>
// <summary>
// 		
// </summary>
//------------------------------------------------------------

namespace Web.Portal.Controllers
{
    using System.Web.Mvc;
    using Web.Portal.Toolkits;
    using Wikitec.Application.SystemManagement;
    using Wikitec.DataTransferObject.SystemConfig;
    using Wikitec.Infrastructure.Mvc.ModelBinder;
    using Wikitec.Infrastructure.Unity.Ioc;

    /// <summary>
    /// 用户信息控制器
    /// </summary>
    public class SysUserController : BaseController
    {
        /// <summary>
        /// 员工业务逻辑
        /// </summary>
        private readonly SysUserMgtService userMgtService;

        /// <summary>
        /// 下拉框选项业务逻辑
        /// </summary>
        private readonly ComboboxMgtService comboboxMgtService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SysUserController()
        {
            this.userMgtService = IocManager.Instance.Resolve<SysUserMgtService>();
            this.comboboxMgtService = IocManager.Instance.Resolve<ComboboxMgtService>();
        }

        /// <summary>
        /// 获取用户分页信息列表
        /// </summary>
        /// <param name="searchInput">查询条件</param>
        /// <returns>用户信息</returns>
        [HttpGet]
        public JsonResult GetUserByOrgId([FromJson]SysUserSearch searchInput)
        {
            var orgId = int.Parse(UserIdentity.CurrentSysUser.OrgId.ToString());
            var result = this.userMgtService.GetUserByOrgId(orgId, searchInput);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增或修改用户
        /// </summary>
        /// <param name="dto">用户信息</param>
        [HttpPost]
        public void AddOrUpdateSysUser([FromJson]SysUserDto dto)
        {
            var orgId = int.Parse(UserIdentity.CurrentSysUser.OrgId.ToString());
            this.userMgtService.UpdateUser(dto, orgId);
        }

        /// <summary>
        /// 根据登录账户获取用户信息
        /// </summary>
        /// <param name="account">登录账户</param>
        /// <returns>用户信息</returns>
        [HttpGet]
        public JsonResult GetUserByAccount(string account)
        {
            int orgId = int.Parse(UserIdentity.CurrentSysUser.OrgId.ToString());
            var result = this.userMgtService.GetUserOfHttp(account, orgId);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取性别选项列表
        /// </summary>
        /// <returns>性别列表</returns>
        [HttpGet]
        public JsonResult GetGederCombobox()
        {
            var result = this.comboboxMgtService.GetGederCombobox();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}