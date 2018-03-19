using System.Collections.Generic;
using Southernfund.UpdateSystem.IService.Base;
using Southernfund.UpdateSystem.Model;

namespace Southernfund.UpdateSystem.IService
{
    public interface IUserService : IBaseService<UserModel, string>
    {
        /// <summary>
        /// 根据id获取单个实体
        /// </summary>
        /// <returns></returns>
        UserModel GetUserInfoById(string id);
       
        /// <summary>
        /// 获取用户列表数据
        /// </summary>
        /// <returns></returns>
        List<UserModel> GetUserModels(UserModel model, out int totalCount);

        /// <summary>
        /// 获取角色名称列表
        /// </summary>
        /// <returns></returns>
        List<RoleModel> GetRoleNameList();

        /// <summary>
        /// 验证用户名密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pw">密码</param>
        /// <returns></returns>
        UserModel ValidateUser(string username, string pw, bool isNumber = false);

        bool CheckUserName(string userName);
    }
}
