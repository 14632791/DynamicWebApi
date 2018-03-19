using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using Southernfund.UpdateSystem.DAL;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.Model.Util;
using Southernfund.UpdateSystem.Service.Base;

namespace Southernfund.UpdateSystem.Service
{
    public class UserService : BaseService<UserModel, UP_ADMINUSER, string>, IUserService
    {
        /// <summary>
        /// 根据id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserInfoById(string id)
        {
            try
            {
              return  Get(id);
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("UserService-GetUserInfoById", e);
                return null;
            }
        }

        /// <summary>
        /// 获取用户列表数据
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<UserModel> GetUserModels(UserModel searchModel, out int totalCount)
        {
            totalCount = 0;
            try
            {
                if (string.IsNullOrEmpty(searchModel.search_name))
                {
                    return GetSearchListByPage(t => !string.IsNullOrEmpty(t.username), t => t.username, searchModel.pageSize, searchModel.page - 1, out totalCount).ToList();
                }else
                {
                    return GetSearchListByPage(t => searchModel.search_name == t.username, t => t.username, searchModel.pageSize, searchModel.page - 1, out totalCount).ToList();
                }
              
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("UserService-GetUserModels", e);
            }
            return null;
        }

        /// <summary>
        /// 获取角色名称列表
        /// </summary>
        /// <returns></returns>
        public List<RoleModel> GetRoleNameList()
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("UserService-GetRoleNameList", e);
            }
            return null;
        }

        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="uName">用户名称</param>
        /// <param name="pw">用户密码</param>
        /// <returns></returns>
        public UserModel ValidateUser(string uName, string pw, bool isNumber = false)
        {
           
            try
            {
                return GetSearchList(p => p.username == uName && p.pwd == pw).FirstOrDefault();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("UserService-ValidateUser", e);
            }
            return null;
        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUserName(string userName)
        {
           return GetSearchListEf(u => u.username == userName)?.Count() > 0;
        }
        protected override string GetPrimaryKey(UserModel entity)
        {
            return entity.UsId;
        }
        public override UP_ADMINUSER ConvertToModel(UserModel model)
        {
            return new UP_ADMINUSER
            {
                id = string.IsNullOrEmpty(model.UsId) ? Guid.NewGuid().ToString("N") : model.UsId,
                createdby = model.CreatedBy,
                createdon = model.CreatedOn,
                modifiedby = model.ModifiedBy,
                modifiedon = model.ModifiedOn,
                phone = model.Phone,
                pwd = model.Password,
                realname = model.RealName,
                remark = model.Remark,
                sex = model.Sex,
                type = model.Type,
                username = model.UserName,
                birthday = model.Birthday,
                department = model.Department,
                isdisabled = model.IsDisabled,
                isvalidate = model.is_validate,
                merid = model.MerId
            };
        }
        public override UserModel ConvertToModel(UP_ADMINUSER EfModel)
        {
            return new UserModel
            {
                UsId = EfModel.id,
                CreatedBy = EfModel.createdby,
                CreatedOn = EfModel.createdon,
                ModifiedBy = EfModel.modifiedby,
                ModifiedOn = EfModel.modifiedon,
                Phone = EfModel.phone,
                Password = EfModel.pwd,
                RealName = EfModel.realname,
                Remark = EfModel.remark,
                Sex = EfModel.sex,
                Type = EfModel.type,
                UserName = EfModel.username,
                Birthday = EfModel.birthday,
                Department = EfModel.department,
                IsDisabled = EfModel.isdisabled,
                is_validate = EfModel.isvalidate,
                MerId = EfModel.merid
            };
        }

    }
}
